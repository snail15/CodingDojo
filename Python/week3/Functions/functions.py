def oddoreven():
    for i in range(1, 2001):
        oddeven = ""
        if i % 2 == 0:
            oddeven = "even"
        else:
            oddeven = "odd"
        print("Number is {0}. This is {1} number.".format(i, oddeven))

oddoreven()

a = [2,4,10,16]
def muliply(lst, val):
    for i in range(len(lst)):
        lst[i] *= val
    return lst

print(muliply(a, 5))

def layered_mulitples(arr):
    newArr = []
    for i in range(len(arr)):
        inter = []
        for k in range(arr[i]):
            inter.append(1)
        newArr.append(inter)

    return newArr

print(layered_mulitples(muliply([2,4,5],3)))



