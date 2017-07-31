def draw_stars(arr):
    for number in arr:
        for i in range(number):
            print("*", end=" ")
        print("\n")

def draw_stars2(arr):
    for element in arr:
        if type(element) == str:
            for i in range(len(element)):
                print(element[0].lower(), end=" ")
        else:
            for i in range(element):
                print("*", end=" ")
        print("\n")

x = [4, 6, 1, 3, 5, 7, 25]
y = [4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"]
draw_stars(x)
draw_stars2(y)