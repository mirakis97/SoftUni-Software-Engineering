function solve() {
    students();
    document.getElementById('submit').addEventListener('click',createStudent)
}

solve();

async function createStudent(event) {
    event.preventDefault();
    const data = new FormData(event.target.parentNode);
    const firstName = data.get('firstName');
    const lastName = data.get('lastName');
    const facultyNumber = data.get('facultyNumber');
    const grade = data.get('grade');

    if (firstName === '' || lastName === '' || facultyNumber === '' || grade === ''|| isNaN(facultyNumber) || isNaN(grade)) {
        alert('Please enter a valid input');
        throw new Error('Please enter a valid input');
    }
    
    let newStudent = {
        facultyNumber,
        firstName,
        grade,
        lastName
    }
    await fetch("http://localhost:3030/jsonstore/collections/students", {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newStudent)
    });

    event.target.parentNode.reset();
    students();
}
async function students() {
    const body = document.querySelector('tbody');
    body.innerHTML= '';
    const url = "http://localhost:3030/jsonstore/collections/students";

    const response = await fetch(url);
    const data = await response.json();
    Object.values(data).map(appendStudents);
}

function appendStudents({firstName,lastName,facultyNumber,grade,_id}) {
    const body = document.querySelector('tbody');
    const tr = document.createElement('tr');
    tr.id = _id;

    const th1 = document.createElement('th');
    th1.textContent = firstName;
    const th2 = document.createElement('th');
    th2.textContent = lastName;
    const th3 = document.createElement('th');
    th3.textContent = facultyNumber;
    const th4 = document.createElement('th');
    th4.textContent = grade;

    tr.appendChild(th1);
    tr.appendChild(th2);
    tr.appendChild(th3);
    tr.appendChild(th4);

    body.appendChild(tr);
}


