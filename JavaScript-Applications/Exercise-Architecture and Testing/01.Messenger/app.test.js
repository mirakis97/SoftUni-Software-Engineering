const { expect } = require('chai');
const { chromium } = require('playwright-chromium');

const host = 'http://localhost:3000';

let browser;
let context;
let page;


describe('E2E tests', function() {
    this.timeout(6000);

    before(async() => {
        browser = await chromium.launch();
    });

    after(async() => {
        await browser.close();
    });

    beforeEach(async() => {
        context = await browser.newContext();

        page = await context.newPage();

        await page.goto(host);
    });

    afterEach(async() => {
        await page.close();
        await context.close();
    });

    describe('Home', () => {
        it('loading messages', async() => {
            await page.goto('http://localhost:3000/')
            await page.click('text=Refresh');
            const messages = await page.$eval('#messages', (el) => el.value.split('\n'));

            expect(messages[0]).to.eql('Spami: Hello, are you there?');
            expect(messages[1]).to.eql('Garry: Yep, whats up :?');
            expect(messages[2]).to.eql('Spami: How are you? Long time no see? :)');
            expect(messages[3]).to.eql('George: Hello, guys! :))');
            expect(messages[4]).to.eql('Spami: Hello, George nice to see you! :)))');
        });
        it('send message ', async() => {
            await page.goto('http://localhost:3000/');
            await page.click('input[type="text"]');
            await page.fill('input[type="text"]', 'Anzhela');
            await page.click('#content');
            await page.fill('#content', 'Hi!');
            await page.click('text=Send');
            await page.click('text=Refresh');

            const messages = await page.$eval('#messages', (el) => el.value.split('\n'));
            expect(messages[6]).to.eql('Anzhela: Hi!');
        });
    });
});