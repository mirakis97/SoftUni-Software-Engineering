export const settings = { host: '' };

export async function get(url) {
    return await request(url,getOption())
}
export async function post(url, data) {
    return await request(url,getOption('post',data))
}
export async function put(url, data) {
    return await request(url,getOption('put',data))
}
export async function del(url) {
    return await request(url,getOption('delete'))
}

export async function login(email, password) {
    const result = await post(settings.host + '/users/login', { email, password});

    sessionStorage.setItem('userId',result._id);
    sessionStorage.setItem('email',result.email);
    sessionStorage.setItem('authToken',result.accessToken);
    return result;
}
export async function register(email, password) {
    const result = await post(settings.host + '/users/register', { email, password});

    sessionStorage.setItem('userId',result._id);
    sessionStorage.setItem('email',result.email);
    sessionStorage.setItem('authToken',result.accessToken);
    return result;
}
export async function logout() {
    const result = await post(settings.host + '/users/logout');

    sessionStorage.removeItem('userId',result._id);
    sessionStorage.removeItem('email',result.email);
    sessionStorage.removeItem('authToken',result.accessToken);
    return result;
}
export async function request(url,options) {
    try {
        const response = await fetch(url,options);

        if (response.ok == false) {
            const error = await response.json();
            throw new Error(error.message)
        }
        try {
            return await response.json();
        } catch (err) {
            return response
        }
    } catch (error) {
        alert(error.message)
    }
}
function getOption(method = 'get', body) {
    const options = {
        method,
        headers: {},
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