export function create(tag, attributesObj, ...params) {
    let element = document.createElement(tag);
    let text = params[0];
    if (params.length === 1 && typeof (text) !== 'object') {
        if (['input', 'textarea'].includes(tag)) {
            element.value = text;
        }
        else {
            element.textContent = text;
        }
    } else {
        params.forEach(e => {
            element.appendChild(e);
        });
    }

    if (attributesObj !== undefined) {
        Object.keys(attributesObj).forEach(key => {
            element.setAttribute(key, attributesObj[key]);
        })
    }

    return element;
}