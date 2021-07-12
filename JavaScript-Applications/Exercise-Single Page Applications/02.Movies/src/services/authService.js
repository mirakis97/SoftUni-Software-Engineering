import nav from "../nav.js";
import viewFinder from "../viewFinder.js";
import { jsonRequest } from "./httpService.js";

async function login(loginUser) {
    try {
        let loginResult = await jsonRequest('http://localhost:3030/users/login', 'Post', loginUser);
        localStorage.setItem('authToken', loginResult.accessToken);
        localStorage.setItem('userId', loginResult._id);
        localStorage.setItem('userName', loginResult.email);
        nav.loginUser();
    } catch (er) {
        alert(er);
    }
}

async function logout() {
    try {
        let logoutResult = await jsonRequest('http://localhost:3030/users/logout', 'Get', undefined, true, true);
        localStorage.removeItem('authToken');
        localStorage.removeItem('userId');
        localStorage.removeItem('userName');
        nav.logoutUser();
        return viewFinder.redirectTo('login');
    } catch (er) {
        alert(er);
    }
}

async function register(newUser) {
    try {
        let registerResult = await jsonRequest('http://localhost:3030/users/register', 'Post', newUser);
        localStorage.setItem('authToken', registerResult.accessToken);
        localStorage.setItem('userId', registerResult._id);
        localStorage.setItem('userName', registerResult.email);
        nav.loginUser();
    } catch (er) {
        alert(er);
    }
}

function  cleanStorage() {
    localStorage.clear();
}
function isLoggedIn() {
    return localStorage.getItem('authToken') !== null &&
        localStorage.getItem('authToken') !== undefined;
}

function getUserName() {
    return localStorage.getItem('userName');
}
function getUserId() {
    return localStorage.getItem('userId');
}
function getAuthToken() {
    return localStorage.getItem('authToken');
}

let auth = {
    login,
    register,
    logout,
    isLoggedIn,
    getUserName,
    getAuthToken,
    getUserId,
    cleanStorage
};

export default auth;