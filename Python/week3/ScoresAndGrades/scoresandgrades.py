import random
def scoresandgrades(times):
    print("Scores and Grades")
    for i in range(times):
        randomScore = random.randint(60, 100)
        grade = ""
        if randomScore >= 90:
            grade = "A"
        elif randomScore >= 80:
            grade = "B"
        elif randomScore >= 70:
            grade = "C"
        else:
            grade = "D"
        print("Score is: {0}. Your grade is {1}".format(randomScore, grade))
    print("End of the program, Bye!")

scoresandgrades(10)