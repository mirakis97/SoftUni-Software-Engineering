function lockedProfile() {

}
async function profil() {
    const url = `http://localhost:3030/jsonstore/advanced/profiles`;

    const response = await fetch(url);
    const data = await response.json();

    Object.values(data).map(({age, email, username, _id}) => {
        createProfile(age,email,username, _id);
    });
}

function createProfile(age, email, username, id) {
    const main = document.getElementById('main');
    const div = create('div',undefined,'profile');
    const img = create('img',undefined,'userIcon',undefined, './iconProfile2.png');
    const leabelOne = create('label','Lock');
    const inputOne = create('input',undefined,undefined,undefined,undefined,'radio','user1Locked','lock',['checked']);
    const leabelTwo = create('label','Unlock');
    const inputTwo = create('input',undefined,undefined,undefined,undefined,'radio','user1Locked','unlock');
    const br = create('br');
    const hr = create('hr');
    const leabelThree = create('label','Username');
    const inputThree = create('input',undefined,undefined,undefined,undefined,'text','user1Username',`${username}`,['disabled', 'readonly']);
    const divTwo = create('div',undefined, undefined,'user1HiddenFields');
    const hrTwo = create('hr');
    const leabelFour = create('label','Email');
    const inputFour = create('input',undefined,undefined,undefined,undefined,'email','user1Email',`${email}`,['disabled', 'readonly']);
    const leabelFive = create('label','Age');
    const inputFive = create('input',undefined,undefined,undefined,undefined,'text','user1Age',`${age}`,['disabled', 'readonly']);

    const btn = create('button', 'Show more');
    btn.addEventListener('click', (e) => show(e));
    divTwo.appendChild(hrTwo);
    divTwo.appendChild(leabelFour);
    divTwo.appendChild(inputFour);
    divTwo.appendChild(leabelFive);
    divTwo.appendChild(inputFive);
    div.appendChild(img);
    div.appendChild(leabelOne);
    div.appendChild(inputOne);
    div.appendChild(leabelTwo);
    div.appendChild(inputTwo);
    div.appendChild(br);
    div.appendChild(hr);
    div.appendChild(leabelThree);
    div.appendChild(inputThree);
    div.appendChild(divTwo);
    div.appendChild(btn);
    main.appendChild(div);

}
function show(e) {
    const locked = document.querySelector('input[type="radio"]:checked').value === 'lock';
    const profile = e.target.parentNode;
    if (locked) {
        return;
    }

    let div = profile.querySelector('div');
    let visible = div.style.display === 'block';
    div.style.display = visible ? 'none' : 'block';
    e.target.textContent = !visible ? "Hide it" : 'Show more';
}

function create(type,content, className, id, image, attrType, attrName, val, attr) {
    let element = document.createElement(type);

    if (content) {
        element.textContent = content;
    }
    if (className) {
        element.className = className;
    }
    if (id) {
        element.id = id;
    }
    if (image) {
        element.src = image;
    }
    if (attrType) {
        element.type = attrType;
    }
    if (attrName) {
        element.name = attrName;
    }
    if (val) {
        element.value = val;
    }
    if (attr) {
        for (let i = 0; i < attr.length; i++) {
            element.addAtribute = attr[i];
        }
    }
   return element;
}

profil();