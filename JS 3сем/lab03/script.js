// Первое задание
// const arrays = [1, [1, 2, [3, 4]], [2, 4]];
// const result = arrays.reduce((a, b) => a.concat(Array.isArray(b) ? b.flat(Infinity) : b), []);
// console.log(result);

// второе задание
// const arrays = [1, [1, 2, [3, 4]], [2, 4]];
// const value = arrays.flat(Infinity).reduce((a, b) => a + b);
// console.log(value);

// третье задание
// function getArray(arrays) {
//     let ages = arrays.filter(student => student.age > 17);

//     let groupedStudents = ages.reduce((result, student) => {
//         if (!result[student.groupId]) {
//             result[student.groupId] = [];
//         }
//         result[student.groupId].push(student);
//         return result;
//     }, {});
    
//     return groupedStudents;
// }
// let students = [
//     { name: "John", age: 5, groupId: 8 },
//     { name: "Alex", age: 18, groupId: 5 },
//     { name: "Игорь", age: 20, groupId: 3 },
//     { name: "Алеша", age: 10, groupId: 2 }
// ];

// console.log(getArray(students));

let obj = { group:1, name:"Alex"}
obj.fio = "ggggg";
delete obj.fio;
for(const key in obj){
    if (key == "group"){
        obj[key] = 10;
    }
}
console.log(obj)


// четвертое задание
// function getUnicode(string, arr) {
//     for (let i = 0; i < string.length; i++) {
//         arr.push(string.charCodeAt(i));
//     }
//     return arr;
// }

// var arr = [];
// getUnicode("ABC", arr);

// let resultString = arr.join(""); 
// console.log(resultString);

// let total1 = resultString.split("");
// for (let i = 0; i < total1.length; i++) {
//     if (total1[i] == "7") {
//         total1[i] = "1";
//     }
// }
// let total2 = total1.join("");
// console.log(total2);
// let result = Number(resultString) - Number(total2);
// console.log(result);

// пятое задание
// function extend(...objects) {
//     return Object.assign({}, ...objects);
// }
// console.log(extend({a: 1, b: 2}, {c: 3})); 
// console.log(extend({a: 1, b: 2}, {c: 3}, {d: 4})); 
// console.log(extend({a: 1, b: 2}, {a: 3, c: 3})); 

// шестое задание
// function createPyramid(floors) {
//     for (let i = 0; i < floors; i++) {
//         console.log(' '.repeat(floors - i - 1) + '*'.repeat(2 * i + 1));
//     }
// }

// createPyramid(3);


