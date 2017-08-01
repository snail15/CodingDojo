class Animal(object):
    def __init__(self, name):
        self.name = name
        self.health = 50

    def walk(self):
        self.health -= 1
        return self

    def run(self):
        self.health -= 5
        return self

    def display_health(self):
        print("Health:", self.health)

class Dog(Animal):
    def __init__(self, name):
        super(Dog, self).__init__(name)
        self.health = 150
    def pet(self):
        self.health += 5
        return self

dog = Dog("Haru")
dog.walk().walk().walk().run().run().pet().display_health()

class Dragon(Animal):
    def __init__(self, name):
        super(Dragon, self).__init__(name)
        self.health = 170

    def fly(self):
        self.health -= 10
        return self

    def display_health(self):
        super(Dragon, self).display_health()
        print("I am a Dragon")

dragon = Dragon("Miru")
dragon.fly().display_health()

animal = Animal("Miru")
animal.fly()