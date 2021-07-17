export function createHomeViewTopic(t) {
    let topicWrapper = document.createElement('div');
    topicWrapper.classList.add('topic-name-wrapper');

    let topicNameDiv = document.createElement('div');
    topicNameDiv.classList.add('topic-name');

    let anchorElement = document.createElement('a');
    anchorElement.href = '#';
    anchorElement.id = t._id;
    anchorElement.classList.add = ('normal');
    anchorElement.addEventListener('click',openPage);

    let h2Element = document.createElement('h2');
    h2Element.textContent = t.title;

    let columsDiv = document.createElement('div');
    columsDiv.classList.add('colums');

    let simpleDiv = document.createElement('div');

    let dateParagraph = document.createElement('p');
    dateParagraph.textContent = 'Date: ';
    let timeElement = document.createElement('time');
    timeElement.textContent = getTimeHomeFormat();
    dateParagraph.appendChild(timeElement);
    let nickNameDiv = document.createElement('div');
    nickNameDiv.classList.add('nick-name');
    let nickParagraph = document.createElement('p');
    nickParagraph.textContent = "Username: ";
    let span = document.createElement('span');
    span.textContent = t.username;

    nickParagraph.appendChild(span);
    nickNameDiv.appendChild(nickParagraph);

    simpleDiv.appendChild(span);
    simpleDiv.appendChild(nickNameDiv);

    columsDiv.appendChild(simpleDiv);

    anchorElement.appendChild(h2Element);

    topicNameDiv.appendChild(anchorElement);
    topicNameDiv.appendChild(columsDiv);

    topicWrapper.appendChild(topicNameDiv);

    return topicWrapper;
}

function openPage(e) {
    e.preventDefault();
    
    let headline = e.target.parentElement;
    console.log(headline);
    let selectedId = headline.id;

    localStorage.setItem('topicId', selectedId);
    location.assign('theme-content.html');
}

export function getTimeHomeFormat() {
    let time = new Date();
    let year = time.getFullYear();
    let month = time.getMonth().toString().padStart(2,0);

    let day = time.getDay().toString().padStart(2,0);
    let hours = time.getHours() > 12 ? (time.getHours() - 12).toString().padStart(2,0) 
    : (time.getHours()).toString().padStart(2,0);

    let minutes = time.getMinutes().toString().padStart(2,0);
    let seconds = time.getSeconds().toString().padStart(2,0);
    
    let miliseconds = time.getMilliseconds().toString().padStart(3,0);

    return `${year}-${month}-${day}T${hours}:${minutes}:${seconds}.${miliseconds}Z`;
}

const homeModule = {
    getTimeHomeFormat,
    createHomeViewTopic,
}

export default homeModule;