from flask import Flask, request, render_template, redirect, flash, session

app = Flask(__name__)
app.secret_key = "validation"

@app.route('/')
def index():
   return render_template("index.html")

@app.route('/result', methods=["POST"])
def result():
    
    error = 0
    name = request.form["name"]
    location = request.form["location"]
    language = request.form["language"]
    comment = request.form["comment"]
    if len(name) < 1:
        flash("Name is empty!")
        error += 1
    if len(comment) < 1:
        flash("Actually, comment ain't optional")
        error += 1
    if len(comment) > 120:
        flash("Comment too long")
        error += 1
    if error > 0:
        return redirect("/")

    return render_template("result.html", name=name, location=location, language=language, comment=comment)

app.run(debug=True)