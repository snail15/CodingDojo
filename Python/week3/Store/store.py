class Store(object):
    def __init__(self, products, address, owner):
        self.products = products
        self.address = address
        self.owner = owner

    def add_product(self, product):
        self.products.append(product)
        return self

    def remove_product(self, product):
        for i in range(len(self.products)):
            if self.products[i]["name"] == product:
                del(self.products[i])
                return self
        return self

    def inventory(self):
        print("Products:", self.products)
        print("Owner:", self.owner)

store1 = Store([{"name": "car", "price": 10000 }, {"name": "bike", "price": 100}], "Chicago", "Sungin Jung")

store1.inventory()
store1.add_product({"name": "train", "price": 1000000}).inventory()
store1.remove_product("car").inventory()
