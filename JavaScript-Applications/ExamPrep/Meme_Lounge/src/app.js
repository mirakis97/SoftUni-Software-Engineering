import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';

import { homePage } from './pages/homePage.js';
import { loginPage } from './pages/loginPage.js';
import { setUserNav } from './pages/navigation.js';

const main = document.querySelector('main');

setUserNav();

page('/', decorationContext,homePage);
page('/login', decorationContext,loginPage);

page.start();

function decorationContext(ctx,next) {
    ctx.render = (content) => render(content, main);
    ctx.setUserNav = setUserNav;
    next();
}