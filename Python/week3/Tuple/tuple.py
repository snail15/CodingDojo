my_dict = {
  "Speros": "(555) 555-5555",
  "Michael": "(999) 999-9999",
  "Jay": "(777) 777-7777"
}

def makeTuple(dict):
    newArr = []
    for key in dict:
        tup = (key, dict[key])
        newArr.append(tup)
    print(newArr)

makeTuple(my_dict)