const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

const host = 'http://localhost:3000';

let browser;
let context;
let page;

describe('E2E tests', function() {
    this.timeout(600000);

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
        it('load all books', async() => {
            await page.goto('http://localhost:3000/');
            await page.click('text=LOAD ALL BOOKS');
            await page.waitForSelector('tbody tr td');
            const firstBook = await page.$eval('tbody tr:first-child :first-child', (el) => el.textContent.trim());
            const firstAuthor = await page.$eval('tbody tr:first-child :nth-child(2)', (el) => el.textContent.trim());

            const secondBook = await page.$eval('tbody tr:nth-child(2) :first-child', (el) => el.textContent.trim());
            const secondAuthor = await page.$eval('tbody tr:nth-child(2) :nth-child(2)', (el) => el.textContent.trim());

            expect(firstBook).to.eql('Harry Potter and the Philosopher\'s Stone');
            expect(firstAuthor).to.eql('J.K.Rowling');

            expect(secondBook).to.eql('C# Fundamentals');
            expect(secondAuthor).to.eql('Svetlin Nakov');
        });

        it('create book', async() => {
            await page.goto('http://localhost:3000/');
            await page.click('[placeholder="Title..."]');
            await page.fill('[placeholder="Title..."]', 'JS');
            await page.click('[placeholder="Author..."]');
            await page.fill('[placeholder="Author..."]', 'PAPAZOV');
            await page.click('text=Submit');
            await page.click('text=LOAD ALL BOOKS');
            await page.waitForSelector('tbody tr td');

            const createdBook = await page.$eval('tbody tr:nth-child(3) :first-child', (el) => el.textContent.trim());
            const createdAuthor = await page.$eval('tbody tr:nth-child(3) :nth-child(2)', (el) => el.textContent.trim());

            expect(createdBook).to.eql('JS');
            expect(createdAuthor).to.eql('PAPAZOV');
        });

        it('edit book', async() => {

            await page.goto('http://localhost:3000/');
            
            await page.click('text=LOAD ALL BOOKS');

            await page.click('text=Edit');
            await page.click('text=Edit FORM TITLE AUTHOR Save >> [placeholder="Title..."]');
            await page.click('text=Edit FORM TITLE AUTHOR Save >> [placeholder="Author..."]');


            await page.fill('text=Edit FORM TITLE AUTHOR Save >> [placeholder="Author..."]', 'J.K.Rowlingaaaaaa');
            await page.click('text=Save');


            await page.click('text=LOAD ALL BOOKS');

            await page.click('text=J.K.Rowlingaaaaaa');


            await page.waitForSelector('tbody tr td');

            const firstBook = await page.$eval('tbody tr:first-child :first-child', (el) => el.textContent.trim());
            const firstAuthor = await page.$eval('tbody tr:first-child :nth-child(2)', (el) => el.textContent.trim());
            expect(firstBook).to.eql('Harry Potter and the Philosopher\'s Stone');
            expect(firstAuthor).to.eql('J.K.Rowlingaaaaaa');
        });

        it.only('delete book', async() => {
            await page.goto('http://localhost:3000/');
            await page.click('text=LOAD ALL BOOKS');
            page.on('dialog', (dialog) => {
                dialog.accept();
            });

            await page.click('tbody tr:last-child .deleteBtn');
            await page.click('#loadBooks');

            await page.waitForSelector('tbody tr td');

            const secondBook = await page.$eval('tbody tr:nth-child(2) :first-child', (el) => el.textContent.trim());
            const secondAuthor = await page.$eval('tbody tr:nth-child(2) :nth-child(2)', (el) => el.textContent.trim());

            expect(secondBook).to.eql('JS');
            expect(secondAuthor).to.eql('PAPAZOV');
        });

    });
});