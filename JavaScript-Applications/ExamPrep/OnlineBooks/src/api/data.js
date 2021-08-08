import * as api from './api.js';

const host = 'http://localhost:3030'
api.settings.host = 'http://localhost:3030';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;



export async function getAllBooks() {
    return await api.get(host + `/data/books?sortBy=_createdOn%20desc`);
}

export async function createBook(obj) {
    return await api.post(host + `/data/books/`,obj);
}

export async function getBookById(id) {
    return await api.get(host + `/data/books/` + id);
}

export async function deleteBook(id) {
    return await api.del(host + `/data/books/` + id);
}

export async function editBookById(id, obj) {
    return await api.put(host + `/data/books/` + id, obj);
}

export async function getMyBooks(userId) {
    return await api.get(host + `/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function getLikesByBookId(bookId) {
    return await api.get(host + `/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`);
}

export async function getOwnLikesByBookId(bookId) {
    const userId = sessionStorage.getItem('userId');
    return await api.get(host + `:/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}