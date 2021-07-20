import { render } from './../node_modules/lit-html/lit-html.js'
import { matchesTemplate, townTemplate } from "./templates/townTemplate.js";
import { towns } from "./towns.js";

let townsDiv = document.getElementById('towns');
let baseTowns = towns.map(t => ({name: t}));
render(townTemplate(baseTowns), townsDiv);

let resultDiv = document.getElementById('result');

let searchButton = document.getElementById('search-btn');
searchButton.addEventListener('click', search);

function search() {
   let searchInput = document.getElementById('searchText');
   let searchText = searchInput.value.toLowerCase();

   let allTowns = towns.map(t => ({ name: t }));
   let matchedTowns = allTowns.filter(t => t.name.toLowerCase().includes(searchText));
   matchedTowns.forEach(t => t.class = 'active');
   let matches = matchedTowns.length;

   console.log(allTowns);
   render(townTemplate(allTowns), townsDiv);
   render(matchesTemplate(matches), resultDiv);
}


