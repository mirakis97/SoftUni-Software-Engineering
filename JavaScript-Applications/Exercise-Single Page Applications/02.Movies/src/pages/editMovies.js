import viewFinder from "../viewFinder.js";
import { jsonRequest } from "../services/httpService.js";


let section = undefined;

export function initialize(domElement) {
    section = domElement;
    let form = section.querySelector('form');
    form.addEventListener('submit',editMovie);
}

export async function getView(id) {
    try {
        let movie = await jsonRequest(`http://localhost:3030/data/movies/${id}`);
        let titleInput = section.querySelector('input[name="title"]');
        let descriptionTextarea = section.querySelector('textarea[name="description"]');
        let imageInput = section.querySelector('input[name="imageUrl"]');
        let idInput = section.querySelector('input[name="id"]');

        titleInput.value = movie.title;
        descriptionTextarea.value = movie.description;
        imageInput.value = movie.img;
        idInput.value = id;
        return section;
    } catch (err) {
        alert(err);
    }
}

async function editMovie(e) {
    e.preventDefault();
    try {
       let form = e.target;
       let formData = new FormData(form);
       let id = formData.get('id');

       let editedMovie = {
           title: formData.get('title'),
           description: formData.get('description'),
           img: formData.get('imageUrl')
       }

       let updateResult = await jsonRequest(`http://localhost:3030/data/movies/${id}`, 'Put', editedMovie, true);
       console.log(updateResult);
       form.reset();
       console.log(`details/${id}`);
       viewFinder.navigateTo('details', id);
    } catch (err) {
        console.error(err);
        alert(err.message);
    }
}

let editedMoviePage = {
    initialize,
    getView
}
export default editedMoviePage;