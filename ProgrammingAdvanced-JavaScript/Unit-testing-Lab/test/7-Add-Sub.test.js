const createCalculator = require('../7-Add-Substract');
const { expect } = require('chai');

describe('Test calculator functionallity', () => {

    let calculator = '';
    beforeEach(function() {
        calculator = createCalculator();
    });

    it ('Should returns module with function add', () => {
       expect(Object.keys(calculator).includes('add')).to.be.true;
       expect(Object.keys(calculator).includes('subtract')).to.be.true;
       expect(Object.keys(calculator).includes('get')).to.be.true;
    });
    it ('Should returns get', () => {
        expect(calculator.get()).equal(0);
       
    });
    it('Should returns false when searching for funcion ser', () => {
        expect(Object.keys(calculator).includes('set')).to.be.false;
    });
    
    it('Should returns method add properly', () => {
        calculator.add(1);
        expect(calculator.get()).to.equal(1);
    });

    it('Should returns method add properly', () => {
        calculator.add('1');
        expect(calculator.get()).to.equal(1);
    });

    it('Should returns method subtract properly', () => {
        calculator.subtract(1);
        expect(calculator.get()).to.equal(-1);
    });

    it('Should returns method subtract properly', () => {
        calculator.subtract('1');
        expect(calculator.get()).to.equal(-1);
    });
    
    it('Should returns method subtract NaN', () => {
        calculator.subtract('Miro');
        expect(calculator.get()).to.be.NaN;
    });

    it('Should returns method add NaN', () => {
        calculator.add('Miro');
        expect(calculator.get()).to.be.NaN;
    });

})