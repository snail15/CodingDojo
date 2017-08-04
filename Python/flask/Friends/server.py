from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
mysql = MySQLConnector(app,'friendsdb')
@app.route('/')
def index():
    friends = mysql.query_db("SELECT * FROM friends")
    print (friends)
    return render_template('index.html', friends=friends)

@app.route('/add_friend', methods=['POST'])
def create():
    
    query = "INSERT INTO friends (name, age, created_at) VALUES (:name, :age, DATE_FORMAT(NOW(), '%m/%d/%Y'))"

    data = {
        "name": request.form['name'],
        "age": request.form["age"]
    }
    mysql.query_db(query, data)

    return redirect('/')
app.run(debug=True)