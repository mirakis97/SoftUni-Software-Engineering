import { render } from ".././node_modules/lit-html/lit-html.js"
import { allTownsTemplates } from "./templetas/townTemplates.js";
let form = document.getElementById('town');
form.addEventListener('submit',displayTowns);

let rootDiv = document.getElementById('root');
function displayTowns(e) {
    e.preventDefault();
    let form = e.target;
    let formData = new FormData(form);

    let townsString = formData.get('towns');
    let towns = townsString.split(', ');

    render(allTownsTemplates(towns), rootDiv);
}