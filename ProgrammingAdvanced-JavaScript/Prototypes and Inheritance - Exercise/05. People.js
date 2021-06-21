function solve() {
    const Tasks = {
        JUNIOR: [" is working on a simple task."],
        SENIOR: [" is working on a complicated task.",
            " is taking time off work.",
            " is supervising junior workers."
        ],
        MANAGER: [" scheduled a meeting.",
            " is preparing a quarterly report."
        ]
    }
    class Employee {
        constructor(name, age , tasks) {
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = tasks;
            this._index = 0;
        }
      
        work() {
            if (this._index === this.tasks.length) {
                this._index = 0;
            }
            console.log(this.name + this.tasks[this._index]);
            this._index++;
        };

        collectSalary() {
            console.log(`${this.name} received ${this.salary} this month.`);
        }
    };
    class Junior extends Employee {
        constructor(name ,age) {
            super(name,age,Tasks.JUNIOR);
        }
    }
    class Senior extends Employee {
        constructor(name ,age) {
            super(name,age,Tasks.SENIOR);
        }
    }
    class Manager extends Employee {
        constructor(name ,age) {
            super(name,age,Tasks.MANAGER);
            this.dividend = 0;
        }
        collectSalary() {
            console.log(`${this.name} received ${this.salary + this.dividend} this month.`);
        }
    }

    return { Employee, Junior, Senior, Manager };
}
const module = solution();
const junior = new module.Junior('Ivan', 25);

junior.work();
junior.work();

junior.salary = 5811;
junior.collectSalary();

const sinior = new module.Senior('Alex', 31);

sinior.work();
sinior.work();
sinior.work();
sinior.work();

sinior.salary = 12050;
sinior.collectSalary();

const manager = new module.Manager('Tom', 55);

manager.salary = 15000;
manager.collectSalary();
manager.dividend = 2500;
manager.collectSalary();
