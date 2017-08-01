class MathDojo(object):
    def __init__(self):
        self.result = 0

    def add(self, *args):
        for arg in args:
            if type(arg) == list or type(arg) == tuple:
                for i in range(len(arg)):
                    self.result += arg[i]
            else:
                self.result += arg
        return self

    def subtract(self, *args):
        for arg in args:
            if type(arg) == list or type(arg) == tuple:
                for i in range(len(arg)):
                    self.result -= arg[i]
            else:
                self.result -= arg
        return self

dojo = MathDojo()
print(dojo.add([1],3,4).add((3, 5, 7, 8), [2, 4.3, 1.25]).subtract(2, [2,3], [1.1, 2.3]).result)
x = 1+3+4+3+5+7+8+2+4.3+1.25-2-2-3-1.1-2.3
print(x)