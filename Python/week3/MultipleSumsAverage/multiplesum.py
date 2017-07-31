def multiptest1():
    for i in range(1,1001):
        if i % 2 != 0:
            print (i)

def multiptest2():
    for i in range(5,1000001):
        if i % 5 == 0:
            print(i)
a = [1, 2, 5, 10, 255, 3]
def sum(lst):
    sum = 0
    for i in range(len(lst)):
        sum += lst[i]
    print(sum)

def average(lst):
    sum = 0
    for i in range(len(lst)):
        sum += lst[i]
    print(sum/len(lst))


multiptest1()
multiptest2()
sum(a)
average(a)