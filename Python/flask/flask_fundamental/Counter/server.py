from flask import Flask, session, redirect, render_template

app = Flask(__name__)
app.secret_key = "counterSecret"

@app.route('/')
def index():
    count = 0
    try:
        if session["count"] >= 1:
            session["count"] += 1
        else:
            session["count"] = 1
    except:
        count += 1
        session['count'] = count

    time = "time"
    if session['count'] > 1:
        time = "times"
        
    return render_template("index.html", view=session['count'], time=time)

@app.route('/plustwo')
def add_two():
    session['count'] += 1
    return redirect("/")

@app.route('/reset')
def reset_count():
   session['count'] = 0
   return redirect("/")

app.run(debug=True)