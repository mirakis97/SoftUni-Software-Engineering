import * as api from './api.js';

const host = 'http://localhost:3030'
api.settings.host = 'http://localhost:3030';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;



export async function getAllListings() {
    return await api.get(host + `/data/cars?sortBy=_createdOn%20desc`);
}

export async function createListing(obj) {
    return await api.post(host + `/data/cars`, obj);
}

export async function getCarById(id) {
    return await api.get(host + `/data/cars/` + id);
}

export async function deleteCar(id) {
    return await api.del(host + `/data/cars/` + id);
}

export async function editCarById(id, obj) {
    return await api.put(host + `/data/cars/` + id, obj);
}

export async function getMyListings(userId) {
    return await api.get(host + `/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function getAllListingsByYear(query) {
    return await api.get(host + `/data/cars?where=year%3D${query}`);
}