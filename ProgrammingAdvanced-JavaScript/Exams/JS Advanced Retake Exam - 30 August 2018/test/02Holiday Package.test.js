let { assert, expect } = require('chai');

class HolidayPackage {
    constructor(destination, season) {
        this.vacationers = [];
        this.destination = destination;
        this.season = season;
        this.insuranceIncluded = false; // Default value
    }

    showVacationers() {
        if (this.vacationers.length > 0)
            return "Vacationers:\n" + this.vacationers.join("\n");
        else
            return "No vacationers are added yet";
    }

    addVacationer(vacationerName) {
        if (typeof vacationerName !== "string" || vacationerName === ' ') {
            throw new Error("Vacationer name must be a non-empty string");
        }
        if (vacationerName.split(" ").length !== 2) {
            throw new Error("Name must consist of first name and last name");
        }
        this.vacationers.push(vacationerName);
    }

    get insuranceIncluded() {
        return this._insuranceIncluded;
    }

    set insuranceIncluded(insurance) {
        if (typeof insurance !== 'boolean') {
            throw new Error("Insurance status must be a boolean");
        }
        this._insuranceIncluded = insurance;
    }

    generateHolidayPackage() {
        if (this.vacationers.length < 1) {
            throw new Error("There must be at least 1 vacationer added");
        }
        let totalPrice = this.vacationers.length * 400;

        if (this.season === "Summer" || this.season === "Winter") {
            totalPrice += 200;
        }

        totalPrice += this.insuranceIncluded === true ? 100 : 0;

        return "Holiday Package Generated\n" +
            "Destination: " + this.destination + "\n" +
            this.showVacationers() + "\n" +
            "Price: " + totalPrice;
    }
}



describe("Tests …", () => {
    let repo = undefined;
    let props = { destination: 'Pepi', season: 'Spring' };
    let entity = { destination: 'Pepi', season: 'Spring' };

    beforeEach(function () {
        repo = new HolidayPackage(props);
    });


    it('Should return false insurance', function () {
        expect(repo.insuranceIncluded).to.equal(false);
    });
    it('Should throw error with number', function () {
        expect(function () { repo.insuranceIncluded(24) }).to.throw();
    });
    it('Should throw error wtih string', function () {
        expect(function () { repo.insuranceIncluded(String) }).to.throw();
    });
    it('Should return false insurance', function () {
        repo.insuranceIncluded = true;
        expect(repo.insuranceIncluded).to.equal(true);
    });


    it('Should vacationers to be array', () => {
        repo = entity;
        expect(repo).to.equal(entity);
    });

    it('tests showVacationers with added vactioners', () => {
        repo.addVacationer('Ivan Petrov');
        expect(repo.showVacationers()).to.equal("Vacationers:\n" + "Ivan Petrov");
    });

    it('tests showVacationers with no added vacationers', () => {
        expect(repo.showVacationers()).to.equal("No vacationers are added yet");
    });


    it('tests addVacationer to throw error added vactioners', () => {
        expect(function () { repo.addVacationer('Ivan') }).to.throw();
    });

    it('tests addVacationer to throw error when is empty string ', () => {
        expect(function () { repo.addVacationer(' ') }).to.throw();
    });
    it('tests addVacationer to throw error when is added number', () => {
        expect(function () { repo.addVacationer(2) }).to.throw();
    });

    it('tests generateHolidayPackage to throw error when vacationer are less then 1 ', () => {
        expect(function () { repo.generateHolidayPackage() }).to.throw();
    });

    it('tests generateHolidayPackage with different season than Summer/Winter ', () => {
        repo.addVacationer('Miroslav Vasilev')
        expect(repo.generateHolidayPackage()).to.equal("Holiday Package Generated\n" +
        "Destination: " + repo.destination + "\n" +
        repo.showVacationers() + "\n" +
        "Price: " + 400);
    });

    it('tests generateHolidayPackage with season  Summer ', () => {
        repo.addVacationer('Miroslav Vasilev')
        repo.season = 'Summer'
        expect(repo.generateHolidayPackage()).to.equal("Holiday Package Generated\n" +
        "Destination: " + repo.destination + "\n" +
        repo.showVacationers() + "\n" +
        "Price: " + 600);
    });

    it('tests generateHolidayPackage with season  Winter ', () => {
        repo.addVacationer('Miroslav Vasilev')
        repo.season = 'Winter'
        expect(repo.generateHolidayPackage()).to.equal("Holiday Package Generated\n" +
        "Destination: " + repo.destination + "\n" +
        repo.showVacationers() + "\n" +
        "Price: " + 600);
    });

    it('tests generateHolidayPackage with insurance included ', () => {
        repo.addVacationer('Miroslav Vasilev')
        repo.season = 'Summer'
        repo.insuranceIncluded = true;
        expect(repo.generateHolidayPackage()).to.equal("Holiday Package Generated\n" +
        "Destination: " + repo.destination + "\n" +
        repo.showVacationers() + "\n" +
        "Price: " + 700);
    });

});
