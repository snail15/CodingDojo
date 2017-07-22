var students = [ 
     {first_name:  'Michael', last_name : 'Jordan'},
     {first_name : 'John', last_name : 'Rosales'},
     {first_name : 'Mark', last_name : 'Guillen'},
     {first_name : 'KB', last_name : 'Tonel'}
]

function callName(students) {
   for (var student in students) {
       console.log(students[student].first_name+ " " + students[student].last_name);
   }
}

var users = {
 'Students': [ 
     {first_name:  'Michael', last_name : 'Jordan'},
     {first_name : 'John', last_name : 'Rosales'},
     {first_name : 'Mark', last_name : 'Guillen'},
     {first_name : 'KB', last_name : 'Tonel'}
  ],
 'Instructors': [
     {first_name : 'Michael', last_name : 'Choi'},
     {first_name : 'Martin', last_name : 'Puryear'}
  ]
 }

function callStudentsAndInstructors(obj) {
    console.log("Students");
    var num = 1;
    for (var i = 0; i < obj.Students.length; i++) {
        var lengthName = obj.Students[i].first_name.length + obj.Students[i].last_name.length;
        var firstName = obj.Students[i].first_name;
        var lastName = obj.Students[i].last_name;
        console.log(num + " - " + firstName + " " + lastName + " - " + lengthName);
        num++;
    }
    console.log("Instructors");
    num = 1;
     for (var i = 0; i < obj.Instructors.length; i++) {
        var lengthName = obj.Instructors[i].first_name.length + obj.Instructors[i].last_name.length;
        var firstName = obj.Instructors[i].first_name;
        var lastName = obj.Instructors[i].last_name;
        console.log(num + " - " + firstName + " " + lastName + " - " + lengthName);
        num++;
    }
    // for (var student in obj.Students) {
    //     var lengthName = obj.Students[student].first_name.length + obj.Students[student].last_name.length;
    //     var firstName = obj.Student[student].first_name;
    //     var lastName = obj.Students[student].last_name;
    //     console.log(num + " - " + firstName + " " + lastName + " - " + lengthName);
    //     num++;
    // }
}

callName(students);
callStudentsAndInstructors(users);