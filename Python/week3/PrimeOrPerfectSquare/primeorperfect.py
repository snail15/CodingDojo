def primeorperfect():
    for i in range(100, 100001):
        prime = True
        perfect = False
        for k in range(2, i):
            if i % k == 0:
                prime = False
            if k * k == i:
                perfect = True
        if prime:
            print (i,": Boo")
        if perfect:
            print(i,": Foo")
        if prime == False and perfect == False:
            print(i,": FooBar")
primeorperfect()