import * as api from './api/api.js';
import { getUserData } from './utility.js';
import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';
import {logout as apiLogout } from './api/api.js';


import { homePage } from './pages/home.js';
import { loginPage, registerPage } from './pages/auth.js';
import { catalogPage } from './pages/catalog.js';
import { createPage } from './pages/create.js';
import { editPage } from './pages/edit.js';
import { detailsPage } from './pages/details.js';
import { profilePage } from './pages/profile.js';
import { searchPage } from './pages/search.js';


api.settings.host = 'http://localhost:3030';
window.api = api;
const main = document.getElementById('site-content');

document.getElementById('logoutBtn').addEventListener('click', logout);
setUserNav();

page('/', decorateContext, homePage);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/all-listings', decorateContext, catalogPage);
page('/details:id', decorateContext, detailsPage);
page('/create', decorateContext, createPage);
page('/edit:id', decorateContext, editPage);
page('/my-listings', decorateContext, profilePage);
page('/search', decorateContext, searchPage);

page.start();


function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setUserNav = setUserNav;
    ctx.user = getUserData();
    next();
}

function setUserNav() {
    const user = getUserData();
    if (user) {
        document.getElementById('profile').style.display = 'block';
        document.getElementById('guest').style.display = 'none';
        document.getElementById('user-greeting').textContent = `Welcome ${user.username}`;
    } else {
        document.getElementById('profile').style.display = 'none';
        document.getElementById('guest').style.display = 'block';
    }
}


async function logout(){
    await apiLogout();
    setUserNav();
    page.redirect('/');
}