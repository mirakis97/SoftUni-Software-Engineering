import { html } from '../../node_modules/lit-html/lit-html.js';

import { deleteCar, getCarById } from '../api/data.js'


const detailsTemplate = (isOwner, car, onDelete) => html`
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src=${car.imageUrl}>
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${car.brand}</li>
            <li><span>Model:</span>${car.model}</li>
            <li><span>Year:</span>${car.year}</li>
            <li><span>Price:</span>${car.price}$</li>
        </ul>
        <p class="description-para">${car.description}</p>
        ${isOwner ? html` <div class="listings-buttons">
            <a href="/edit/${car._id}" class="button-list">Edit</a>
            <a href="javascript:void(0)" @click=${onDelete} class="button-list">Delete</a>
        </div>` : ''}
    </div>
</section>
`;




export async function detailsPage(ctx) {
    const carId = ctx.params.id;
    const car = await getCarById(carId);
    // console.log('1', ctx.user);
    // console.log('2', car._ownerId);
    // console.log('3', ctx.user._id);
    const isOwner =  ctx.user && car._ownerId == ctx.user._id;


    ctx.render(detailsTemplate(isOwner, car, onDelete));

    async function onDelete() {
        const confirmed = confirm('Are you sure?');
        if (confirmed) {
            await deleteCar(carId);
            ctx.page.redirect('/catalog');
        }
    }

}