from flask import Flask, render_template, redirect, session, request
import random

app = Flask(__name__)
app.secret_key = "ninjasecret"

@app.route('/')
def index():
    return render_template("index.html")


@app.route('/process_money', methods=["POST"])
def process_money():
    building = request.form["building"]
    if building == "farm":
        gold = random.randrange(10, 21)
    elif building == "cave":
        gold = random.randrange(5, 11)
    elif building == "house":
        gold = random.randrange(2,6)
    else:
        gold = random.randrange(-50, 51)
    
    if building != "casino":
        activity_message= "You entered " + building.title() + " and earned " + str(gold) + " golds!\n"
    else:
        if gold < 0:
            activity_message= "You entered " + building.title() + " and lost " + str(abs(gold)) + " golds.....Sorry\n"
        else:
            activity_message= "You entered " + building.title() + " and earned " + str(gold) + " golds!\n"
    try:
        session["gold"] += gold
        session["activity"] += activity_message
        print(activity_message)
    except:
        session["gold"] = gold
        session["activity"] = activity_message

    return redirect("/")

app.run(debug=True)