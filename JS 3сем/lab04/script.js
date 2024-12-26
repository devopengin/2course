// // первое задание

// let products = new Set(["Яблоки", "Огурцы"]);

// function addProduct(name) {
//   if (products.has(name)) {
//     console.log("Такой продукт уже есть");
//   }
//   products.add(name);
// }

// function deleteProduct(name){
//     if(products.has(name)){
//         products.delete(name)
//     }
//     else{
//         console.log("Такого продукта нет в корзине")
//     }
// }

// function checkProduct(name){
//     if(products.has(name)){
//         console.log("Такой продукт находится в вашей корзине");
//     }
//     else{
//         console.log("Такого продукта нет в вашей корзине");
//     }
// }

// function getCount(products){
//     console.log("Количество товаров в корзине: ", products.size)
// }

// addProduct("машина")
// deleteProduct("машина")
// checkProduct("папа")
// getCount(products)
// console.log(products)

// //второе задание
let students = new Set([
     { id:1 , group:6 , name:"Васечкин Вася Васильевич"},
     { id:2 , group:7 , name:"Васечкин Вася Васильевич"}
]);

function addStudent(id, group, name ){
    for (let student of students) {
        if (student.id === id) {
            console.log(`Студент с номером зачетки ${id} уже существует.`);
            return;
        }
    }

    const student = {id, group, name};
    students.add(student);
    console.log(`Студент ${name} добавлен.`);
}

function deleteStudent(number) {
    let flag = false;

    for (let value of students) {
        if (value.id === number) {
            students.delete(value);
            console.log(`Студент с номером зачетки ${number} удален.`);
            flag = true;
            break;
        }
    }

    if (!flag) {
        console.log(`Студент с номером зачетки ${number} не найден.`);
    }
}

function sortByGroup(group){
    console.log("Результат фильтрации: ");
    for (let student of students) {
        if (student.group === group) {
            console.log(`Студент ${student.name} c номером зачетки ${student.id}` )
        }
    }

}

function sortByNumber() {
    const studentsArray = [...students];

    studentsArray.sort((a,b) => a.id - b.id);

    console.log("Результат сортировки: ");
    for (let student of studentsArray) {
        console.log(`Номер зачетки: ${student.id}, Группа: ${student.group}, ФИО: ${student.name}`);
    }

    return studentsArray;
}
addStudent(3, 6, "ипи")
addStudent(4, 6, "ипggи")
addStudent(5, 2, "ипhhhи")
deleteStudent(1);
sortByGroup(6);
sortByNumber()
console.log(students)

// // третье задание
// let map = new Map([[1, { name: "Ручка", amount: 3, price: 240 }]]);

// map.set(2, { name: "Стерка", amount: 2, price: 267 });
// map.set(7, { name: "Ластик", amount: 2, price: 207 });

// function addItem(id, name, amount, price) {
//   if (map.has(id)) {
//     console.log("Ошибка, элемент с таким id уже существует");
//     return;
//   }
//   map.set(id, { name: name, amount: amount, price: price });
// }

// function deleteItembyID(id) {
//   if (map.has(id)) {
//     map.delete(id);
//   } else {
//     console.log(`Элемента с id ${id} не существует`);
//   }
// }

// function deleteByName(name) {
//   let found = false;
//   for (let [id, product] of map) {
//     if (product.name === name) {
//       map.delete(id);
//       found = true;
//       console.log(`Товар ${name} с id ${id} удален из корзины.`);
//     }
//   }
//   if (!found) {
//     console.log("Такого товара нет в корзине");
//   }
// }

// function changeAmount(amount, id) {
//     if (map.has(id)) {
//         let product = map.get(id); // Получаем продукт по id
//         product.amount = amount; // Изменяем количество
//         console.log(`Количество товара с id ${id} изменено на ${amount}`);
//     } else {
//         console.log("Ошибка: Элемент с таким id не существует");
//     }
// }


// function changePrice(id, price) {
//     if (map.has(id)) {
//         let product = map.get(id); // Получаем продукт по id
//         product.price = price; // Изменяем цену
//         console.log(`Цена товара с id ${id} изменена на ${price}`);
//     } else {
//         console.log("Ошибка: Элемент с таким id не существует");
//     }
// }

// // функция для подсчета общего количества позиций
// function getTotalItems() {
//     let totalItems = 0;
//     for (let product of map.values()) {
//         totalItems += product.amount; 
//     }
//     return totalItems;
// }

// // функция для расчета общей стоимости
// function getTotalCost() {
//     let totalCost = 0;
//     for (let product of map.values()) {
//         totalCost += product.amount * product.price;
//     }
//     return totalCost;
// }


// addItem(3, "ножка", 4, 780);
// // deleteItembyID(3);
// deleteByName("Ручка");
// changeAmount(4, 7);
// changePrice(3, 1000);

// console.log(`Общее количество позиций: ${getTotalItems()}`);
// console.log(`Общая стоимость всех товаров: ${getTotalCost()} руб.`);

// for (let product of map.values()) {
//   console.log(product);
// }


// четвертое задание
const cache = new WeakMap();

function cached(obj) {
    if (cache.has(obj)) {
        console.log("Данные взяты из кэша.");
        return cache.get(obj); 
    }
    

    const result = Math.sqrt(obj.value);
    
    cache.set(obj, result);
    
    console.log("Вычисление выполнено.");
    return result;
}

let obj1 = { value: 16 };
let obj2 = { value: 25 };

console.log(cached(obj1)); // 4
console.log(cached(obj1)); // 4

console.log(cached(obj2)); // 5
console.log(cached(obj2)); // 5
