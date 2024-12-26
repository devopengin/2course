// первое задание
// let a = 5;
// let name = "Name";
// let i = 0;
// let double = 0.23;
// let result = 1/0;
// let answer = true;
// let no = null;
// console.log(typeof(a));
// console.log(typeof(name));
// console.log(typeof(i));
// console.log(typeof(double));
// console.log(typeof(result));
// console.log(typeof(answer));
// console.log(typeof(no));

// второе задание
let squareA = 45*21;
let squareB = 5*5;
let amount = squareA/squareB;
console.log(Math.floor(amount));

// Третье задание
// let ih = 2;
// let ah = ++ih;
// let bh = ih++;
// if (ah>bh) {
//     console.log("a>b")
// } else if(ah<bh){
//     console.log("a<b")
// }
// else{
//     console.log("a=b")
// }

// Четвертое задание
// ("Котик" > "котик") ? console.log("true") : console.log("false");
// ("Котик" > "китик") ? console.log("true") : console.log("false");
// ("Кот" > "котик") ? console.log("true") : console.log("false");
// ("Привет" > "Пока") ? console.log("true") : console.log("false");
// (73 > "53") ? console.log("true") : console.log("false");
// (false > 0.54) ? console.log("true") : console.log("false");
// (0.54 > true) ? console.log("true") : console.log("false");
// (123 > false) ? console.log("true") : console.log("false");
// (true > "3") ? console.log("true") : console.log("false");
// (3 > "5мм") ? console.log("true") : console.log("false");
// (8 > "-2") ? console.log("true") : console.log("false");
// (34 > "34") ? console.log("true") : console.log("false");
// (null > undefined) ? console.log("true") : console.log("false");

// пятое задание
// let name_student = prompt("Введите имя")
// const name_t = 'Марина';
// const name_surname = "марина кудлацкая"
// const name_teacher = "кудлацкая марина федоровна"
// if(name_student.toLowerCase == (name_t || name_surname || name_teacher).toLowerCase)
// {
//     alert("Введенные пользователем данные верны")
// }
// else{
//     alert("Введенные пользователем данные неверны")
// }

// шестое задание
// let mat = prompt("Ты сдал математику? (1 - да, 0 - нет)")
// let rus = prompt("Ты сдал русский? (1 - да, 0 - нет)")
// let engl = prompt("Ты сдал английский? (1 - да, 0 - нет)")
// let sum = parseInt(mat)+parseInt(rus)+parseInt(engl)
// if (sum == 3)
// {
//     console.log("Студент перешел на следующий курс")
// }
// else if(sum < 1 && sum >= 0)
// {
//     console.log("Студент отчислился")
// }
// else{
//     console.log("Студента ждет пересдача")
// }

// седьмое задание
// console.log(true+true)
// console.log(0 + "5")
// console.log(5 + "мм")
// console.log(8/Infinity)
// console.log(9 * "\n9")
// console.log(null - 1)
// console.log("5" - 2)
// console.log("5px" - 3)
// console.log(true - 3)
// console.log(7||0)

// восьмое задание
// let i = 0;
// let numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

// for (i = 0; i < numbers.length; i++) {
//     if (numbers[i] % 2 == 0) {
//         numbers[i] += 2;
//         console.log(numbers[i]);
//     } else {
//         console.log(numbers[i] + " mm");
//     }
// }

// девятое задание
// объект
// var obj = {
//     1:"понедельник",
//     2:"вторник",
//     3:"среда",
//     4:"четверг",
//     5:"пятница",
//     6:"суббота",
//     7:"воскресенье"
// };
// let x = prompt("Введите номер дня недели")
// console.log("Сегодня"+ " " + obj[x])

// // массив
// let days = ["понедельник", "вторник", "среда", "четверг", "пятница", "суббота", "воскресенье"]
// let x = prompt("Введите номер дня недели")
// console.log("Сегодня" + " " + days[--x])

// десятое задание
// let x = prompt("Введите слово");
// let say = "люблю"
// function writeWord(second, third,from = "жизнь"){
// return(from+second+third);
// }

function createString(first = "жизнь", second, third) {
    return `${third} ${second} ${first}`;
}

// Запрос значения у пользователя для третьего параметра
const x = prompt("Введите значение для третьего параметра:");
const result = createString(undefined, "люблю", x);

console.log(result);
// console.log(writeWord(x, say))

//одиннадцатое задание
// let a = prompt("Введите длину a");
// let b = prompt("Введите длину b");
//                         //  Function Declaration
// function params(a,b){
//     if (a==b){
//         return (a*4)
//     }
//     else
//     {
//         return (a*b)
//     }
// }
// alert(params(a,b))

//                         // Function Expression
// let params = function(a,b){
//     if (a==b){
//         return(a*4)
//     }
//     else{
//         return(a*b)
//     }
// };
// alert(params(a,b))

//                         //  стрелочная
// let params = (a, b) => {
//   if (a == b) {
//     return a * 4;
//   } 
//     return a * b;
  
// };
// alert(params(a,b))
