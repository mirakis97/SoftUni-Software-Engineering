import { html } from '../../node_modules/lit-html/lit-html.js';
import { getById } from '../api/data.js';
import { deleteRecord } from '../api/data.js';


const detailsTemplate = (item, isOnwer, onDelete) => html`
<section id="meme-details">
    <h1>Meme Title: ${item.title}</h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src=${item.imageUrl}>
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>${item.description}</p>
            ${isOnwer ? html`<a class="button warning" href=${`/edit/${item._id}`}>Edit </a> <button @click=${onDelete}
                href="javascript:void(0)" class="button danger">Delete</button>` : ''}

        </div>
    </div>
</section>`;

export async function detailsPage(ctx) {
    const id = ctx.params.id;
    const item = await getById(id);

    const userId = sessionStorage.getItem('userId');

    ctx.render(detailsTemplate(item, item._ownerId == userId, onDelete));

    async function onDelete() {
        const confirmed = confirm('Are you sure you want to delete this item?');

        if (confirmed) {

            await deleteRecord(item._id);
            ctx.page.redirect('/catalog');
        }
    }
}