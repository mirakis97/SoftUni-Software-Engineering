const rgbToHexColor = require('../6-RGB-to-HEX');
const { expect } = require('chai');

describe('Test rgbToHexColor functionallity', () => {
    it ('Should pass when rgbToHexColor returns colors', () => {
       expect(rgbToHexColor(255,158,170)).to.equal('#FF9EAA')
    });
    it ('Should returns undefiend', () => {
        expect(rgbToHexColor('a',1,1)).to.equal(undefined);
        expect(rgbToHexColor(1,'x',1)).to.equal(undefined);
        expect(rgbToHexColor(1,1,'z')).to.equal(undefined);
    });
    it('Should returns white', () => {
        expect(rgbToHexColor(0,0,0)).to.equal('#000000');
    });
    
    it('Should returns undefiend when is less than zero', () => {
        expect(rgbToHexColor(-1,1,1)).to.equal(undefined);
        expect(rgbToHexColor(1,-1,1)).to.equal(undefined);
        expect(rgbToHexColor(1,1,-1)).to.equal(undefined);
    });

    it('Should returns undefiend when is bigger than 255', () => {
        expect(rgbToHexColor(256,1,1)).to.equal(undefined);
        expect(rgbToHexColor(1,300,1)).to.equal(undefined);
        expect(rgbToHexColor(1,1,2500)).to.equal(undefined);
    });
})