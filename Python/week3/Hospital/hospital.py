class Patient(object):
    def __init__(self, id, name, allergies):
        self.id = id
        self.name = name
        self.allergies = allergies
        self.bedNumber = None

class Hospital(object):
    def __init__(self, name, capacity):
        self.patients = []
        self.name = name
        self.capacity = capacity

    def admit(self, patient, bedNumber):
        if len(self.patients) >= self.capacity:
            print("Capacity Full")
            return self
        else:
            patient.bedNumber = bedNumber
            self.patients.append(patient)
        print("Patient is admitted with bed number", bedNumber)
        return self

    def discharge(self, patient):
        for pat in self.patients:
            if patient.id == pat.id:
                pat.bedNumber = None
                self.patients.remove(pat)
                print("Patient is discharged with bed number", pat.bedNumber)
                return self



patient1 = Patient(1,"Sungin","None")
patient2 = Patient(2,"Sungin2","None2")
patient3 = Patient(3,"Sungin3","None3")
patient4 = Patient(4,"Sungin4","None4")

hospital = Hospital("Chicago Hospital", 3)
hospital.admit(patient1, 111)
hospital.admit(patient2, 222)
hospital.admit(patient3, 333)
hospital.admit(patient4, 444)

hospital.discharge(patient1)
for patient in hospital.patients:
    print(patient.name)







