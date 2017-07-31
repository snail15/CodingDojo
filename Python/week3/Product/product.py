class Product(object):
    def __init__(self, price, name, weight, brand, cost):
        self.price = price
        self.name = name
        self.weight = weight
        self.brand = brand
        self.cost = cost
        self.status = "for Sale"

    def sell(self):
        self.status = "Sold"
        return self

    def addTax(self, rate):
        self.price = self.price * (1+rate)
        return self

    def returnItem(self, status):
        if status == "defective":
            self.status = "Defective"
            self.price = 0
        elif status == "box":
            self.status = "Like New"
        elif status == "opened":
            self.status = "for Sale"
            self.price = self.price * 0.8
        return self

    def displayInfo(self):
        print("Status:", self.status)
        print("Price:", self.price)
        print("Name:", self.name)
        print("Weight:", self.weight)
        print("Brand:", self.brand)
        print("Cost:", self.cost)

item1 = Product(100, "Car", 2000, "BMW", 50)
item1.sell().returnItem("opened").displayInfo()