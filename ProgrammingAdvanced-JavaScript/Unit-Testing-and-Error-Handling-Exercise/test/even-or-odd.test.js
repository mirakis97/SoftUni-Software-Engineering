const { expect } = require('chai');
const isOddOrEven = require('../2-Even or Odd');

describe('isOdOrEven works', () => {
    it('returns udefiend with invalid input', () =>{
        expect(isOddOrEven(1)).to.be.undefined;
    })

    it('returns even with even input', () =>{
        expect(isOddOrEven('aa')).to.equal('even');
    })

    it('returns odd with odd input', () =>{
        expect(isOddOrEven('aaa')).to.equal('odd');
    })
})
