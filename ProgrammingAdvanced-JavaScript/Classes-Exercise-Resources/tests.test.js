let { expect } = require('chai');
let StringBuilder = require('./13.StringBulider');

describe('stringBUilder', () => {
    describe('constructor', () => {
        it ('Should initialize with empty array', () => {
            let sb = new StringBuilder(undefined);
            expect(sb.toString()).to.equal('');
        })
        it ('Should throw error if passed non-string arg', () => {
            expect(() => new StringBuilder (1.23).to.throw(TypeError));
            expect(() => new StringBuilder (null).to.throw(TypeError));
        })
        it ('Should initialize correct array when passed valid stibg', () => {
            let sb = new StringBuilder('abc');
            let sb2 = new StringBuilder('test');

            expect(sb.toString()).to.equal('abc');
            expect(sb2.toString()).to.equal('test');
        })
    })
    
})