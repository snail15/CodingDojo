from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
mysql = MySQLConnector(app,'friendsdb')
@app.route('/')
def index():
    users = mysql.query_db("SELECT * FROM friends")
    return render_template('index.html', users=users)

@app.route('/add_user', methods=['POST', "GET"])
def add_user():
    
    if request.method == "POST":       
        query = "INSERT INTO friends (name, age, created_at) VALUES (:name, :age, DATE_FORMAT(NOW(), '%m/%d/%Y %T'))"

        data = {
            "name": request.form['name'],
            "age": request.form["age"]
        }
        mysql.query_db(query, data)

        return redirect('/')
    else:
        return render_template("add.html")

@app.route('/show/<user_id>')
def show_user(user_id):
    
    query = "SELECT * FROM friends WHERE id = :user_id"
    data = {"user_id": user_id}

    user = mysql.query_db(query, data)
    print(user[0]["name"])

    return render_template("show.html", user= user)

@app.route('/edit/<user_id>', methods=["POST", "GET"])
def edit_user(user_id):
    
    user = mysql.query_db("SELECT * FROM friends WHERE id = " + str(user_id))
    show_user = user[0]

    if request.method == "POST":       
        query = "UPDATE friends SET name= :name, age = :age, created_at = DATE_FORMAT(NOW(), '%m/%d/%Y %T') WHERE id = :user_id"

        data = {
            "name": request.form['name'],
            "age": request.form["age"],
            "user_id": user_id
        }
        
        mysql.query_db(query, data)

        return redirect('/show/' + str(user_id))
    else:
        
        return render_template("edit.html", user = show_user)

@app.route('/delete/<user_id>', methods=['GET', 'POST'])
def method_name(user_id):
    
    query = "DELETE FROM friends where id = :user_id"
    data = { "user_id": user_id }
    mysql.query_db(query,data)

    return redirect('/')

app.run(debug=True)