class Vacationer {
    constructor(fullName, creditCard) {
        this.fullName = fullName;
        this._idNumber = this.generateIDNumber();
        this.creditCard = creditCard;
        this.wishList = [];
    }

    get creditCard() {
        return this._creditCard;
    }
    set creditCard(value) {
        if (!value) {
            this._creditCard = { cardNumber: 1111, expirationDate: '', securityNumber: 111 }
        } else {
            if (value.length != 3) {
                throw new Error("Missing credit card information");
            }
            let [cardNumber, expirationDate, securityNumber] = value;
            if (typeof cardNumber != "number" || typeof securityNumber != "number") {
                throw new Error("Invalid credit card details");
            }
            this._creditCard = {
                cardNumber: cardNumber,
                expirationDate: expirationDate,
                securityNumber: securityNumber
            };
        }
    }

    get fullName() {
        return this._fullName
    }
    set fullName(value) {
        if (value.length != 3) {
            throw new Error("Name must include first name, middle name and last name");
        }
        const regex = new RegExp('^[A-Z]{1}[a-z]{1,30}$');
        value.forEach((name) => {
            if (!regex.test(name)) {
                throw new Error("Invalid full name");
            }
        });
        this._fullName = { firstName: value[0], middleName: value[1], lastName: value[2] };
    }

    get idNumber() {
        return this._idNumber;
    }
    set idNumber(value) {
        this._idNumber = this.generateIDNumber();
    }

    generateIDNumber() {
        let result = 231 * this.fullName.firstName.charCodeAt(0) + 139 * this.fullName.middleName.length;
        const vowels = ['u', 'e', 'o', 'a', 'i'];
        const lastChar = this.fullName.lastName.charAt(this.fullName.lastName.length - 1);

        result += vowels.includes(lastChar) ? '8' : '7';
        return result;
    }

    addCreditCardInfo(input) {
        if (input.length != 3) {
            throw new Error("Missing credit card information");
        }
        if (typeof input[0] != "number" || typeof input[2] != "number") {
            throw new Error("Invalid credit card details");
        }
        let [cardNumber, expirationDate, securityNumber] = input;

        this._creditCard = {
            cardNumber: cardNumber,
            expirationDate: expirationDate,
            securityNumber: securityNumber
        };
    }

    addDestinationToWishList(destination) {
        if (this.wishList.includes(destination)) {
            throw new Error(
                "Destination already exists in wishlist");
        }

        this.wishList.push(destination);
        this.wishList.sort((a, b) => a.lenght - b.lenght);
    }

    getVacationerInfo() {
        let emtyOrWish = this.wishList.length == 0 ? 'empty' : this.wishList.join(', ');
        return `Name: ${this.fullName.firstName} ${this.fullName.middleName} ${this.fullName.lastName}\nID Number: ${this.idNumber}\nWishlist:\n${emtyOrWish}\nCredit Card:\nCard Number: ${this.creditCard.cardNumber}\nExpiration Date: ${this.creditCard.expirationDate}\nSecurity Number: ${this.creditCard.securityNumber}`
    }
}

// Initialize vacationers with 2 and 3 parameters
let vacationer1 = new Vacationer(["Vania", "Ivanova", "Zhivkova"]);
let vacationer2 = new Vacationer(["Tania", "Ivanova", "Zhivkova"], 
[123456789, "10/01/2018", 777]);

// Should throw an error (Invalid full name)
try {
    let vacationer3 = new Vacationer(["Vania", "Ivanova", "ZhiVkova"]);
} catch (err) {
    console.log("Error: " + err.message);
}

// Should throw an error (Missing credit card information)
try {
    let vacationer3 = new Vacationer(["Zdravko", "Georgiev", "Petrov"]);
    vacationer3.addCreditCardInfo([123456789, "20/10/2018"]);
} catch (err) {
    console.log("Error: " + err.message);
}

vacationer1.addDestinationToWishList('Spain');
vacationer1.addDestinationToWishList('Germany');
vacationer1.addDestinationToWishList('Bali');

// Return information about the vacationers
console.log(vacationer1.getVacationerInfo());
console.log(vacationer2.getVacationerInfo());

