def drawCheckboard(row):
    for i in range(1, row+1):
        if i % 2 != 0:
            print("* * * *")
        else:
            print(" * * * *")

drawCheckboard(8)
print("-------------")
drawCheckboard(1)
print("-------------")
drawCheckboard(3)