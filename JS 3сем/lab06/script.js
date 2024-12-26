// Первое задание
let numbers = [1,2,3,4,5,6,7,8,9,0];
let [, second, ...next] = numbers;

console.log(firstNumber)
console.log(next[next.length-1])

// второе задание
let user = {
    name: "Максим",
    age:"19"
}

let admin = {
    admin: null,
    ...user
}
console.log(admin);

// третье задание

let store = { 
    state: { 
        profilePage: { 
            posts: [
                {id:1, message:'Hi', likesCount:12},
                {id:2, message:'By', likesCount:1},
            ],
            newPostText: 'About me',
        },
        dialogsPage: {
            dialogs: [
                {id: 1, name: 'Valera'},
                {id: 2, name: 'Andrey'},
                {id: 3, name: 'Sasha'},
                {id: 4, name: 'Viktor'},
            ],
            messages: [
                {id: 1, message: 'hi'},
                {id: 2, message: 'hi hi'},
                {id: 3, message: 'hi hi hi'},
            ],
        },
        sidebar: [],
    }
}

let {
    state:{
        profilePage:{
            posts,
            newPostText
        },
        dialogsPage:{
            dialogs,
            messages
        }
    }

} = store;



let m = {
    name:"nnn",
    age:12,
    adress : {
number:4,
name_str:"34343"
    },
    max:[4,5,7]
}

let {
    name,
    age,
    adress:{
number,
name_str
    },
    max
} = m

console.log(max[2])
posts.forEach(element => {
    return console.log(element.likesCount)
});


let filterPeoples = dialogs.filter(dialog => {
    return dialog.id % 2 == 0;
});

console.log(filterPeoples);

for (let message of messages){
    message.message = "Hello user"
    console.log(message)
}

// четвертое задание

let tasks = [
    {id:1, title:"HTML&CSS", isDone:true},
    {id:2, title:"JS", isDone:true},
    {id:3, title:"ReactJS", isDone:false},
    {id:4, title:"Rest API", isDone:false},
    {id:5, title:"GraphQL", isDone:false},
];

let newTask = {id:6, title:"XML", isDone:true}

let newTasks = [...tasks, newTask];

console.log(newTasks)

// // пятое задание
let arr = [1,2,3];

function sumValues(x,y,z){
    return x+y+z;
}

console.log(sumValues(...arr))