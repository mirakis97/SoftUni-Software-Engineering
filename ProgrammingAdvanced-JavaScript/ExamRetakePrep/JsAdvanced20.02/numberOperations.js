
let { assert, expect } = require('chai');

const numberOperations = {
    powNumber: function (num) {
        return num * num;
    },
    numberChecker: function (input) {
        input = Number(input);

        if (isNaN(input)) {
            throw new Error('The input is not a number!');
        }

        if (input < 100) {
            return 'The number is lower than 100!';
        } else {
            return 'The number is greater or equal to 100!';
        }
    },
    sumArrays: function (array1, array2) {

        const longerArr = array1.length > array2.length ? array1 : array2;
        const rounds = array1.length < array2.length ? array1.length : array2.length;

        const resultArr = [];

        for (let i = 0; i < rounds; i++) {
            resultArr.push(array1[i] + array2[i]);
        }

        resultArr.push(...longerArr.slice(rounds));

        return resultArr
    }
};


describe("Tests …", function () {
    describe("numberOperations …", function () {
        it("powNumber works correct …", function () {
            expect(numberOperations.powNumber(2)).to.equal(4);
            assert.strictEqual(numberOperations.powNumber(1.5), 1.5 * 1.5);
            expect(numberOperations.powNumber(4)).to.equal(16);
            expect(numberOperations.powNumber(5)).to.equal(25);
            expect(numberOperations.powNumber(-4)).to.equal(16);
            assert.strictEqual(numberOperations.powNumber(0), 0);

        })

        it("numberChecher throws error if is not a number …", function () {
            expect(function() { numberOperations.numberChecker("asd") }).to.throw();
            expect(function() { numberOperations.numberChecker("123b") }).to.throw();
            expect(function() { numberOperations.numberChecker(undefined) }).to.throw();

        })
        it("numberChecher throws correct message …", function () {
            expect(numberOperations.numberChecker(101)).to.equal('The number is greater or equal to 100!');
            expect(numberOperations.numberChecker(99)).to.equal('The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker("-199"), "The number is lower than 100!");
            assert.strictEqual(numberOperations.numberChecker(""), "The number is lower than 100!");
            assert.strictEqual(numberOperations.numberChecker("100"), "The number is greater or equal to 100!");
            assert.strictEqual(numberOperations.numberChecker("123.5"), "The number is greater or equal to 100!");

        })
        it("sumArrays works correct…", function () {
            expect(numberOperations.sumArrays([1],[2])).to.eqls([3]);
            expect(numberOperations.sumArrays([1,2,3],[2])).to.eqls([3,2,3]);
            expect(numberOperations.sumArrays([],[2])).to.eqls([2]);
            expect(numberOperations.sumArrays(['a','b','c'],['c','d','f'])).to.eqls(['ac','bd','cf']);
            expect(numberOperations.sumArrays([],[])).to.eqls([]);
        })
    });
});
