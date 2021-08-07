import { html } from '../../node_modules/lit-html/lit-html.js';


import { search } from '../api/data.js';
import { carTemplate } from './common/car.js';


const searchTemplate = (cars, onSearch, year) => html`<section id="search-cars">
    <h1>Filter by year</h1>
    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year" .value=${year || ''}>
        <button @click=${onSearch} class="button-list">Search</button>
    </div>
    <h2>Results:</h2>
    <div class="listings">
        ${cars.length == 0 ? html`<p class="no-cars"> No results.</p>` :
        cars.map(carTemplate)}
    </div>
</section>`;

export async function searchPage(ctx) {
    const year = Number(ctx.querystring.split('=')[1]);

    const cars = Number.isNaN(year) ? [] : await search(year);
    ctx.render(searchTemplate(cars, onSearch, year));

    function onSearch() {
        const query = Number(document.getElementById('search-input').value);
        ctx.page.redirect('/search?query=' + query);
    }
}