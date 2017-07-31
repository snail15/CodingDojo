dict = {
    "name": "Sungin",
    "country of birth": "Korea",
    "age": 30,
    "favorite language": "Korean"
}
def printdict(dict):
    for key in dict:
        print("My {0} is {1}".format(key, dict[key]))

printdict(dict)