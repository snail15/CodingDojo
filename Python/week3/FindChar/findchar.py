def findChar(arr, letter):
    newLst = []
    for i in range(len(arr)):
        if arr[i].find(letter) != -1:
            newLst.append(arr[i])

    return newLst
word_list = ['hello','world','my','name','is','Anna']
char = 'o'

print(findChar(word_list, char))