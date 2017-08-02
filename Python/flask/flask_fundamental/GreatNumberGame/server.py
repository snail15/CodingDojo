import random
from flask import Flask, redirect, request, render_template, session

app = Flask(__name__)
app.secret_key = "secretgame"

@app.route('/')
def index():
    try:
        print(session["high"], session["low"], session["right"])
        return render_template("index.html", high=session["high"], low=session["low"], right=session["right"])
    except:
        session["number"] = random.randrange(0,101)
        print("Target:", session["number"])
        return render_template("index.html")

@app.route('/guess', methods=["POST"])
def verify():
    print(session["number"])
    session["low"] = False
    session["high"] = False
    session["right"] = False
    guess = int(request.form["guess"])
    if guess < session["number"]:
        session["low"] = True
        session["high"] = False
    elif guess > session["number"]:
        session["high"] = True
        session["low"] = False
    elif guess == session["number"]:
        session["right"] = True
        session["low"] = False
        session["high"] = False
    return redirect("/")

@app.route('/reset')
def reset():
    session.pop("low")
    session.pop("high")
    session.pop("right")
    session.pop("number")
    return redirect("/")

app.run(debug=True)