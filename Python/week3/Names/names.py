students = [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
]
def name1(arr):
    for dict in arr:
        for key in dict:
            print(dict[key], end=" ")
        print("\n")

name1(students)

users = {
 'Students': [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
  ],
 'Instructors': [
     {'first_name' : 'Michael', 'last_name' : 'Choi'},
     {'first_name' : 'Martin', 'last_name' : 'Puryear'}
  ]
 }


def name2(dicts):
    for key in dicts:
        num = 1
        print(key)
        for dict in dicts[key]:
            print(num, "-", dict["first_name"], dict["last_name"], "-", len(dict["first_name"])+len(dict["last_name"]))
            num += 1

name2(users)