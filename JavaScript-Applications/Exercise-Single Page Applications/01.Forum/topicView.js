let commentElement = document.querySelector('.comment');
let replyForm = document.querySelector('.answer form');
let commentsElement = document.querySelector('#user-comment');
let homeElement = document.querySelector('li a');

homeElement.addEventListener('click',goHome);
replyForm.addEventListener('submit',createReply);

fetch(`http://localhost:3030/jsonstore/collections/myboard/posts/${localStorage.getItem('topicId')}`)
.then(res => res.json())
.then(function (res) {
    commentElement.appendChild(createHtmlTopic(res));
});
fetch(`http://localhost:3030/jsonstore/collections/myboard/comments?where=postId%3D"${localStorage.getItem('topicId')}`)
.then(res => res.json())
.then(function (res) {
    Object.values(res).forEach(r => {
        commentElement.appendChild(createHtmlReply(r));
    })
});

function createReply(e) {
    e.preventDefault();
    let form = new FormData(replyForm);
    let comment = form.get('postText');
    let username = form.get('username');

    replyForm.reset();
    if (!username) {
        alert('Username cannot be empty!');
        return;
    }

    fetch('http://localhost:3030/jsonstore/collections/myboard/comments', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            username,
            comment,
            postId: localStorage.getItem('topicId')
        })
    })
        .then(res => res.json())
        .then(res => commentElement.appendChild(createHtmlReply(res)));
}

function createHtmlTopic(t) {
    let headersDivElemt = document.createElement('div');
    headersDivElemt.classList.add('header');

    let profilePicElement = document.createElement('img');
    profilePicElement.src ='./static/profile.png'
    profilePicElement.alt = 'avatar';

    let metaParagraphElement = document.createElement('p');
    let usernameSpanElement = document.createElement('span');
    usernameSpanElement.textContent = t.username;

    let timeElement = document.createElement('time');

    timeElement.textContent = getPostTime();
    metaParagraphElement.textContent = ' posted on ';
    metaParagraphElement.prepend(usernameSpanElement);
    metaParagraphElement.appendChild(timeElement);

    let contetnParagraph = document.createElement('p');
    contetnParagraph.classList.add('post-content');
    contetnParagraph.textContent = t.post;

    headersDivElemt.appendChild(profilePicElement);
    headersDivElemt.appendChild(metaParagraphElement);
    headersDivElemt.appendChild(contetnParagraph);

    return headersDivElemt;
}
function createHtmlReply(r) {
    let replyWrapperDiv = document.createElement('div');
    replyWrapperDiv.classList.add('topic-name-wrapper');

    let topicNameDiv = document.createElement('div');
    topicNameDiv.classList.add('topic-name');

    let infoParagraphElement = document.createElement('p');
    infoParagraphElement.textContent = ' commented on ';
    let nameStrong = document.createElement('strong');
    nameStrong.textContent = r.username;
    infoParagraphElement.prepend(nameStrong);
    let timeElement = document.createElement('time');
    timeElement.textContent = getReplyTime();
    infoParagraphElement.appendChild(timeElement);

    let contentDiv = document.createElement('div');
    contentDiv.classList.add('post-content');

    let contentParagraph = document.createElement('p');
    contentParagraph.textContent = r.comment;

    contentDiv.appendChild(contentParagraph);
    topicNameDiv.appendChild(infoParagraphElement);
    topicNameDiv.appendChild(contentParagraph);
    replyWrapperDiv.appendChild(topicNameDiv);

    return replyWrapperDiv;
}
function getPostTime() {
    let time = new Date();
    let year = time.getFullYear()
    let month = time.getMonth()
        .toString()
        .padStart(2, 0);

    let day = time.getDay()
        .toString()
        .padStart(2, 0);

    let hours = time.getHours() > 12 ? (time.getHours() - 12).toString().padStart(2, 0)
        : (time.getHours()).toString().padStart(2, 0);
    let minutes = time.getMinutes()
        .toString()
        .padStart(2, 0);

    let seconds = time.getHours()
        .toString()
        .padStart(2, 0);

    return `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`
}

function getReplyTime() {
    let time = new Date();
    let year = time.getFullYear();
    let month = time.getMonth();
    let day = time.getDay();
    let hours = time.getHours()
        .toString()
        .padStart(2, 0);

    let minutes = time.getMinutes()
        .toString()
        .padStart(2, 0);

    let seconds = time.getSeconds()
        .toString()
        .padStart(2, 0);

    let format = hours > 12 ? "PM" : "AM";

    return `${day}/${month}/${year}, ${hours}:${minutes}:${seconds} ${format}`;
}

function goHome(){
    location.assign('index.html');
}