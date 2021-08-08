import { html } from '../../node_modules/lit-html/lit-html.js';
import { deleteBook, getBookById } from '../api/data.js';



const detailsTemplate = (isOwner, book, onDelete) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${book.title}</h3>
        <p class="type">${book.type}</p>
        <p class="img"><img src=${book.imageUrl}></p>
        <div class="actions"></div>
        ${isOwner ? html`
        <a class="button" href="/edit/${book._id}">Edit</a>
        <a class="button" href="javascript:void(0)" @click=${onDelete}>Delete</a>` : ''}
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${book.description}</p>
    </div>
</section>
`;





export async function detailsPage(ctx) {
    const bookId = ctx.params.id;
    const book = await getBookById(bookId);
    // console.log('1', ctx.user);
    // console.log('2', book._ownerId);
    // console.log('3', ctx.user._id);
    const isOwner = ctx.user && book._ownerId == ctx.user._id;


    ctx.render(detailsTemplate(isOwner, book, onDelete));

    async function onDelete() {
        const confirmed = confirm('Are you sure?');
        if (confirmed) {
            await deleteBook(bookId);
            ctx.page.redirect('/dashboard');
        }
    }

}


{/* <a class="button" href="#">Like</a>
                    <div class="likes">
                        <img class="hearts" src="/images/heart.png">
                        <span id="total-likes">Likes: 0</span>
                    </div>
                    <!-- Bonus --> */}