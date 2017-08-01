from flask import Flask, request, redirect, render_template

app = Flask(__name__)

@app.route('/')
def index():
   return render_template("index.html")

@app.route('/ninja')
def displayAll():
   return render_template("ninja.html")

@app.errorhandler(404)
def page_not_found(e):
    return render_template("error.html")

app.run(debug=True)