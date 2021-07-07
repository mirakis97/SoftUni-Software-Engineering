let register = document.getElementById('register-form');
register.addEventListener('submit',newRegister);
let loginForm = document.getElementById('login-form');
loginForm.addEventListener('submit',login);

async function newRegister(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);

    let password = formData.get('password');
    let repeatPassword = formData.get('rePass');

    if (password !== repeatPassword) {
        console.error('Password dont`t match');
        return;
    }

    let newUser = {
        email: formData.get('email'),
        password: password
    }

    let registerResponse = await fetch(`http://localhost:3030/users/register`,{
        headers: { 'Content-Type': 'application/json' },
        method: 'Post',
        body: JSON.stringify(newUser)
    });

    let registerResult = await registerResponse.json();

    localStorage.setItem('token', registerResult.accessToken);
    localStorage.setItem('userId', registerResult._id);
    location.assign('./index.html');
}


async function login(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);

    let password = formData.get('password');

    let loginUser = {
        email: formData.get('email'),
        password: password
    }

    let loginResponse = await fetch(`http://localhost:3030/users/login`,{
        headers: {
            'Content-Type': 'application/json'
        },
        method: 'Post',
        body: JSON.stringify(loginUser)
    });
    let result = await loginResponse.json();

    localStorage.setItem('token', result.accessToken);
    localStorage.setItem('userId', result._id);
    location.assign('./index.html');
}