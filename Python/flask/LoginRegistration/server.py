from flask import Flask, session, request, redirect, render_template, flash
from mysqlconnection import MySQLConnector
import md5
import os, binascii
import re

app = Flask(__name__)
app.secret_key = "secret"
mysql = MySQLConnector(app, 'friendsdb')
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

@app.route('/')
def index():
    return render_template("index.html")

@app.route('/validate', methods=["POST"])
def validate():
    error = 0

    salt = binascii.b2a_hex(os.urandom(15))

    first_name = request.form['firstname']
    last_name = request.form['lastname']
    email = request.form['email']
    password = request.form['password']
    server_pw = md5.new(password + salt).hexdigest()

    if request.form['type'] == "registration": # if user is trying to register
        confrim_pw = request.form['confirm_pass']

        user_data = [first_name, last_name, password, confrim_pw]

        for data in user_data:
            if len(data) < 1:
                flash("You can't leave anything black!")
                error += 1
        
        if (not first_name.isalpha() or not last_name.isalpha()) or (len(first_name) < 2 or len(last_name) < 2):
            flash("First and Last name must be at least 2 characters (no number!)")
            error += 1
        
        if not EMAIL_REGEX.match(email):
            flash("Your email form is weird")
            error += 1
        if len(password) < 8:
            flash("PW too short")
            error += 1
        if password != confrim_pw:
            flash("Your passwords don't match")
            error += 1

        if error > 0:
            return redirect("/")


        query = "INSERT INTO users (first_name, last_name, email, password, salt) VALUES (:first_name, :last_name, :email, :password, :salt)"

        data = {
            "first_name": first_name,
            "last_name": last_name,
            "email": email,
            "password": server_pw,
            "salt": salt
        }

        mysql.query_db(query,data)

        return redirect("/success")

    else: # if user is trying to log in
        
        query = "SELECT * FROM users WHERE email = :email LIMIT 1"
        data = {"email": email}
        result = mysql.query_db(query, data)
        if len(result) != 0:
            encrypted_password = md5.new(password + result[0]['salt']).hexdigest();
            if result[0]['password'] == encrypted_password:
                return redirect("/success")
            else:
                flash("invalid password")
                return redirect("/")
        else:
            flash("email not found")
            return redirect("/")

    
@app.route('/success')
def success():
    return render_template("success.html")

app.run(debug=True)