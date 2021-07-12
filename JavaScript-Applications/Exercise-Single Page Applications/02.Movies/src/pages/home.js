import { ce } from "../helpers/htmlHelpers.js";
import auth from "../services/authService.js";
import { jsonRequest } from "../services/httpService.js";
import viewFinder from "../viewFinder.js";

let section = undefined;
let addMovieBtn = undefined

export function initialize(domSection) {
    section = domSection;
    addMovieBtn = section.querySelector('#add-movie-btn');
}

export async function getView() {
    await populateMovies();
    return section;
}

async function populateMovies() {
    try{
        let url = 'http://localhost:3030/data/movies';
        let movies = await jsonRequest(url, 'GET');
        console.log(movies);
        let moviesContainer = section.querySelector('#home-movies-container');
        moviesContainer.querySelectorAll('.movie').forEach(m => m.remove());
        if(!auth.isLoggedIn()) {
            addMovieBtn.remove();
        } else {
            let moviesHeading = section.querySelector('#movies-heading');
            moviesHeading.after(addMovieBtn);
        }
        moviesContainer.append(...movies.map(m => createHtmlMovie(m)));
    } catch(err){
        console.error(err);
        alert(err);
    }
}

function createHtmlMovie(movie) {
    let movieImg = ce('img', { class: 'card-img-top', src: movie.img, alt: 'Card image cap', width: '400' });
    let cardBodyDiv = ce('div', { class: 'card-body' }, ce('h4', { class: 'card-title' }, movie.title));

    let detailsButton = ce('button', { type: 'button', class: 'btn btn-info' }, 'Details');
    let linkAnchor = ce('a', { class: 'link', "data-route": `details/${movie._id}`, href: `#/details/${movie._id}` });
    if(auth.isLoggedIn()){
        linkAnchor.appendChild(detailsButton);
    }
    linkAnchor.addEventListener('click', viewFinder.navigationHandler);
    let cardFooterDiv = ce('div', { class: 'card-footer' }, linkAnchor);

    let movieCardDiv = ce('div', { class: 'card mb-4 movie' }, movieImg, cardBodyDiv, cardFooterDiv);
    return movieCardDiv;
}

let homePage = {
    initialize,
    getView
}

export default homePage;