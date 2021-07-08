function attachEvents() {
    document.querySelector('#btnLoad').addEventListener('click',loadPosts);
    document.querySelector('#btnCreate').addEventListener('click',createPost);
}

attachEvents();

async function loadPosts() {
    const ul = document.querySelector('#phonebook');
    const response = await fetch('http://localhost:3030/jsonstore/phonebook');
    const data = await response.json();

    ul.innerHTML = '';

    Object.values(data)
    .map(createE)
    .forEach((p) => ul.appendChild(p))
}

async function deletePost(even) {
    const id = even.target.parentNode.id;
    const url = `http://localhost:3030/jsonstore/phonebook` + id;

    const response = await fetch(url, {
        method: 'delete',
        headers: { 'Content-Type': 'application/json'},
    })
    even.target.parentNode.remove();
}
async function createPost() {
    const name = document.querySelector('#person').value;
    const phone = document.querySelector('#phone').value;

    if (name && phone) {
        const response = await fetch('http://localhost:3030/jsonstore/phonebook', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({name, phone})
        });
        loadPosts();
    }else{
        return alert('All fields are required!')
    }
}

function createE({ name,phone,_id}) {
    const element = document.createElement('li');
    element.setAttribute('id',_id);
    element.textContent = `${name}: ${phone}`;

    const deleteButton = document.createElement('button');

    deleteButton.textContent = 'Delete';
    deleteButton.addEventListener('click',deletePost);
    element.append(deleteButton);

    return element;
}