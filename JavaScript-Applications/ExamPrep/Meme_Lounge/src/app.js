import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';

import { logout as apiLogout } from './api/data.js'
import { homePage } from './pages/homePage.js';
import { loginPage } from './pages/loginPage.js';
//import { setUserNav } from './pages/navigation.js';
import { registerPage } from './pages/registerPage.js';
import { catalogPage } from './pages/catalogPage.js';
import { createPage } from './pages/createPage.js';
import { editPage } from './pages/editPage.js';
import { detailsPage } from './pages/detailsPage.js';
import { myPage } from './pages/profilePage.js';

const main = document.querySelector('main');
document.getElementById('logoutBtn').addEventListener('click', logout);
setUserNav();


page('/', decorationContext, homePage);
page('/login', decorationContext, loginPage);
page('/register', decorationContext, registerPage);
page('/catalog', decorationContext, catalogPage);
page('/create', decorationContext, createPage);
page('/edit/:id', decorationContext, editPage);
page('/details/:id', decorationContext, detailsPage);
page('/profile/', decorationContext, myPage);


page.start();

function decorationContext(ctx,next) {
    ctx.render = (content) => render(content, main);
    ctx.setUserNav = setUserNav;
    next();
}

function setUserNav() {
    const email = sessionStorage.getItem('email');

    if (email != null) {
        document.querySelector('div.profile > span').textContent = `Welcome, ${email}`
        document.querySelector('.user').style.display = '';
        document.querySelector('.guest').style.display = 'none';
    } else {
        document.querySelector('.user').style.display = 'none';
        document.querySelector('.guest').style.display = '';
    }
}


async function logout() {
    await apiLogout();
    setUserNav();
    page.redirect('/');
}