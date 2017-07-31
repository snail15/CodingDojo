name = ["Anna", "Eli", "Pariece", "Brendan", "Amy", "Shane", "Oscar"]
favorite_animal = ["horse", "cat", "spider", "giraffe", "ticks", "dolphins", "llamas"]

def createDict(arr1, arr2):
    dict = {}
    for i in range(len(arr1)):
        dict[arr1[i]]= arr2[i]
    return dict

print(createDict(name, favorite_animal))