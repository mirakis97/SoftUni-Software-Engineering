import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';
import { getUserData } from './utility.js';

import { logout as logoutApi } from './api/api.js';
import { dashboardPage } from './views/catalog.js';
import { loginPage } from './views/auth.js';
import { registerPage } from './views/auth.js';
import { detailsPage } from './views/details.js';
import { createBook } from './api/data.js';
import { editPage } from './views/edit.js';
import { myListingsPage } from './views/myBooks.js';

const main = document.querySelector('main');
document.getElementById('logoutBtn').addEventListener('click', logout);
setUserNav();

page('/dashboard', decorateContext, dashboardPage);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/details/:id', decorateContext, detailsPage);
page('/create', decorateContext, createBook);
page('/edit/:id', decorateContext, editPage);
page('/my-books', decorateContext, myListingsPage);


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
        document.getElementById('guest').style.display = 'none';
        document.getElementById('user').style.display = 'block';
        document.getElementById('text').textContent = `Welcome ${user.email}`;
    } else {
        document.getElementById('guest').style.display = 'block';
        document.getElementById('user').style.display = 'none';
    }
}



async function logout() {
    await logoutApi();
    setUserNav();
    page.redirect('/');
}