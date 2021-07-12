import auth from "./services/authService.js";

let section = undefined;

export function initialize(domSection) {
    section = domSection;
    if (auth.isLoggedIn()) {
        this.loginUser();
    }else {
        this.logoutUser();
    }
}

export function logoutUser() {
    let userWelcome = section.querySelector('#user-welcome');
    userWelcome.textContent = 'Welcome, guest';
    let userLinks = [...section.querySelectorAll('.user')];
    userLinks.forEach(el => el.classList.add('hidden'));
    let guestLinks = [...section.querySelectorAll('.guest')];
    guestLinks.forEach(el => el.classList.remove('hidden'));
}

export function loginUser() {
    let userWelcome = section.querySelector('#user-welcome');
    userWelcome.textContent = `Welcome, ${auth.getUserName()}`;
    let userLinks = [...section.querySelector('.user')];
    userLinks.forEach(el => el.classList.remove('hidden'));
    let guestLinks = [...section.querySelectorAll('.guest')];
    guestLinks.forEach(el => el.classList.add('hidden'));
}

let nav = {
    initialize,
    loginUser,
    logoutUser
};

export default nav;