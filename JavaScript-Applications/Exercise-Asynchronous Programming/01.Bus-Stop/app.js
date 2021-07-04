async function getInfo() {
    // const submitButton = document.getElementById('submit');
    const input  = document.getElementById('stopId');
    const id = input.value;

    const url = `http://localhost:3030/jsonstore/bus/businfo/` + id;

    const buses = document.getElementById('buses');

    buses.innerHTML = '';

    try{
        const response = await fetch(url);
        const data = await response.json();

        document.getElementById('stopName').textContent = data.name;

        Object.entries(data.buses).map(([bus,time]) => {
            const li = document.createElement('li');
            li.textContent = `Bus ${bus} arrives in ${time} minutes`;

            buses.appendChild(li);
        });
    }catch (error){
        document.getElementById('stopName').textContent = 'Error';
    }
}
  