function solve() {
    const spawn = document.querySelector('span[class="info"]')
    const departButton = document.getElementById('depart');
    const arriveButton = document.getElementById('arrive');
    
    console.log(spawn);
    let stop = {
        next: 'depot'
    }
    async function depart() {
        const url = `http://localhost:3030/jsonstore/bus/schedule/` + stop.next;
        const response = await fetch(url);
        const data = await response.json();

        stop = data;
        spawn.textContent = `Next stop ${stop.name}`;
        departButton.disabled = true;
        arriveButton.disabled = false;
    }

    async function arrive() {
        spawn.textContent = `Arriving at ${stop.name}`;


        departButton.disabled = false;
        arriveButton.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();