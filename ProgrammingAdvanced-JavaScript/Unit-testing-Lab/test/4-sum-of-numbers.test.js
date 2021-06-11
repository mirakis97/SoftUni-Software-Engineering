const sum = require('../04. Sum of Numbers');
const { expect } = require('chai');

describe('Test sum functionallity', () => {
    it ('Should pass when sum array is provided', () => {
        expect(sum([1])).to.equal(1);
       
    });
    it ('Should multiple numbers', () => {
        expect(sum([1,1])).to.equal(2);
    });
    it('Should add different numbers', () => {
        expect(sum([1,2,3])).to.equal(6);
    });
})