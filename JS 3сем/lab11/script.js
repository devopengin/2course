class Task {
    constructor(id, name, state){
        this.id = id;
        this.name = name;
        this.state = state;
    }
    ChangeName(newName){
        this.name = newName
    }
    ChangeState(newState){
        this.state = newState
    }
    ToString(){
        return `Задача : id : ${this.id}, название : ${this.name}, статус: ${this.state}`
    }
}

class ToDoList {
    constructor(idList,nameList){
        this.idList = idList;
        this.nameList = nameList;
        this.ListOfTasks = [];
    }
    ChangeIdList(newIdList){
        this.idList = newIdList;
    }
    ChangeNameList(newNameList){
        this.nameList = newNameList;
    }
    AddNewTask(task){
        this.ListOfTasks.push(task);
    }
    filterTaskByState(State){
        return this.ListOfTasks.filter(task => task.state == State)
    }
    WriteAll(){
        this.ListOfTasks.forEach(task => console.log(`ID списка: ${this.idList}, название списка: ${this.nameList}` + ", " + task.ToString()))
    }
}

const List1 = new ToDoList(1, "Список1");

const task1 = new Task(1, "Сделать лабы", false);
const task2 = new Task(2, "Сделать ужин", true);
const task3 = new Task(3, "Сделать курсач", false);

List1.AddNewTask(task1);
List1.AddNewTask(task2);
List1.AddNewTask(task3);


console.log("Список задач")
List1.WriteAll()

console.log("Выполненные задачи:");
const completedTasks = List1.filterTaskByState(true);
completedTasks.forEach(task => console.log(task.ToString()));
console.log();

List1.ChangeNameList("пппопппп")
task1.ChangeState(true);

console.log("Список задач")
List1.WriteAll()