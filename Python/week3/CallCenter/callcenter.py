class Call(object):
    def __init__(self, id, name, number, time, reason):
        self.id = id
        self.name = name
        self.number = number
        self.time = time
        self.reason = reason

    def display(self):
        print(self.id, self.name, self.number, self.time, self.reason)


class CallCenter(object):
    def __init__(self, calls):
        self.calls = calls
        self.size = len(calls)

    def addCall(self, call):
        self.calls.append(call)
        self.size = len(self.calls)
        return self

    def removeCall(self, number):
        for call in self.calls:
            if number in call.number:
                self.calls.remove(call)
        self.size = len(self.calls)
        return self

    def info(self):
        for call in self.calls:
            print(call.name, call.number)
        print("Queue:", self.size)


call1 = Call(1, "Sungin", "917-678-4779", "10:12", "refund")
call2 = Call(2, "Sun", "917-692-5736", "10:44", "refund2")
callList = [call1, call2]

center = CallCenter(callList)
center.info()
center.addCall(Call(3,"Yo","123-456-7890","11:23","refund3"))
center.removeCall("917-678-4779").info()