from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
mysql = MySQLConnector(app,'friendsdb')
app.secret_key = "secret"
@app.route('/')
def index():
    friends = mysql.query_db("SELECT * FROM friends")
    print (friends)
    return render_template('index.html', friends=friends)

@app.route('/validate', methods=['POST'])
def create():
    
    email = request.form['email']

    query = "SELECT * FROM emails WHERE email ='" + email + "'" 

    emails = mysql.query_db(query)

    if len(emails) < 1:
        insertQuery = "INSERT INTO emails (email, created_at) VALUES (:email, DATE_FORMAT(NOW(), '%m/%d/%Y %T'))"
        data = {
            "email": email
        }
        mysql.query_db(insertQuery, data)
        emails = mysql.query_db("SELECT * FROM emails")

        return render_template("success.html", email=email, emails = emails)
    
    else:    
        flash("Invalid Email!")
    return redirect('/')

@app.route('/success')
def success():
    return render_template("success.html")

app.run(debug=True)