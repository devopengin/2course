document.addEventListener("DOMContentLoaded", () => {
    class Task {
        constructor(id, name, state) {
            this.id = id;
            this.name = name;
            this.state = state;
        }
        ChangeName(newName) {
            this.name = newName;
        }
        ChangeState(newState) {
            this.state = newState;
        }
        ToString() {
            return `Задача: id: ${this.id}, название: ${this.name}, статус: ${this.state ? "выполнено" : "не выполнено"}`;
        }
    }

    class ToDoList {
        constructor(idList, nameList) {
            this.idList = idList;
            this.nameList = nameList;
            this.ListOfTasks = [];
        }
        ChangeIdList(newIdList) {
            this.idList = newIdList;
        }
        ChangeNameList(newNameList) {
            this.nameList = newNameList;
        }
        AddNewTask(task) {
            this.ListOfTasks.push(task);
        }
        filterTaskByState(state) {
            return this.ListOfTasks.filter(task => task.state === state);
        }
        WriteAll() {
            return this.ListOfTasks.map(task => task.ToString()).join("\n");
        }
    }

    const todoList = new ToDoList(1, "Мой список задач");

    const taskInputField = document.getElementById("task-input");
    const addTaskButton = document.getElementById("add-task-btn");
    const taskListContainer = document.getElementById("task-list");
    const taskFilterButtons = {
        all: document.getElementById("filter-all"),
        completed: document.getElementById("filter-completed"),
        pending: document.getElementById("filter-pending"),
    };

    let taskIdCounter = 1;

    function displayTasks(filterMode = "all") {
        taskListContainer.innerHTML = "";
        const tasksToDisplay = todoList.ListOfTasks.filter(task => {
            if (filterMode === "completed") return task.state;
            if (filterMode === "pending") return !task.state;
            return true;
        });

        tasksToDisplay.forEach(task => {
            const taskElement = document.createElement("li");
            taskElement.className = `todo-item ${task.state ? "task-completed" : ""}`;

            const taskLabel = document.createElement("span");
            taskLabel.className = "todo-text";
            taskLabel.textContent = task.name;

            const statusCheckbox = document.createElement("input");
            statusCheckbox.type = "checkbox";
            statusCheckbox.checked = task.state;
            statusCheckbox.addEventListener("change", () => {
                task.ChangeState(!task.state);
                displayTasks(filterMode);
            });

            const modifyButton = document.createElement("button");
            modifyButton.className = "change";
            modifyButton.textContent = "Изменить";
            modifyButton.addEventListener("click", () => {
                const updatedText = prompt("Обновите задачу:", task.name);
                if (updatedText) {
                    task.ChangeName(updatedText);
                    displayTasks(filterMode);
                }
            });

            const removeButton = document.createElement("button");
            removeButton.className = "delete";
            removeButton.textContent = "Удалить";
            removeButton.addEventListener("click", () => {
                todoList.ListOfTasks = todoList.ListOfTasks.filter(t => t !== task);
                displayTasks(filterMode);
            });

            taskElement.appendChild(statusCheckbox);
            taskElement.appendChild(taskLabel);
            taskElement.appendChild(modifyButton);
            taskElement.appendChild(removeButton);
            taskListContainer.appendChild(taskElement);
        });
    }

    function addNewTask() {
        const taskText = taskInputField.value.trim();
        if (taskText) {
            const newTask = new Task(taskIdCounter++, taskText, false);
            todoList.AddNewTask(newTask);
            taskInputField.value = "";
            displayTasks();
        }
    }

    addTaskButton.addEventListener("click", addNewTask);
    taskInputField.addEventListener("keypress", (event) => {
        if (event.key === "Enter") addNewTask();
    });

    Object.entries(taskFilterButtons).forEach(([filterType, button]) => {
        button.addEventListener("click", () => displayTasks(filterType));
    });

    displayTasks();
});
