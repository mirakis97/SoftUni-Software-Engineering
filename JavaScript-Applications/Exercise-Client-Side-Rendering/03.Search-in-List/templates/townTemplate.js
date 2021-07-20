import { html } from './../../node_modules/lit-html/lit-html.js'
import { ifDefined } from './../../node_modules/lit-html/directives/if-defined.js';

export let townTemplate = (town) => html`<li class=${ifDefined(town.class)}>${town.name}</li>`;

export let townsTemplate = (towns) => html`
<ul>
    ${towns.map(t => townTemplate(t))}
</ul>`;

export let matchesTemplate = (matches) => html`<span>${matches} matches found</span>`;