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
        let person = this.allCustomers.find((c) => { return c.personalId === personalId });

        if (person === undefined) {
            throw new Error('We have no customer with this ID!');
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
            return `${person.totalMoney}$`;
        }

    }
    withdrawMoney(personalId, amount) {
        let person = this.allCustomers.find((c) => { return c.personalId === personalId });

        if (person === undefined) {
            throw new Error('We have no customer with this ID!');
        } else {
            if (isNaN(person.totalMoney)) {
                person.totalMoney = amount;
            } else if (person.totalMoney <= amount) {
                throw new Error(`${person.firstName} ${person.lastName} does not have enough money to withdraw that amount!`);
            } else {
                person.totalMoney -= amount;
            }

            if (!Array.isArray(person.transactionInfos)) {
                person.transactionInfos = [];
            }

            let message = `${person.transactionInfos.length + 1}. ${person.firstName} ${person.lastName} withdrew ${amount}$!`;
            person.transactionInfos.push(message);
            return `${person.totalMoney}$`;
        }
    }

    customerInfo(personalId) {
        let person = this.allCustomers.find((c) => { return c.personalId === personalId });

        if (person === undefined) {
            throw new Error('We have no customer with this ID!');
        } else {
            let sb = '';
            sb += `Bank name: ${this._bankName}\n`;
            sb += `Customer name: ${person.firstName} ${person.lastName}\n`;
            sb += `Customer ID: ${person.personalId}\n`;
            sb += `Total Money: ${person.totalMoney}$\n`;
            sb += `Transactions:\n`;
            for (let i = person.transactionInfos.length - 1; i >= 0; i--) {
                sb += person.transactionInfos[i];
                if (i !== 0) {
                    sb += '\n';
                }
            }
            return sb
        }
    }
}
