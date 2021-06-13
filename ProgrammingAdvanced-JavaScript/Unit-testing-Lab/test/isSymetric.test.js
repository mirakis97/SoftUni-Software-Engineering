const isSymmetric = require('../isSymetric');
const { assert, expect, should} = require('chai');

describe('Test isSymetric functionallity', () => {
    it ('Should pass when symetric array is provided', () => {
        let input = [1,2,3,2,1];
        let expectedResult = true;

        let actualResult = isSymmetric(input);

        assert.equal(actualResult, expectedResult);
    })
    it ('Should fail when non symetric array is provided', () => {
        let input = [1,2,3,2,1];
        let expectedResult = true;

        let actualResult = isSymmetric(input);

        assert.equal(actualResult, expectedResult);
    })
    it ('Should fail when non array is provided as an argument', () => {
        let expectedResult = false;


        assert.equal(isSymmetric(null), expectedResult);
        assert.equal(isSymmetric({}), expectedResult);
        assert.equal(isSymmetric(''), expectedResult);
        assert.equal(isSymmetric(0), expectedResult);
        assert.equal(isSymmetric(true), expectedResult);
        assert.equal(isSymmetric(undefined), expectedResult);
    })
    it ('Should pass when an empty array is provided', () => {
        let actualResult = isSymmetric([]);
        expect(actualResult).to.be.true;
    })
    it ('Should pass when an empty array is provided', () => {
        let actualResult = isSymmetric([]);
        expect(actualResult).to.be.true;
    })
    it ('Should fail', () => {
        let actualResult = isSymmetric(['1',1]);
        expect(actualResult).to.be.false;
    })
})