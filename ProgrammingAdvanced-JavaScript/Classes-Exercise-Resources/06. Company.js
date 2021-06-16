class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username,salary,position,department) {
        if ([username,salary,position,department].some(x => !x)) {
            throw new Error('Invalid input!');
        };

        if (salary <= 0 ) {
            throw new Error('Invalid input!');
        };

        let newEmployee = {
            username,
            salary,
            position,
        };

        if (!this.departments.some(x => x.name === department)) {

            let newDepartment = {
                name: department,
                employees: [],
                totalSalary: 0,
            };
            this.departments.push(newDepartment);
        }

        this.departments.forEach(x => {
            if (x.name === department) {
                x.employees.push(newEmployee);
                x.totalSalary += salary;
            }
        })
        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }
    bestDepartment() {
        let bestAvgSalary = 0;
        let bestDepartment = undefined;

        this.departments.forEach (x => {
            x.avgSalary = x.totalSalary / x.employees.length;

            if (x.avgSalary > bestAvgSalary) {
                bestAvgSalary = x.avgSalary;
                bestDepartment = x;
            }
        });

        let employeeList = bestDepartment.employees
        .sort(((a,b) => b.salary - a.salary) || a.username.localeCompare(b.username))
        .map(x => `${x.username} ${x.salary} ${x.position}`)
        .join('\n');

        return `Best Department is: ${bestDepartment.name}\nAverage salary: ${bestDepartment.avgSalary.toFixed(2)}\n${employeeList}`;
    }
}



let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());

