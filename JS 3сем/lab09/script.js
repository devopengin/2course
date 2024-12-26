// первое задание

const shape = {
    color: null,
    size: 12,
    getColor() {
      return this.color;
    },
    getSize() {
      return this.size;
    }
  };
  
const square = {
  __proto__ : shape
}
console.log(square.color)
  
  // const square = Object.create(shape);
  square.type = "Квадрат";
  console.log(square.size)
  
  const circle = Object.create(shape);
  circle.type = "Круг";

  const triangle = Object.create(shape);
  triangle.type = "Треугольник";
  triangle.lines = null;
  triangle.getLines = function() {
    return this.lines;
  };
  

  const largeYellowSquare = Object.create(square);
  largeYellowSquare.color = "желтый";
  largeYellowSquare.size = "большой";
  
  const smallYellowSquare = Object.create(square);
  smallYellowSquare.color = "желтый";
  smallYellowSquare.size = "маленький";
  
  const whiteCircle = Object.create(circle);
  whiteCircle.color = "белый";
  whiteCircle.size = "большой";
  
  const greenCircle = Object.create(circle);
  greenCircle.color = "зеленый";
  greenCircle.size = "большой";
  
  const triangleWithThreeLines = Object.create(triangle);
  triangleWithThreeLines.color = "белый";
  triangleWithThreeLines.size = "большой";
  triangleWithThreeLines.lines = 3;

  const triangleWithOneLine = Object.create(triangle);
  triangleWithOneLine.color = "белый";
  triangleWithOneLine.size = "большой";
  triangleWithOneLine.lines = 1;


  console.log(greenCircle.getColor());
  console.log(triangleWithThreeLines.getLines());
  console.log(smallYellowSquare.getSize());

  // второе задание

class Human {
    constructor(name, surname, birthYear, address) {
      this.name = name;
      this.surname = surname;
      this.birthYear = birthYear;
      this.address = address;
    }
  
    ChangeAddress(newAddress) {
      this.address = newAddress;
    }
  
    get age() {
      const currentYear = new Date().getFullYear();
      return currentYear - this.birthYear;
    }
  
    set age(newAge) {
      if (newAge < 0) {
        console.log("Ошибка, возраст не может быть меньше нуля");
      } else {
        const currentYear = new Date().getFullYear();
        this.birthYear = currentYear - newAge;
      }
    }
  }
  
  class Student extends Human {
    constructor(name, surname, birthYear, address, faculty, course, group, RecNumber) {
      super(name, surname, birthYear, address);
      this.faculty = faculty;
      this.course = course;
      this.group = group;
      this.RecNumber = RecNumber;
    }
  
    ChangeCourse(newCourse) {
      this.course = newCourse;
    }
  
    ChangeGroup(newGroup) {
      this.group = newGroup;
    }
  
    getFullName() {
      return `${this.name} ${this.surname}`;
    }
  
    CardNumber() {
      const NumberStr = this.RecNumber.toString();
      return {
        facultyCode: parseInt(NumberStr[0]),
        specialtyCode: parseInt(NumberStr[1]),
        admissionYear: parseInt('20' + NumberStr.slice(2, 4)),
        educationForm: parseInt(NumberStr[4]), 
        serialNumber: parseInt(NumberStr.slice(5))
      };
    }
  }
  
  // Класс Faculty
  class Faculty {
    constructor(faculty, groupCount, students) {
      this.faculty = faculty;
      this.groupCount = groupCount;
      this.students = students;
    }
  
    ChangeGroupCount(newGroupCount) {
      this.groupCount = newGroupCount;
    }
  
    ChangeStudentCount(newStudentsCount) {
      this.studentsCount = newStudentsCount;
    }
  
    getDev() {
      const devStudents = this.students.filter(
        (student) => student.CardNumber().specialtyCode === 3
      );
  
      console.log(`Количество студентов специальности ДЭВИ: ${devStudents.length}`);
      return devStudents;
    }
  
    getGroup(group) {
      const groupStudents = this.students.filter((student) => student.group === group);
      console.log(`Студенты группы ${group}:`);
      groupStudents.forEach((student) => console.log(student.getFullName()));
      return groupStudents;
    }
  }
  
  const student1 = new Student("Вася", "Пупкин", 2006, "Минск", "ФИТ", 2, 6, 7123100);
  const student2 = new Student("Иван", "Иванов", 2005, "Гродно", "ФИТ", 2, 6, 7123130);
  const student3 = new Student("Анна", "Сидорова", 2006, "Брест", "ФИТ", 2, 5, 7122230);
  const student4 = new Student("Пиип", "Пулал", 2006, "Боровляны", "ФИТ", 2, 10, 7322100);
  
  const fitFaculty = new Faculty("ФИТ", 10, [student1, student2, student3, student4]);
  
  console.log(fitFaculty.getDev());
  fitFaculty.getGroup(6);
  