import { html } from '../../node_modules/lit-html/lit-html.js';


import { getAllListings, getCollectionSize } from '../api/data.js';
import { carTemplate } from './common/car.js';

const catalogTemplate = (cars) => html`<section id="car-listings">
    <h1>Car Listings</h1>
    <div class="listings">
 
        ${cars.length == 0 ? html`<p class="no-cars">No cars in database.</p>` :
        cars.map(carTemplate)}
    </div>
</section>`;


export async function catalogPage(ctx) {
    const cars = await getAllListings();
    ctx.render(catalogTemplate(cars));
}
