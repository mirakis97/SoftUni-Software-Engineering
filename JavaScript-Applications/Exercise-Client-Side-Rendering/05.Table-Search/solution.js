import { html, render } from "../node_modules/lit-html/lit-html.js";

const rowTemplate = (student, select) => html`
<tr class=${select ? 'select' : ''}>
   <td>${student.firstName} ${student.lastName}</td>
   <td>${student.email}</td>
   <td>${student.course}</td>
</tr>`;

const tbody = document.querySelector('tbody');
const input = document.getElementById('searchField');
start();

async function start() {
   document.getElementById('searchBtn').addEventListener('click',() => {
      update(list, input.value)
   });

   const response = await fetch('http://localhost:3030/jsonstore/advanced/table');
   const data = await response.json();
   const list = Object.values(data);
   update(list);
}

function update(list,match) {
   const result = list.map(e => rowTemplate(e, compare(e,match)));
   render(result,tbody);
}

function compare(item, match) {
   return Object.values(item).some(v => match && v.toLowerCase().includes(match.toLowerCase()))
}