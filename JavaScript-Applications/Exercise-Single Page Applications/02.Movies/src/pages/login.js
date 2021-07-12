import viewFinder from "../viewFinder.js";
import auth from "../services/authService.js";


let section = undefined;

export function initialize(domElement) {
    section = domElement;
    let form = section.querySelector('form');
    form.addEventListener('submit',sendLoginRequest);
}

export async function getView(id) {
    return section;
}

async function sendLoginRequest(e) {
    e.preventDefault();
    try {
       let form = e.target;
       let formData = new FormData(form);
       let id = formData.get('id');

        let email = formData.get('email');
        let password = formData.get('password');
        let loginUser = {
            email,
            password
        };

       await auth.login(loginUser)
       form.reset();
       viewFinder.navigateTo('home');
    } catch (err) {
        console.error(err);
        alert(err);
    }
}

let loginPage = {
    initialize,
    getView
}
export default loginPage;