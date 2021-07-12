import { jsonRequest } from "../services/httpService.js";
import viewFinder from "../viewFinder.js";
import { ce } from "../helpers/htmlHelpers.js";
import auth from "../services/authService.js";

let section = undefined;
let linkClass = undefined;

export function initialize(domSection, viewLinkClass) {
    section = domSection;
    linkClass = viewLinkClass;
}

export async function getView(movieId) {
    try {
        let moviePromise = jsonRequest(`http://localhost:3030/data/movies/${movieId}`);
        let userId = auth.getUserId();
        let userLikesPromise = jsonRequest(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${userId}%22`);
        let likesPromise = jsonRequest(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22&distinct=_ownerId&count`);
        let [movie, userLikesArr, likes] = await Promise.all([moviePromise, userLikesPromise, likesPromise]);

        let userCanLike = true;
        if (userLikesArr.length > 0 || auth.getUserId() === movie._ownerId) {
            userCanLike = false;
        }

        let htmlMovie = createHtmlMovieInfo(movie, userCanLike, likes);
        let movieContainer = section.querySelector('.container');
        movieContainer.querySelectorAll('.movie-details').forEach(e => e.remove());
        movieContainer.appendChild(htmlMovie);
        return section;
    } catch (err) {
        console.error(err);
        alert(err);
    }
}

export async function deleteMovie(movieId) {
    try {
        let deleteResult = await jsonRequest(`http://localhost:3030/data/movies/${movieId}`, 'Delete', undefined, true);
        return viewFinder.redirectTo('home');
    } catch (err) {
        console.error(err);
        alert(err);
    }
}

export async function likeMovie(movieId) {
    try {
        let body = { movieId: movieId };
        let likeResult = await jsonRequest(`http://localhost:3030/data/likes`, 'Post', body, true);
        let movieLikes = await jsonRequest(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22&distinct=_ownerId&count`);

        let likeBtn = section.querySelector('.like');
        likeBtn.remove();
        let likesSpan = section.querySelector('.likes');
        likesSpan.textContent = `Liked: ${movieLikes}`;
        return viewFinder.redirectTo('details', movieId);
    } catch (err) {
        console.error(err);
        alert(err);
    }
}

function createHtmlMovieInfo(movie, userCanLike, movieLikes) {
    let movieHeading = ce('h1', undefined, `Movie title: ${movie.title}`);

    let movieImage = ce('img', { class: 'img-thumbnail', src: movie.img, alt: 'Movie' });
    let imageDiv = ce('div', { class: 'col-md-8' }, movieImage);

    let descriptionHeading = ce('h3', { class: 'my-3' }, 'Movie Description');
    let descriptionP = ce('p', undefined, movie.description);
    let deleteBtn = ce('a', { class: `btn btn-danger delete ${linkClass}`, 'data-route': `delete/${movie._id}`, href: `#/delete/${movie._id}` }, 'Delete');
    deleteBtn.addEventListener('click', viewFinder.navigationHandler);
    let editBtn = ce('a', { class: `btn btn-warning ${linkClass}`, 'data-route': `edit/${movie._id}`, href: `#/edit/${movie._id}` }, 'Edit');
    editBtn.addEventListener('click', viewFinder.navigationHandler);
    let likeBtn = ce('a', { class: `btn btn-primary like ${linkClass}`, 'data-route': `like/${movie._id}`, href: `#/like/${movie._id}` }, 'Like');
    likeBtn.addEventListener('click', viewFinder.navigationHandler);
    let likesSpan = ce('span', { class: 'enrolled-span likes' }, `Liked: ${movieLikes}`);
    let descriptionDiv = ce('div', { class: 'col-md-4 text-center' },
        descriptionHeading, descriptionP);

    if (auth.getUserId() === movie._ownerId) {
        descriptionDiv.appendChild(deleteBtn);
        descriptionDiv.appendChild(editBtn);
    }

    if (userCanLike) {
        descriptionDiv.appendChild(likeBtn);
    }

    descriptionDiv.appendChild(likesSpan);

    let movieDiv = ce('div', { class: 'row bg-light text-dark movie-details', 'data-id': `${movie._id}` },
        movieHeading, imageDiv, descriptionDiv);

    return movieDiv;
}

let movieDetailsPage = {
    initialize,
    getView,
    likeMovie,
    deleteMovie
}

export default movieDetailsPage;