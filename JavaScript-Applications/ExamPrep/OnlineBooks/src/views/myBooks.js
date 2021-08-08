import { html } from '../../node_modules/lit-html/lit-html.js';
import { getMyBooks } from '../api/data.js';


const myListingsTemplate = (books) => html`
<section id="my-books-page" class="my-books">
    <h1>My Books</h1>
    <ul class="my-books-list">
        ${books.length > 0 ? books.map(b => bookTemplate(b)) 
        : html`<p class="no-books">No books in database!</p>`}
    </ul>
</section>`;

const bookTemplate = (book) => html`
<li class="otherBooks">
            <h3>${book.title}</h3>
            <p>${book.type}</p>
            <p class="img"><img src=${book.imageUrl}></p>
            <a class="button" href="/details/${book._id}">Details</a>
        </li>`;



export async function myListingsPage(ctx) {
    const userId = ctx.user._id;
    const cars = await getMyBooks(userId);

    ctx.render(myListingsTemplate(cars));
}