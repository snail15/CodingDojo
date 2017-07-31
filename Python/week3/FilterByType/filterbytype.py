def filterbytpye(userVal):
    if type(userVal) == str:
        if len(userVal) >= 50:
            print("Long Sentence")
        else:
            print("Short Sentece")
    elif type(userVal) == int or type(userVal) == float:
        if userVal >= 100:
            print("That's a big number")
        else:
            print("That's a small number")
    elif type(userVal) == list:
        if len(userVal) >= 10:
            print("That's a big list")
        else:
            print("That's a small list")

sI = 45
mI = 100
bI = 455
eI = 0
spI = -23
sS = "Rubber baby buggy bumpers"
mS = "Experience is simply the name we give our mistakes"
bS = "Tell me and I forget. Teach me and I remember. Involve me and I learn."
eS = ""
aL = [1,7,4,21]
mL = [3,5,7,34,3,2,113,65,8,89]
lL = [4,34,22,68,9,13,3,5,7,9,2,12,45,923]
eL = []
spL = ['name','address','phone number','social security number']

filterbytpye(sI)
filterbytpye(mI)
filterbytpye(bI)
filterbytpye(eI)
filterbytpye(spI)
filterbytpye(sS)
filterbytpye(mS)
filterbytpye(bS)
filterbytpye(eS)
filterbytpye(aL)
filterbytpye(mL)
filterbytpye(lL)
filterbytpye(eL)
filterbytpye(spL)