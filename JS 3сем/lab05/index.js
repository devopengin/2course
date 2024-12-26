//первый пример кода
// function makeCounter(){
//     let currentCount = 1;
//     return function(){
//         return currentCount++;
//     };
// }

// let counter = makeCounter();
// alert(counter()); //1
// alert(counter()); //2
// alert(counter()); //3

// let counter2 = makeCounter();
// alert(counter2()); //1

//второй пример кода
let currentCount = 1;
function makeCounter(){
    return function(){
        return currentCount++;
    };
}

let counter = makeCounter();
let counter2 = makeCounter();

alert(counter()); //1
alert(counter()); //2

alert(counter2()); //3
alert(counter2()); //4

// // второе задание
function curriedFunction(a) {
    return function(b) {
        return function(c) {
            return a * b * c;
        };
    };
}

const fixedValue = curriedFunction(5);

const volume1 = fixedValue(2)(3);
const volume2 = fixedValue(4)(6);

console.log(volume1);
console.log(volume2);

// третье задание

function* moveObj() {
    let x = 0;
    let y = 0;

    while (true) {
        const way = prompt("Введите направление (left, right, up, down) или 'stop' для выхода:");
        const step = 10;

        if (way === 'stop') {
            console.log("Выход из программы.");
            return;
        }

        switch (way) {
            case "left":
                x -= step;
                break;
            case "right":
                x += step;
                break;
            case "up":
                y += step;
                break;
            case "down":
                y -= step;
                break;
            default:
                console.log("Ошибка");
                continue;
        }

        console.log(`Новые координаты: (${x}, ${y})`);
        yield { x, y };
    }
}

const tap = moveObj();
function step() {
    const result = tap.next();
    if (!result.done) { 
        step();
    }
}

step();



// четвертое задание
// var globalVar1 = 10;
// let globalVar2 = 20;
// const globalVar3 = 30;

// function globalFunc() {
//     console.log("Глобальная функция");
//     return 0;
// }

// console.log(window.globalVar1);
// console.log(window.globalFunc());

// console.log(window.globalVar2);
// console.log(window.globalVar3);

// window.globalVar1 = 100;
// console.log(globalVar1); // 100

// window.globalFunc = function() {
//     console.log("Глобальная функция переопределена");
// };
// globalFunc();


// let keysArray = [];
// for (let key in window) {
//     keysArray.push(key);
// }
// console.log(keysArray);

