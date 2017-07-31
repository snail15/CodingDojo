def findAndReplace():
    words = "It's thanksgiving day. It's my birthday,too!"
    index = words.find("day")
    print(index)
    print(words.replace("day", "month"))
findAndReplace()

def findMinAndMax(list):
    print(min(list), max(list))

findMinAndMax([2,9,1,0])

def firstAndLast(list):
    print(list[-1])
    print(list[0])
    newList = []
    newList.append(list[-1])
    newList.append(list[0])
    print(newList)
firstAndLast([2,9,1,0])
x = [19,2,54,-2,7,12,98,32,10,-3,6]
def newList(list):
    newList = list.sort()
    medianIndex = int(len(list)/2)
    firstList= list[:medianIndex]
    secondList = list[medianIndex:]
    secondList[0] = firstList
    print(secondList)
newList(x)
