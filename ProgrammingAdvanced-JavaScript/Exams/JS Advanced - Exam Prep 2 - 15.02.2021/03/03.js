const { assert, expect } = require('chai');

let dealership = {
    newCarCost: function (oldCarModel, newCarPrice) {

        let discountForOldCar = {
            'Audi A4 B8': 15000,
            'Audi A6 4K': 20000,
            'Audi A8 D5': 25000,
            'Audi TT 8J': 14000,
        }

        if (discountForOldCar.hasOwnProperty(oldCarModel)) {
            let discount = discountForOldCar[oldCarModel];
            let finalPrice = newCarPrice - discount;
            return finalPrice;
        } else {
            return newCarPrice;
        }
    },

    carEquipment: function (extrasArr, indexArr) {
        let selectedExtras = [];
        indexArr.forEach(i => {
            selectedExtras.push(extrasArr[i])
        });

        return selectedExtras;
    },

    euroCategory: function (category) {
        if (category >= 4) {
            let price = this.newCarCost('Audi A4 B8', 30000);
            let total = price - (price * 0.05)
            return `We have added 5% discount to the final price: ${total}.`;
        } else {
            return 'Your euro category is low, so there is no discount from the final price!';
        }
    }
}


describe("dillership …", function() {
    describe("newCarCost …", function() {

        it("gives dicsount when is old model …", function() {
            expect(dealership.newCarCost('Audi A4 B8',20000)).to.equal(5000);
            expect(dealership.newCarCost('Audi A6 4K',30000)).to.equal(10000);
            expect(dealership.newCarCost('Audi A8 D5',50000)).to.equal(25000);
            expect(dealership.newCarCost('Audi TT 8J',20000)).to.equal(6000);
        });

        it("gives price …", function() {
            expect(dealership.newCarCost('BMW M3 ',20000)).to.equal(20000);
        });

     });

     describe("carEquipment …", function() {

        it("return undefined …", function() {
            expect(dealership.carEquipment(['BMW','M3 '],[20000])).to.eql([undefined]);
           
        });

        it("carEquipment to work …", function() {
            expect(dealership.carEquipment(['BMW','M3'],[1])).to.eql(['M3']);
            expect(dealership.carEquipment(['BMW','M3'],[0,1])).to.eql(['BMW','M3']);

        });

     });

     describe("euroCategory …", function() {

        it("euroCategory should return…", function() {
            expect(dealership.euroCategory(4)).to.equal('We have added 5% discount to the final price: 14250.');
            expect(dealership.euroCategory(5)).to.equal('We have added 5% discount to the final price: 14250.');

           
        });

        it("carEquipment to work …", function() {
            expect(dealership.euroCategory(3)).to.equal('Your euro category is low, so there is no discount from the final price!');

        });

     });
});

