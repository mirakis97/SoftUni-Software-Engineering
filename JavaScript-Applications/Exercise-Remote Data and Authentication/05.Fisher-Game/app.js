
let loadBtn = document.querySelector('main aside .load').addEventListener('click', getAllCatches)
let catchConteiner = document.getElementById('catches');
catchConteiner.querySelectorAll('.catch').forEach(x => x.remove());
let addButton = document.querySelector('#addForm . add');
addButton.disabled = localStorage.getItem('token') === null;
addButton.addEventListener('click', createCatch);


async function getAllCatches() {
    let url = `http://localhost:3030/data/catches`;
    const data = await fetch(url);
    const cathces = await data.json();

    catchConteiner.querySelectorAll('.catch').forEach(x => x.remove());
    catchConteiner.append(...cathces.map(c => createElement(e)))
}
async function login() {

}

async function createElement(object) {
    let angler = document.querySelector('#addForm .angler');
    let weight = document.querySelector('#addForm .weight');
    let species = document.querySelector('#addForm .species');
    let location = document.querySelector('#addForm .location');
    let bait = document.querySelector('#addForm .bait');
    let captureTime = document.querySelector('#addForm .captureTime');

    let newFish = {
        angler: angler.value,
        weight: Number(weight.value),
        species: species.value,
        location: location.value,
        bait: bait.value,
        captureTime: Number(captureTime.value)
    };

    let createResponse = await fetch(`http://localhost:3030/data/catches`, {
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('token')
        },
        method: 'Post',
        body: JSON.stringify(newFish)
    });

    let result = await createResponse.json();
    let createCatch = createHtmlCatch(result);
    catchConteiner.appendChild(createCatch);
}
async function newCatch(e) {
    let currCatch = e.target.parentElement;
    let currAngler = currCatch.querySelector('.angler');
    let currWeight = currCatch.querySelector('.weight');
    let currSpecies = currCatch.querySelector('.species');
    let currLocation = currCatch.querySelector('.location');
    let currBait = currCatch.querySelector('.bait');
    let currCaptureTime = currCatch.querySelector('.captureTime');

    let updateCatch = {
        angler: currAngler.value,
        weight: Number(currWeight.value),
        species: currSpecies.value,
        location: currLocation.value,
        bait: currBait.value,
        captureTime: Number(currCaptureTime.value)
    };

    let id = currCatch.dataset.id;
    let url = `http://localhost:3030/data/catches${id}`;
    let updateResponse = await fetch(url,{
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('token')
        },
        method: 'Put',
        body: JSON.stringify(updateCatch)
    });
    let result = await updateResponse.json();
}
async function deleteCatch(e) {
    let curFish = e.target.parentElement;
    let id = curFish.dataset.id;
    let url = `http://localhost:3030/data/catches${id}`;
    let deleteResponse = await fetch(url, {
        headers:{
            'X-Authorization': localStorage.getItem('token')
        },
        method: 'Delete'
    });
    let result = await deleteResponse.json();
    if (deleteResponse === 200) {
        curFish.remove();
    }
}
function createHtmlCatch(curFish) {
    let anglerLable = Create('lable',undefined, 'Angler');
    let inputAngler = Create('input',{type: 'text',class:'angler'},curFish.angler);
    let hr1 = Create('hr');
    let weightLabel = Create('lable',undefined, 'Weight');
    let weightInput = Create('input',{type: 'number',class:'weight'},curFish.weight);
    let hr2 = Create('hr');
    let speciesLabel = Create('lable',undefined, 'Species');
    let speciesInput = Create('input',{type: 'text',class:'species'},curFish.species);
    let hr3 = Create('hr');
    let locationLabel = Create('lable',undefined, 'Location');
    let locationInput = Create('input',{type: 'text',class:'location'},curFish.location);
    let hr4 = Create('hr');
    let baitLabel = Create('lable',undefined, 'Bait');
    let baitInput = Create('input',{type: 'text',class:'bait'},curFish.bait);
    let hr5 = Create('hr');
    let captureTime = Create('lable',undefined, 'Capture Time');
    let captureTimeInput = Create('input',{type: 'number',class:'captureTime'},curFish.captureTime);
    let hr6 = Create('hr');


    let newDiv = Create('div', {class:'catch'},
    anglerLable,inputAngler,hr1,weightLabel,weightInput,hr2,speciesLabel,
    speciesInput,hr3,locationLabel,locationInput,hr4,baitLabel,baitInput,
    hr5,captureTime,captureTimeInput,hr6);
    newDiv.dataset.id = curFish._id;
    newDiv.dataset.ownerId = curFish._ownerId;
    return newDiv;
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
