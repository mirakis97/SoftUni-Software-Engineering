import { render } from './../node_modules/lit-html/lit-html.js';
import { cats } from "./catSeeder.js";
import { allCatsTemplate } from './templates/catTemplates.js';

function toggleStatusCodeButton(e) {
    let button = e.target;
    button.textContent = button.textContent === 'Show status code'
        ? 'Hide status code'
        : 'Show status code';
    let infoDiv = button.closest('.info');
    let statusDiv = infoDiv.querySelector('.status');
    if(statusDiv.classList.contains('hidden')){
        statusDiv.classList.remove('hidden');
    } else {
        statusDiv.classList.add('hidden');
    }
}

let allCatsSection = document.getElementById('allCats');
render(allCatsTemplate(cats, toggleStatusCodeButton), allCatsSection);