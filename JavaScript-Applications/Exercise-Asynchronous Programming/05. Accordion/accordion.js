async function solution() {
    const selection = document.getElementById('main');
    const url = `http://localhost:3030/jsonstore/advanced/articles/list`;
    const response = await fetch(url);
    const data = await response.json();

    Object.values(data).map(createElements).forEach(el => selection.appendChild(el));
}
solution();

function createElements({_id, title}) {
    let div = create('div', undefined, 'accordion');
    let divTwo = create('div', undefined, 'head');
    let span = create('span', title);
    let button = create('button', 'More', 'button', _id);
    button.addEventListener('click',(e) => more(e,p, extradiv, _id));

    divTwo.appendChild(span);
    divTwo.appendChild(button);
    div.appendChild(divTwo);

    const extradiv = create('div', undefined, 'extra');
    const p = create('p');
    extradiv.appendChild(p);
    div.appendChild(extradiv);

    return div;
}
function create(type,content,className, id) {
    let element = document.createElement(type);

    if (content) {
        element.textContent = content;
    }
    if (className) {
        element.className = className;
    }
    if (id) {
        element.id = id;
    }

    return element;
}
async function more(e,p,extradiv, id) {
    const url = `http://localhost:3030/jsonstore/advanced/articles/details/` + id;

    const response = await fetch(url);
    const data = await response.json();

    p.textContent = data.content
    if(e.target.textContent == 'More'){
        e.target.textContent = 'Less'
        extradiv.style.display = 'flex';
    }
    else{
        e.target.textContent = 'More'
        extradiv.style.display = 'none'
    }
}