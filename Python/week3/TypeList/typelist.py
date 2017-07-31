def typelist(userList):
    sum = 0
    strType = False
    intType = False
    stringMessage = "String: "
    sumMessage = "Sum:"

    for i in range(len(userList)):
        if type(userList[i]) == int or type(userList[i]) == float:
            sum += userList[i]
            intType = True
        elif type(userList[i]) == str:
            stringMessage += userList[i] + " "
            strType = True

    if strType == True and intType == True:
        typeMessage = "The list you entered is of {0} type".format("mixed")
        print(typeMessage)
        print(stringMessage)
        print(sumMessage, sum)
    elif intType == True and strType == False:
        typeMessage = "The list you entered is of {0} type".format("integer")
        print(typeMessage)
        print(sumMessage, sum)
    else:
        typeMessage = "The list you entered is of {0} type".format("string")
        print(typeMessage)
        print(stringMessage)

l1 = ['magical unicorns',19,'hello',98.98,'world']
l2 = [2,3,1,7,4,12]
l3 = ['magical','unicorns']

typelist(l1)
typelist(l2)
typelist(l3)





