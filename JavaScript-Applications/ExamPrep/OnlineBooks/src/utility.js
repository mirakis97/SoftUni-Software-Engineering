export function getUserData() {
    const user = sessionStorage.getItem('user');

    if (user) {
        return JSON.parse(user);
    } else {
        return undefined;
    }
}


export async function setUserData(data) {
    sessionStorage.setItem('user', JSON.stringify(data));
}

export async function clearUserData() {
    sessionStorage.removeItem('user');
}