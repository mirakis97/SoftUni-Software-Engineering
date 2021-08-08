import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';

import { logout as logoutApi } from './api/api.js';
import { homePage } from './views/home.js';

import { getUserData } from './utility.js';
import { catalogPage } from './views/catalog.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { myListingsPage } from './views/my-listings.js';
import { searchPage } from './views/search.js';

const main = document.querySelector('main');
document.getElementById('logoutBtn').addEventListener('click', logout);
setUserNav();

page('/', decorateContext, homePage);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/catalog', decorateContext, catalogPage);
page('/create', decorateContext, createPage);
page('/details/:id', decorateContext, detailsPage);
page('/edit/:id', decorateContext, editPage);
page('/my-listings', decorateContext, myListingsPage);
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
        document.querySelector('#guest').style.display = 'none';
        document.querySelector('#profile').style.display = 'block';
        document.querySelector('#profile > a').textContent = `Welcome ${user.username}`;
    } else {
        document.querySelector('#guest').style.display = 'block';
        document.querySelector('#profile').style.display = 'none';
    }
}



async function logout() {
    await logoutApi();
    setUserNav();
    page.redirect('/');
}