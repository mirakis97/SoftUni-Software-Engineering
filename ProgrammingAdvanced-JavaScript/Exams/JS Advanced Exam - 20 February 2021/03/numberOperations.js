let { assert , expect} = require('chai');

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


describe("Tests numberOperations", function() {
    describe("powNumber …", function() {
        it("Should return number to the second …", function() {
            assert.strictEqual(numberOperations.powNumber(3), 9);
            assert.strictEqual(numberOperations.powNumber(1.5), 1.5 * 1.5);
            assert.strictEqual(numberOperations.powNumber(-4), 16);
            assert.strictEqual(numberOperations.powNumber(0), 0);
        });
     });

     describe("numberChecker …", function() {
        it("Should correctly  input argument  …", function() {
            assert.strictEqual(numberOperations.numberChecker("3"), "The number is lower than 100!");
            assert.strictEqual(numberOperations.numberChecker(""), "The number is lower than 100!");
        });
        it("Should throw error when input argument  …", function() {
            assert.throw(() => numberOperations.numberChecker("abc"),Error, "The input is not a number!");
            assert.throw(() => numberOperations.numberChecker(undefined),Error, "The input is not a number!");
            assert.throw(() => numberOperations.numberChecker("123b"),Error, "The input is not a number!");
        });

        it("Should correctly return string when is valid input  …", function() {
            assert.strictEqual(numberOperations.numberChecker("99"), "The number is lower than 100!");
            assert.strictEqual(numberOperations.numberChecker("100"), "The number is greater or equal to 100!");
            assert.strictEqual(numberOperations.numberChecker("-199"), "The number is lower than 100!");
            assert.strictEqual(numberOperations.numberChecker("123.5"), "The number is greater or equal to 100!");

        });
       
     });
     describe("summArrays …", function() {
        it("Should correctly  input argument  …", function() {
            assert.deepEqual(numberOperations.sumArrays([],[]), []);
            assert.strictEqual(numberOperations.sumArrays([1],[2]), [3]);
        });
    
        it("Should empty array when ome parameter is an empty  …", function() {
            assert.deepEqual(numberOperations.sumArrays([1,2,3],[]), [1,2,3]);
            assert.deepEqual(numberOperations.sumArrays([],[1,2,3]), [1,2,3]);

            assert.strictEqual(numberOperations.sumArrays([1],[2]), [3]);
        });
    
        it("Should return correct result  …", function() {
            assert.deepEqual(numberOperations.sumArrays([1,2,3],[2,3,4]), [3,5,7]);
            assert.deepEqual(numberOperations.sumArrays(['a','b','c'],['b','c','cd']), ['ab','bc','cd']);

        });

        it("Should return correct result when array are diferent length  …", function() {
            assert.deepEqual(numberOperations.sumArrays([1,2,3],[2,3]), [3,5,3]);
            assert.deepEqual(numberOperations.sumArrays(['a','b','c'],['b','c']), ['ab','bc','c']);

        });
     });
});