let loadBookBtn = document.getElementById('loadBooks');
loadBookBtn.addEventListener('click', getBooks);
let booksTableBody = document.querySelector('#books-table tbody');
booksTableBody.querySelectorAll('tr').forEach(tr => tr.remove());

let bookForm = document.getElementById('book-form');

bookForm.addEventListener('submit',handleForm);

function handleEdit(event) {
    let currBook = event.target.closest('.book');
    let currTitle = currBook.querySelector('.title');
    let currentAuthor = currBook.querySelector('.author');

    let formHeading = bookForm.querySelector('h3');
    formHeading.textContent = 'Edit Form';
    bookForm.dataset.entryId = currBook.dataset.id;
    bookForm.dataset.isEdit = true;

    let titleInput = bookForm.querySelector('input[name="title"]');
    let authorInput = bookForm.querySelector('input[name="author"]');
    titleInput.value = currTitle.textContent;
    authorInput.value = currentAuthor.textContent;
}

async function handleForm(e) {
    e.preventDefault();
    let form = e.currentTarget;
    let formData = new FormData(form);
    if (form.dataset.isEdit !== undefined) {
        let id = form.dataset.entryId;
        updateBook(formData,id);
    }else {
        createBook(formData);
    }
}
async function updateBook(event) {
    event.preventDefault();
    const data = new FormData(event.target);
    const id = data.get('id');
    const book = {
        title: data.get('title'),
        author: data.get('author')
    }
    let url = `http://localhost:3030/jsonstore/collections/books` + id;
    let editResponse = await fetch(url, {
        headers: { 'Content-Type': 'application/json' },
        method: 'Put',
        body: JSON.stringify(book)
    });
    let result = await editResponse.json();
    let editBook = booksTableBody.querySelector(`tr.book[data-id="${id}"]`);
    let editedHtmlBook = createHtmlBook(result,result._id);
    editBook.replaceWith(editedHtmlBook);
}

async function deleteBook(element) {
    let bookToDelete = element.target.closest('.book');
    let id = bookToDelete.dataset.id;

    let url = `http://localhost:3030/jsonstore/collections/books` + id;
    let deleteResponse = await fetch(url, {
        method: 'Delete'
    });

    if (deleteResponse.status == 200) {
        bookToDelete.remove();
    }
}
async function createBook(e) {     
     let book = {
         title: e.get('title'),
         author: e.get('author')
     }
     let url = `http://localhost:3030/jsonstore/collections/books`;
    let response = await fetch(url,{
         headers: { 'Content-Type': 'application/json' },
         method: 'Post',
         body: JSON.stringify(book)
     });
     let result = await response.json();
     let createHtmlBook = createHtmlBook(result, result._id);
     booksTableBody.appendChild(createHtmlBook);
 }
async function getBooks(){
    let url = 'http://localhost:3030/jsonstore/collections/books';
    let getBooksResponse = await fetch(url);
    let books = await getBooksResponse.json();
    console.log(books);

    booksTableBody.querySelectorAll('tr').forEach(tr => tr.remove());

    Object.keys(books).forEach(key => {
        let htmlBook = createHtmlBook(books[key], key);
        booksTableBody.appendChild(htmlBook);
    })
}
function createHtmlBook(book, id){
    let titleTd = Create('td', {class: 'title'}, book.title);
    let authorTd = Create('td', {class: 'author'}, book.author);
    let editBtn = Create('button', undefined, 'Edit');
    editBtn.addEventListener('click', handleEdit);
    let deleteBtn = Create('button', undefined, 'Delete');
    deleteBtn.addEventListener('click', deleteBook);
    let buttonsTd = Create('td', undefined, editBtn, deleteBtn);
    let tr = Create('tr', {class: 'book'}, titleTd, authorTd, buttonsTd);
    tr.dataset.id = id;
    return tr;
}

 
function Create(tag, attributes, ...params){
    let element = document.createElement(tag);
    let firstValue = params[0];
    if(params.length === 1 && typeof(firstValue) !== 'object'){
        if(['input', 'textarea'].includes(tag)) {
            element.value = firstValue;
        } else {
            element.textContent = firstValue;
        }
    } else {
        element.append(...params);
    }

    if(attributes !== undefined){
        Object.keys(attributes).forEach(key => {
            element.setAttribute(key, attributes[key]);
        })
    }

    return element;
}




