class Car(object):

    def __init__(self, price, speed, fuel, mileage):
        if price > 10000:
            self.tax = 0.15
        else:
            self.tax = 0.12
        self.price = price
        self.speed = speed
        self.fuel = fuel
        self.mileage = mileage
        self.displayAll()

    def displayAll(self):
        print("Price:",self.price)
        print("Speed",self.speed)
        print("Fuel:",self.fuel)
        print("Mileage:",self.mileage)
        print("Tax:",self.tax)

car1 = Car(900, 200, "Full", 20000,)
car2 = Car(222222, 200, "Empty", 12312)