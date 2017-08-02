from flask import Flask, render_template, session, flash, request, redirect
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
app = Flask(__name__)
app.secret_key = "secret"

@app.route('/')
def index():
   return render_template("index.html")

@app.route('/process', methods=['POST'])
def validate():
    
    first_name = request.form["firstname"]
    last_name = request.form["lastname"]
    email = request.form["email"]
    password = request.form["password"]
    confirm = request.form["confirm"]

    if len(first_name) < 1 or len(last_name) < 1 or len(email) < 1 or len(password) < 1 or len(confirm) < 1:
        
        flash("Nothing can be blank!")
    
    if not first_name.isalpha() or not last_name.isalpha():
        flash("First and Last name should only be characters")
    
    if len(password) <= 8:
        flash("Password should be more than 8")
    
    if not EMAIL_REGEX.match(email):
        flash("Emali is in invalid form")
    
    if password != confirm:
        flash("Password should match confirm")
    
    if (not any(x.isupper() for x in password)) or (not any(x.isdigit() for x in password)): 
        flash("One Upper and One Number at least")

    return redirect("/")
    
app.run(debug=True)