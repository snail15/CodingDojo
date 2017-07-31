def multiplcation(num):
    print("*", end=" ")
    for i in range(1, num+1):
        print(i, end=" ")
    print("\n")

    for i in range(1, num+1):
        print(i, end=" ")
        for j in range(1, num+1):
            print(i*j, end=" ")
        print("\n")

multiplcation(12)