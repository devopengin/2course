// 1 код
let user = {
  name: "Masha",
  age: 21,
};

// первое задание
let newUser = {
  ...user,
};
console.log(newUser);

// 2 код
let numbers = [1, 2, 3];

// первое задание
let newNumbers = [...numbers];
console.log(newNumbers);

// 3 код
let user1 = {
  name: "Masha",
  age: 23,
  location: {
    city: "Minsk",
    country: "Belarus",
  },
};
// первое задание
let newUser1 = {
  ...user1,
  location: {
    ...user1.location,
  },
};

console.log(newUser1);

// 4 код
let user2 = {
  name: "Masha",
  age: 28,
  skills: ["HTML", "CSS", "JavaScript", "React"],
};

// первое задание
let newUser2 = {
  ...user2,
  skills:[...user2.skills]
};
console.log(newUser2);

// 5 код
const array = [
  { id: 1, name: "Vasya", group: 10 },
  { id: 2, name: "Ivan", group: 11 },
  { id: 3, name: "Masha", group: 12 },
  { id: 4, name: "Petya", group: 10 },
  { id: 5, name: "Kira", group: 11 },
];
// первое задание
let newArray = array.map(element => ({...element}));
console.log(newArray);

// 6 код
let user4 = {
  name: "Masha",
  age: 19,
  studies: {
    university: "BSTU",
    speciality: "designer",
    year: 2020,
    exams: {
      maths: true,
      programming: false,
    },
  },
};
// первое задание
let newUser4 = {
  ...user4,
  studies: {
    ...user4.studies,
    exams: {
      ...user4.studies.exams,
    },
  },
};
console.log(newUser4);

// 7 код
let user5 = {
  name: "Masha",
  age: 22,
  studies: {
    university: "BSTU",
    speciality: "designer",
    year: 2020,
    department: {
      faculty: "FIT",
      group: 10,
    },
    exams: [
      { maths: true, mark: 8 },
      { programming: true, mark: 4 },
    ],
  },
};
// первое задание
let newUser5 = {
  ...user5,
  studies: {
    ...user5.studies,
    department: {
      ...user5.studies.department,
    },
    exams: [
        { ...user5.studies.exams[0] },
        { ...user5.studies.exams[1] }
    ],
  },
};

// второе задание
newUser5.studies.department.group = 12;
newUser5.studies.exams[1].mark = 10;
console.log(newUser5);

// 8 код
let user6 = {
  name: "Masha",
  age: 21,
  studies: {
    university: "BSTU",
    speciality: "designer",
    year: 2020,
    department: {
      faculty: "FIT",
      group: 10,
    },
    exams: [
      {
        maths: true,
        mark: 8,
        professor: {
          name: "Ivan Ivanov ",
          degree: "PhD",
        },
      },
      {
        programming: true,
        mark: 10,
        professor: {
          name: "Petr Petrov",
          degree: "PhD",
        },
      },
    ],
  },
};
// первое задание
let newUser6 = {
  ...user6,
  studies: {
    ...user6.studies,
    department: {
      ...user6.studies.department,
    },
    exams: [
      {
        ...user6.studies.exams[0],
        professor: { ...user6.studies.exams[0].professor },
      },
      {
        ...user6.studies.exams[1],
        professor: { ...user6.studies.exams[1].professor },
      },
    ],
  },
};

// третье задание
newUser6.studies.exams[0].professor.name = "Професор Профч";
console.log(newUser6);

// 9 код
let user7 = {
  name: "Masha",
  age: 20,
  studies: {
    university: "BSTU",
    speciality: "designer",
    year: 2020,
    department: {
      faculty: "FIT",
      group: 10,
    },
    exams: [
      {
        maths: true,
        mark: 8,
        professor: {
          name: "Ivan Petrov",
          degree: "PhD",
          articles: [
            { title: "About HTML", pagesNumber: 3 },
            { title: "About CSS", pagesNumber: 5 },
            { title: "About JavaScript", pagesNumber: 1 },
          ],
        },
      },
      {
        programming: true,
        mark: 10,
        professor: {
          name: "Petr Ivanov",
          degree: "PhD",
          articles: [
            { title: "About HTML", pagesNumber: 3 },
            { title: "About CSS", pagesNumber: 5 },
            { title: "About JavaScript", pagesNumber: 1 },
          ],
        },
      },
    ],
  },
};
// первое задание
let newUser7 = {
    ...user7,
    studies: {
      ...user7.studies,
      department: {
        ...user7.studies.department,
      },
      exams: [
        {
          ...user7.studies.exams[0],
          professor: {
            ...user7.studies.exams[0].professor,
            articles: [
              { ...user7.studies.exams[0].professor.articles[0] },
              { ...user7.studies.exams[0].professor.articles[1] },
              { ...user7.studies.exams[0].professor.articles[2] },
            ],
          },
        },
        {
          ...user7.studies.exams[1],
          professor: {
            ...user7.studies.exams[1].professor,
            articles: [
              { ...user7.studies.exams[1].professor.articles[0] },
              { ...user7.studies.exams[1].professor.articles[1] },
              { ...user7.studies.exams[1].professor.articles[2] },
            ],
          },
        },
      ],
    },
  };
  
  // четвертое задание
  newUser7.studies.exams[1].professor.articles[1].pagesNumber = 3;
  console.log(newUser7);
  

// 10 код
let store = {
  state: {
    profilePage: {
      posts: [
        { id: 1, message: "Hi", likesCount: 12 },
        { id: 2, message: "By", likesCount: 1 },
      ],
      newPostText: "About me",
    },
    dialogsPage: {
      dialogs: [
        { id: 1, name: "Valera" },
        { id: 2, name: "Andrey" },
        { id: 3, name: "Sasha" },
        { id: 4, name: "Viktor" },
      ],
      messages: [
        { id: 1, message: "hi" },
        { id: 2, message: "hi hi" },
        { id: 3, message: "hi hi hi" },
      ],
    },
    sidebar: [],
  },
};

// первое задание
let newStore = {
  ...store,
  state: {
    ...store.state,
    profilePage: {
      ...store.state.profilePage,
      posts: [
        { ...store.state.profilePage.posts[0] },
        { ...store.state.profilePage.posts[1] },
      ],
    },
    dialogsPage: {
      ...store.state.dialogsPage,
      dialogs: [
        { ...store.state.dialogsPage.dialogs[0] },
        { ...store.state.dialogsPage.dialogs[1] },
        { ...store.state.dialogsPage.dialogs[2] },
        { ...store.state.dialogsPage.dialogs[3] },
      ],
      messages: [
        { ...store.state.dialogsPage.messages[0] },
        { ...store.state.dialogsPage.messages[1] },
        { ...store.state.dialogsPage.messages[2] },
      ],
    },
    sidebar: [...store.state.sidebar],
  },
};

// пятое задание
// newStore.state.profilePage.posts[0].message = "Hello";
// newStore.state.profilePage.posts[1].message = "Hello";
newStore.state.profilePage.posts.map(elem => elem.message = "Hello")
newStore.state.dialogsPage.messages.map(el => el.message = "Hello")
// newStore.state.dialogsPage.messages[0].message = "Hello";
// newStore.state.dialogsPage.messages[1].message = "Hello";
// newStore.state.dialogsPage.messages[2].message = "Hello";
console.log(newStore);