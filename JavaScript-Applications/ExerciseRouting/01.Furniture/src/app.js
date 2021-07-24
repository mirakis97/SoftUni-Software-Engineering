import { render } from '../node_modules/lit-html/lit-html.js'
import page from '../node_modules/page/page.mjs';

import { logout } from './helpers/data.js';
import { loginPage } from "./logic/login.js";
import { registerPage } from "./logic/register.js";
import { dashboardPage } from "./logic/dashboard.js";
import { createPage } from "./logic/create.js";
import { detailsPage } from "./logic/details.js";
import { editPage } from "./logic/edit.js";
import { myFurniturePage } from "./logic/myFurniture.js";

const conteiner = document.querySelector('.container');

page('/',renderMid,dashboardPage);
page('/dashboard',renderMid,dashboardPage);
page('/login',renderMid,loginPage);
page('/register',renderMid,registerPage);
page('/create',renderMid,createPage);
page('/details/:id',renderMid,detailsPage);
page('/edit/:id',renderMid,editPage);
page('/my-furniture',renderMid,myFurniturePage);

document.getElementById('logoutBtn').addEventListener('click', async() =>{
    await logout();
    setUserNav();
    page.redirect('/');
    console.log(sessionStorage.length);
    
});
setUserNav();
page.start();

function renderMid(context,next) {
    context.render = (context) => render(context,conteiner);
    context.setUserNav = setUserNav;
    next();
}

export function setUserNav() {
    const userId = sessionStorage.getItem('userId');
    if (userId != null) {
        document.getElementById('guest').style.display = 'none';
        document.getElementById('user').style.display = 'inline-block';
    }else{
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'inline-block';
    }
}

