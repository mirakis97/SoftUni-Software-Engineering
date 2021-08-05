export const settings = {
    host: ''
};

async function request(url , options) {
    try {
        const response = await fetch(url,options);

        if (!response.ok) {
            const messageError = await response.json();
            throw new Error(messageError.mesage);
        }

        try {
            const data = await response.json();
            return data;
        } catch (error) {
            return response;
        }
    } catch (error) {
        alert(error.mesage);
        throw error;
    }
}

function getOptions(method = 'GET', body) {
    const options = {
        method,
        headers: {}
    };

    const token = sessionStorage.getItem('authToken');
    if (token != null) {
        options.headers['X-Authorization'] = token;
    }

    if (body) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }

    return options;
}

export async function get(url) {
    return await request(url,getOptions());
}
export async function put(url, data) {
    return await request(url,getOptions('PUT', data));
}
export async function post(url, data) {
    return await request(url,getOptions('POST', data));
}
export async function del(url) {
    return await request(url, getOptions('DELETE'));
}

export async function register(username, email, password, gender) {
    const result = await post(settings.host + '/users/register', {username,email,password,gender});

    sessionStorage.setItem('username',result.username);
    sessionStorage.setItem('email',result.email);
    sessionStorage.setItem('authToken',result.accessToken);
    sessionStorage.setItem('userId',result._id);
    sessionStorage.setItem('userGender',result.gender);

    return result;
}

export async function login(email, password) {
    const result = await post(settings.host + '/users/login', {email, password});

    sessionStorage.removeItem('username',result.username);
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('authToken');
    sessionStorage.removeItem('userId');
    sessionStorage.removeItem('userGender')

    return result;
}

export async function logout() {
    const result = await post(settings.host + '/users/logout');

    sessionStorage.removeItem('username',result.username);
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('authToken');
    sessionStorage.removeItem('userId');
    sessionStorage.removeItem('userGender')

    return result;
}