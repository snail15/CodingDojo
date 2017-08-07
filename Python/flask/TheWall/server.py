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

    email = request.form['email']
    password = request.form['password']
   
    server_pw = md5.new(password + salt).hexdigest()

    if request.form['type'] == "registration": # if user is trying to register
        confrim_pw = request.form['confirm_pass']
        first_name = request.form['firstname']
        last_name = request.form['lastname']

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


        query = "INSERT INTO users (first_name, last_name, email, password, salt, created_at, updated_at) VALUES (:first_name, :last_name, :email, :password, :salt,DATE_FORMAT(NOW(), '%m/%d/%Y'), DATE_FORMAT(NOW(), '%m/%d/%Y'))"

        data = {
            "first_name": first_name,
            "last_name": last_name,
            "email": email,
            "password": server_pw,
            "salt": salt
        }

        mysql.query_db(query,data)

        create_session("SELECT id FROM users WHERE email = :email", data)

        return redirect("/wall")

    else: # if user is trying to log in
        
        query = "SELECT * FROM users WHERE email = :email LIMIT 1"
        data = {
            "email": email,
            "password": server_pw,
            "salt": salt
        }
        result = mysql.query_db(query, data)
        if len(result) != 0:
            encrypted_password = md5.new(password + result[0]['salt']).hexdigest();
            if result[0]['password'] == encrypted_password:
                name = result[0]["first_name"] + " " + result[0]['last_name']
                create_session(query, data, name)
                return redirect("/wall")
            else:
                flash("invalid password")
                return redirect("/")
        else:
            flash("email not found")
            return redirect("/")

    
@app.route('/wall')
def wall():
    
    messages = mysql.query_db("SELECT CONCAT(users.first_name,' ', users.last_name) as name, user_id, message, messages.id FROM users JOIN messages ON users.id = messages.user_id")
    comments = mysql.query_db("SELECT * FROM comments ORDER BY updated_at")
    comment_dict = {}
    for c in comments:
        comment_dict[c['message_id']] = c['comment']
    print(comment_dict) 
    return render_template("wall.html", messages = messages, comments = comments)



@app.route('/post', methods=["POST"])
def post_message():
    
    
    message = request.form["message"]
    print(message)

    if len(message) > 0:
        
        user_id = session["user_id"]

        query = "INSERT INTO messages (user_id, message, created_at, updated_at) VALUES (:user_id, :message, DATE_FORMAT(NOW(), '%m/%d/%Y %T'), DATE_FORMAT(NOW(), '%m/%d/%Y %T'))"

        data = { "user_id": user_id, "message": message }
        
        mysql.query_db(query, data)

        return redirect("/wall")

    return redirect("/wall")

@app.route('/delete_post/<message_id>')
def delete_post(message_id):
    
    query = "DELETE FROM messages WHERE id = :id"
    data = { "id": message_id}

    mysql.query_db(query, data)

    return redirect("/wall")

@app.route('/delete_comment/<comment_id>')
def delete_comment(comment_id):
    
    query = "DELETE FROM comments WHERE id = :id"
    data = { "id": comment_id}

    mysql.query_db(query, data)

    return redirect("/wall")

@app.route('/logout')
def logout():
    
    session.pop("user_id", None)
    session.pop("user_name", None)
    return redirect("/")


@app.route('/post_comment/<message_id>', methods=['POST'])
def post_comment(message_id):
    
    query = "INSERT INTO comments (user_id, message_id, comment, created_at, updated_at) VALUES (:user_id, :message_id, :comment, DATE_FORMAT(NOW(), '%m/%d/%Y %T'), DATE_FORMAT(NOW(), '%m/%d/%Y %T'))"
    data = {
        "user_id": session["user_id"],
        "message_id": message_id,
        "comment": request.form['comment']
    }
    
    mysql.query_db(query, data)

    return redirect('/wall')

def create_session(query, data, name=None):
    
    if name == None:
        session["user_name"] = data["first_name"] + " " + data["last_name"]
    else:
        session["user_name"] = name


    user_id = mysql.query_db(query, data)
    session["user_id"] = user_id[0]["id"]
    
app.run(debug=True)