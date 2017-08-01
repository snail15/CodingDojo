from flask import Flask, render_template, request

app = Flask(__name__)

@app.route('/')
def index():
   return render_template("index.html")

@app.route('/ninjas')
def ninjas():
   return render_template("ninjas.html")

@app.route('/dojo/new', methods=["POST"])
def new_ninja():
    if request.method == 'POST':
        name = request.form['name']
        email = request.form['email']
        print(name, email)
    return render_template("dojo.html")

app.run(debug=True)