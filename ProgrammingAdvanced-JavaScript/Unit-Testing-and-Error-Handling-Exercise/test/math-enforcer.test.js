const { expect } = require('chai');
const mathEnforcer = require('../4-Math-Enforcer');

describe('mathEnforcer',function () {
    describe('addFive', function () {
        it('should return invalid input',() => {
            expect(mathEnforcer.addFive('one')).to.be.undefined;
        })
        it('should add five ',() => {
            expect(mathEnforcer.addFive(1)).to.equal(6);
        })
        it('should add five to negative numbers',() => {
            expect(mathEnforcer.addFive(-1)).to.equal(4);
        })
        it('should add five to floating numbers ',() => {
            expect(mathEnforcer.addFive(1.1)).to.closeTo(6.1, 0.00001);
        })
        it('should add five to negative floating numbers',() => {
            expect(mathEnforcer.addFive(-1.1)).to.closeTo(3.9,00001);
        })
    })
    describe('subtractTen', function () {
        it('should return invalid input',() => {
            expect(mathEnforcer.subtractTen('one')).to.be.undefined;
        })
        it('should subtract seven ',() => {
            expect(mathEnforcer.subtractTen(11)).to.equal(1);
        })
        it('should subtract seven to negative numbers',() => {
            expect(mathEnforcer.subtractTen(-1)).to.equal(-11);
        })
        it('should subtract seven to floating numbers ',() => {
            expect(mathEnforcer.subtractTen(12.1)).to.closeTo(2.1, 0.00001);
        })
        it('should subtract seven to negative floating numbers',() => {
            expect(mathEnforcer.subtractTen(-1.1)).to.closeTo(-11.1,00001);
        })
    })
    describe('sum', function () {
      
        it('should return invalid input',() => {
            expect(mathEnforcer.sum('one',1)).to.be.undefined;
            expect(mathEnforcer.sum(1,'one')).to.be.undefined;
            expect(mathEnforcer.sum('one','two')).to.be.undefined;
        })
        it('should sums valid integers ',() => {
            expect(mathEnforcer.sum(1,1)).to.equal(2);
            expect(mathEnforcer.sum(1.2,1)).to.equal(2.2);
            expect(mathEnforcer.sum(1,1.2)).to.equal(2.2);
            expect(mathEnforcer.sum(2,-1)).to.equal(1);
            expect(mathEnforcer.sum(-2,1)).to.equal(-1);
            expect(mathEnforcer.sum(-2,-1)).to.equal(-3);
        })
    })
})