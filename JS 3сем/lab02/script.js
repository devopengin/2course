//первое задание
// let result
// function basicOperation(operation, value1, value2) {
//     const operations = {
//         '+': (a, b) => a + b,
//         '-': (a, b) => a - b,
//         '*': (a, b) => a * b,
//         '/': (a, b) => a / b
//     };
//     return operations[operation](value1, value2);
// }
// result = basicOperation('+', 5, 10); // result = 15
// console.log(result)

// let func1 = function basic(operation, value1, value2){
//     const operations1 = {
//         '+': (a, b) => a + b,
//         '-': (a, b) => a - b,
//         '*': (a, b) => a * b,
//         '/': (a, b) => a / b
//     };
//     return operations[operation](value1, value2);
// };

//второе задание
function getCube(n) {
  let result = 0;
  for (let i = 1; i <= n; i++) {
    result += i ** 3;
  }
  return result;
}
let n = prompt("Введите n");
console.log(getCube(n));

//третье задание
function getArray(array) {
  let result = 0;
  array.forEach((element) => {
    result += element;
  });
  return result / array.length;
}
let array = [1, 2, 3, 4];
console.log(getArray(array));

//четвертое задание
function getWord(str){
    let stringwithoutEng = str.replace(/[^a-zA-Z]/g, '');
    let splitString = stringwithoutEng.split("");
    let reverseString = splitString.reverse();
    return reverseString.join("");
}
let word = "JavaScriptП"
console.log(getWord(word))

//пятое задание
function repeatString(n, str)
{
    let i=0;
    let result = '';
    while (i<n)
    {
        result+=str
        i++;
    }
    return result;
}

let func2 = (a,b) =>{
return a+b;
}
a=2;
b=3;
console.log(func2(a,b))

// console.log(repeatString(3,"ggg"))

//шестое задание
// function returnArray(arr1, arr2){
//     arr3 = arr1.filter(item => !arr2.includes(item));
//     return arr3;
// }
// const arr1 = ["чай", "машина", "клюква", "аристотель"];
// const arr2 = ["машина", "клюква"];

// console.log(returnArray(arr1, arr2));
