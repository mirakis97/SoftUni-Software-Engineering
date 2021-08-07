import { html } from '../../node_modules/lit-html/lit-html.js';
import { getMyListings } from '../api/data.js';
import { carTemplate } from './common/car.js';


const profileTemplate = (cars) => html`<section id="my-listings">
    <h1>My car listings</h1>
    <div class="listings">
        ${cars.length == 0 ? html` <p class="no-cars"> You haven't listed any cars yet.</p>`
         :
        cars.map(carTemplate)}
    </div>
</section>`;


export async function profilePage(ctx){
    const cars = await getMyListings(ctx.user._id);
    ctx.render(profileTemplate(cars));
}