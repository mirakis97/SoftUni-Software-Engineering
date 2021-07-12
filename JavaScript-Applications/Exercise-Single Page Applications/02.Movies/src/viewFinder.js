import addMoviePage from "./pages/addMovie.js";
import editMoviePage from "./pages/addMovie.js";
import homePage from "./pages/addMovie.js";
import loginPage from "./pages/addMovie.js";
import movieDetailsPage from "./pages/addMovie.js";
import registerPage from "./pages/addMovie.js";
import auth from "./pages/addMovie.js";


let sections = {
    'home': async () => await homePage.getView(),
    'register': async () => await registerPage.getView(),
    'login': async () => await loginPage.getView(),
    'add-movie': async () => await addMoviePage.getView(),
    'edit': async () => await editMoviePage.getView(id),
    'details': async () => await movieDetailsPage.getView(id),
    'logout': async () => await auth.logout(),
    'delete': async () => await movieDetailsPage.deleteMovie(id),
    'like': async () => await movieDetailsPage.likeMovie(id),
};

let getViewCallback = undefined;
let linkRouteSelector = undefined;

export function initialize(linkElements, linkSelector, callback) {
    linkRouteSelector = linkSelector;
    linkElements.forEach(el => el.addEventListener('click', navigationHandler));
    getViewCallback = callback;
}

export function navigationHandler(e) {
    let element = e.target.matches(linkRouteSelector)
    ? e.target
    : e.currentTarget.closest(linkRouteSelector);
    if (element.dataset.route !== undefined) {
        let [route,id] = element.dataset.route.split('/');
        navigateTo(route, id);
    }
}

export function navigateTo(route,id) {
    if (sections[route] !== undefined) {
        let viewPromise = sections[route](id);
        getViewCallback(viewPromise);
    }
}

export function redirectTo(route,id) {
    if (sections[route] !== undefined) {
        let viewPromise = sections[route](id);
        location.hash = `/${route}${id !== undefined ? `${id}`: ''}`;
        return viewPromise;
    }
}

let viewFinder = {
    navigateTo,
    redirectTo,
    navigationHandler,
    initialize
}

export default viewFinder;