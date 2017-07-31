class Bike(object):
    def __init__(self, name,price, max_speed, miles):
        self.name = name
        self.price = price
        self.max_speed = max_speed
        self.miles = miles

    def displayInfo(self):
        print("Name:", self.name)
        print("Price:", self.price)
        print("Max Speed:", self.max_speed)
        print("Miles:", self.miles)

    def ride(self):
        self.miles += 5
        return self

    def reverse(self):
        if (self.miles < 0):
            print("You can't have negative miles")
            return self
        else:
            self.miles -= 5
        return self

bike1 = Bike("bike1", 200, 15, 5)

bike1.ride().ride().ride().reverse().displayInfo()
