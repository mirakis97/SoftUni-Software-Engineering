import auth from "../services/authService.js";
import viewFinder from "../viewFinder.js";


let section = undefined;

export function initialize(domElement) {
    section = domElement;
    let form = section.querySelector('form');
    form.addEventListener('submit',sendRegisterRequest);
}

export async function getView() {
    return section;
}

async function sendRegisterRequest(e) {
    e.preventDefault();
    try {
        let form = e.target;
        let formData = new FormData(form);

        let email = formData.get('email');
        let password = formData.get('password');
        let repeatPassword = formData.get('repeatPassword');

        if (email.trim() === '' || password.trim() === '') {
            alert('Fields cannot be empty');
            return;
        }
        if (password.length < 6) {
            alert('Password must be at least 6 characters');
            return;
        }
        if (password !== repeatPassword) {
            alert('Password don\'t match');
            return;
        }

        let registerUser = {
            email,
            password
        };

        await auth.register(registerUser);
        form.reset();
        viewFinder.navigateTo('home');
    } catch (err) {
        console.error(err);
        alert(err.message);
    }
}

let registerPage = {
    initialize,
    getView
}
export default registerPage;