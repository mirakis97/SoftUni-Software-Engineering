function attachEvents() {
    document.getElementById('submit').addEventListener('click',sendMessage);
    document.getElementById('refresh').addEventListener('click',getMessage);
}

attachEvents();


async function sendMessage() {
    const author = document.querySelector('input[name="author"]').value;
    const content = document.querySelector('input[name="content"]').value;

    if (author == '' || content == '') {
        return alert('All fields are required');
    }

    await fetch('http://localhost:3030/jsonstore/messenger',{
        method: 'post',
        headers: {'Content-Type': 'applications/json'},
        body: JSON.stringify({ author,content})
    });

    document.querySelector('input[name="author"]').value = '';
    document.querySelector('input[name="content"]').value = '';
    getMessage();
}

async function getMessage() {
    const response = await fetch('http://localhost:3030/jsonstore/messenger');
    const data = await response.json();

    const message = document.getElementById('messages');
    message.value = Object.values(data)
    .map((e) => `${e.author}: ${e.content}`)
    .join('\n');
    console.log(Object.values(data));
}