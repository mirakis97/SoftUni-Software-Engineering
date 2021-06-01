function extractText() {
    //let listItems = document.querySelectorAll('#items li')
    let listetElement = document.getElementById('items');

    let itemText = listetElement.textContent;

    let resultElement = document.getElementById('result');
    resultElement.textContent = itemText;
}