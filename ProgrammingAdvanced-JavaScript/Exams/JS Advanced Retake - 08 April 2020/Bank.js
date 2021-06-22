class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer({ firstName, lastName, personalId }) {
        this.allCustomers.find((c) => {
            if (c.personalId === personalId) {
                throw new Error(`${firstName} ${lastName} is already our customer!`);
            }
        });
        this.allCustomers.push({ firstName, lastName, personalId });
        return { firstName, lastName, personalId };
    }

    depositMoney(personalId, amount) {
        let person = this.allCustomers.find((c) => { return c.personalId === personalId })
        if (person === undefined) {
            throw new Error(`We have no customer with this ID!`);
        } else {
            if (isNaN(person.totalMoney)) {
                person.totalMoney = amount;
            } else {
                person.totalMoney += amount;
            }

            if (!Array.isArray(person.transactionInfos)) {
                person.transactionInfos = [];
            }

            let message = `${person.transactionInfos.length + 1}. ${person.firstName} ${person.lastName} made deposit of ${amount}$!`;
            person.transactionInfos.push(message);
            return `${person.totalMoney}$`
        }
    }

    withdrawMoney(personalId, amount) {
        let person = this.allCustomers.find((c) => { return c.personalId == personalId });

        if (person == undefined) {
            throw new Error(`We have no customer with this ID!`);
        }

        if (person.totalMoney < amount) {
            throw new Error(`${person.firstName} ${person.lastName} does not have enough money to withdraw that amount!`);
        } else {
            let message = `${person.transactionInfos.length + 1}. ${person.firstName} ${person.lastName} withdrew ${amount}$!`;
            person.totalMoney -= amount;

            person.transactionInfos.push(message);

            return `${person.totalMoney}$`;
        }

    }
    customerInfo(personalId) {
        let person = this.allCustomers.find((c) => { return c.personalId === personalId });
        if (person === undefined) {
            throw new Error(`We have no customer with this ID!`);
        } else {
            let finalString = '';
            finalString += `Bank name: ${this._bankName}\n`;
            finalString += `Customer name: ${person.firstName} ${person.lastName}\n`;
            finalString += `Customer ID: ${person.personalId}\n`;
            finalString += `Total Money: ${person.totalMoney}$\n`;
            finalString += `Transactions:\n`;
            for (let i = person.transactionInfos.length - 1 ; i >= 0; i--) {
                finalString += person.transactionInfos[i];
                if (i !== 0) {
                    finalString += `\n`;
                }
            }
            return finalString;
        }
    }
}


let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));

