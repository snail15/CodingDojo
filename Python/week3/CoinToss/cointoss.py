import random
def cointoss(times):
    print("Starting program..")
    head = 0
    tail = 0
    for i in range(times):
        coin = ""
        side = random.randint(0,1)
        if side == 0:
            tail += 1
            coin = "tail"
        else:
            head += 1
            coin = "head"
        print("Attempt #{0}: Throwing..It's a {1}!!, so far we had {2} head(s) and {3} tail(s)".
              format(i+1, coin, head, tail))
    print("End of the program!")

cointoss(5000)