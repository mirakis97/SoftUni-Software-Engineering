function addDestination() {
    const cityInput = document.querySelector('.inputData:nth-child(2)');
    const countryInput = document.querySelector('.inputData:nth-child(4)');
    const seasonInput = document.querySelector("#seasons");

    const city = document.querySelector('.inputData:nth-child(2)').value;
    const country = document.querySelector('.inputData:nth-child(4)').value;
    const season = document.querySelector("#seasons").value;

    const destinationsList = document.querySelector('#destinationsList');

    const springSummary = document.querySelector("#spring");
    const summerSummary = document.querySelector("#summer");
    const autumnSummary = document.querySelector("#autumn");
    const winterSummary = document.querySelector("#winter");

    if (city !== '' || country !== '') {
        let newTr = destinationsList.insertRow(-1);

        let tdItem1 = newTr.insertCell(0);

        tdItem1.textContent = `${city}, ${country}`;

        let tdItem2 = newTr.insertCell(1);
        let seasonText = season.charAt(0).toUpperCase() + season.slice(1);
        tdItem2.textContent = seasonText;

        if (seasonText === 'Spring') {
            springSummary.value++;
            
        } else if (seasonText === 'Summer') {
            summerSummary.value++;

        } else if (seasonText === 'Autumn') {
            autumnSummary.value++;

        } else if (seasonText === 'Winter') {
            winterSummary.value++;
        }


        cityInput.value = '';
        countryInput.value = '';
        seasonInput.value = '';
    }
}