import { html } from "../../node_modules/lit-html/lit-html.js";
import { getMemes } from "../api/data.js";

const catalogTemplate = (data) => html`
<section id="meme-feed">
    <h1>All Memes</h1>
    <div id="memes">
        ${data.length != 0 ? data.map(itemTemplate) : emptyTemplate()}
    </div>
</section>`;

const itemTemplate = (item) => html`
<div class="meme">
    <div class="card">
        <div class="info">
            <p class="meme-title">${item.title}</p>
            <img class="meme-image" alt="meme-img" src=${item.imageUrl}>
        </div>
        <div id="data-buttons">
            <a class="button" href="/details${item._id}">Details</a>
        </div>
    </div>
</div>`;

const emptyTemplate = () => html`
        <p class="no-memes">No memes in database.</p>`;


export async function catalogPage(ctx) {
    const data = await getMemes();
    ctx.render(catalogTemplate(data));
}