const { expect } = require('chai');
const { chromium } = require('playwright-chromium');

let browser, page;

describe('EndToEnd test', function () {
    this.timout(6000);
    before(async() => {
        browser = await chromium.launch();
    });

    after(async() => {
        await browser.close();
    });

    beforeEach(async() => {
        page = await browser.newPage();
    });

    afterEach(async => {
        await page.close();
    });

    it('loads page', async() => {
        await page.goto('http://localhost:3000/');
        await page.click('text=Scalable Vector Graphics');
        await page.click('text=Unix');
        await page.click('span:has-text("Open standard")');
        await page.click('text=ALGOL');
    })
    it('loads page with more button show/toggle content', async() => {
        await page.goto('http://localhost:3000/');
        await page.click('text=More');
        const isVisible = await page
        .isVisible('text=Scalable Vector Graphics (SVG) is an Extensible Markup Language (XML)-based vect');
        expect(isVisible).to.be.true;
        
    })
    it('loads page with more button is click and the button change to Less ', async() => {
        await page.goto('http://localhost:3000/');
        await page.click('text=More');
        const isVisible = await page.isVisible('text=less');
        expect(isVisible).to.be.true;
    })

});