window.addEventListener('load', solve);

function solve() {
    const model = document.getElementById('model');
    const year = document.getElementById('year');
    const description = document.getElementById('description');
    const price = document.getElementById('price');

    let submitButtonElement = document.getElementById('add');

    submitButtonElement.addEventListener('click', (e) => {
        e.preventDefault()
        console.log('Kiko');
        if (!model.value || !description.value || year.value < 0 || price.value < 0) {
            return;
        }
        let modelInput = model.value;
        let yearInput = year.value;
        let descriptionInput = description.value;
        let priceInput = price.value;
        console.log(modelInput,yearInput,descriptionInput,priceInput);

        model.value = '';
        year.value = '';
        description.value = '';
        price.value = '';

        let trElement = document.createElement('tr')
        trElement.classList.add('info')
        let tdModelElement = document.createElement('td');
        tdModelElement.textContent = modelInput;
        let tdPriceElement = document.createElement('td');
        tdPriceElement.textContent = Number(priceInput).toFixed(2);
        let tdButtonsElement = document.createElement('td');
        let trHideElement = document.createElement('tr')
        trHideElement.classList.add('hide');
        let tdYearElement = document.createElement('td');
        tdYearElement.textContent = yearInput;
        let tdDescriptionElement = document.createElement('td');
        tdDescriptionElement.colSpan = 3;
        tdDescriptionElement.textContent = `Description: ${descriptionInput}`;

        let moreInfoBtn = el('button', 'More Info', 'moreBtn');
        moreInfoBtn.addEventListener('click', (e) => {
            e.preventDefault();

        });
        let deleteBtn = el('button', 'Buy it', 'buyBtn');
        deleteBtn.addEventListener('click', (e) => {
            e.preventDefault();
            let totalPrice = document.querySelector('.total-price')
            let totalPriceTo = Number(totalPrice.value) + Number(priceInput).toFixed(2)
            totalPrice.textContent = totalPriceTo;
            trElement.remove();
        });
        tdButtonsElement.appendChild(moreInfoBtn);
        tdButtonsElement.appendChild(deleteBtn);

        trElement.appendChild(tdModelElement)
        trElement.appendChild(tdPriceElement)
        trElement.appendChild(tdButtonsElement)
        trHideElement.appendChild(tdYearElement);
        trHideElement.appendChild(tdDescriptionElement);


        let tableElelement = document.getElementById('furniture-list');
        tableElelement.appendChild(trElement);
        tableElelement.appendChild(trHideElement);
    })

    function el(type, content, addClass) {
        const result = document.createElement(type);
        result.textContent = content;;
  
        if (addClass) {
           result.className = addClass;
        }
  
        return result;
     }
}
