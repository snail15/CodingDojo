def compareArrays(userList1, userList2):
    if len(userList1) != len(userList2):
        return print("Not the Same")
    else:
        userList1.sort()
        userList2.sort()
        for i in range(len(userList1)):
            if userList1[i] != userList2[i]:
                return print("Not the Same")

    return print("The Same!")

list_one = [1,2,5,6,2]
list_two = [1,2,5,6,2]

list_one_1 = [1,2,5,6,5]
list_two_1 = [1,2,5,6,5,3]

list_one_2 = [1,2,5,6,5,16]
list_two_2 = [1,2,5,6,5]

str_list_one = ['celery','carrots','bread','milk']
str_list_two = ['celery','carrots','bread','cream']

compareArrays(list_one,list_two)
compareArrays(list_one_1,list_two_1)
compareArrays(list_one_2,list_two_2)
compareArrays(str_list_one,str_list_two)