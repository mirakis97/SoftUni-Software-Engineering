import { html } from "../../node_modules/lit-html/lit-html.js"

export let townTemplate = (town) => html`<li>${town}</li>`; 

export let allTownsTemplates = (towns) => html`
<ul>
    ${towns.map(t => townTemplate(t))}
</ul>`;