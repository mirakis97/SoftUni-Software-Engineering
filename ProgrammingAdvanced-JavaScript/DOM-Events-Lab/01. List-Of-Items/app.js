function addItem() {
    let newItemTextElement = document.getElementById('newItemText');

    let itemsElement = document.getElementById('items');

    let lilItemElement = document.createElement('li');
    lilItemElement.textContent = newItemTextElement.value;

    itemsElement.appendChild(lilItemElement);
}