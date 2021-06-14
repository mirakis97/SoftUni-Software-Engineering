const { expect } = require('chai');
const lookupChar = require('../03-Char-Lookup');

describe('Should char-lookup', () => {
    it('returns udefiend with invalid input', () =>{
        expect(lookupChar(45,1)).to.be.undefined;
        expect(lookupChar('Miro',1.2)).to.be.undefined;
        expect(lookupChar('Miro','2')).to.be.undefined;
    })

    it('returns error input when is negative index', () =>{
        expect(lookupChar('Miro',-1)).to.equal('Incorrect index')
    })

    it('returns error with outside input', () =>{
        expect(lookupChar('Miro',8)).to.equal('Incorrect index')
        
    })
    it('returns char at index', () =>{
        expect(lookupChar('Miro',0)).to.equal('M')
        expect(lookupChar('Miro',1)).to.equal('i')
        expect(lookupChar('Miro',2)).to.equal('r')
        expect(lookupChar('Miro',3)).to.equal('o')
    })
})
