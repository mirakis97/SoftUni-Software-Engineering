function attachEvents() {
    document.getElementById('submit').addEventListener('click', getWeather);
}

attachEvents();

async function getWeather(){
    const citys = {
        'New York': 'ny',
        'London': 'london',
        'Barcelona': 'barcelona'
    };

    const sym = {
        'Sunny': '&#x2600',
        'Partly sunny': '&#x26C5',
        'Overcast': '&#x2601',
        'Rain': '&#x2614',
        'Degree': '&#176',
    }

    const curDiv = document.getElementById('current');
    const nextDiv = document.getElementById('upcoming');
    const location = document.getElementById('location');
    const city = location.value;
    
    location.value = '';

    while (curDiv.children.length >= 1 && nextDiv.children.length >= 1){
        curDiv.removeChild(curDiv.lastChild);
        nextDiv.removeChild(nextDiv.lastChild);
    }

    const code = await getCode(city);

    const [curr,next] = await Promise.all([
        getCurr(code),
        getNext(code)
    ]);

    document.getElementById('forecast').style.display = 'block';

    const forecast = create('div',undefined,'forecasts');
    const condition = curr.forecast.condition;
    const spanConditionS = create('span',undefined, 'symbol');

    spanConditionS.innerHTML = sym[condition];

    forecast.appendChild(spanConditionS);
    curDiv.appendChild(forecast);

    const span = create('span',undefined,'condition');
    const spanCity = create('span', `${curr.name}`, 'forecast-data');
    const spanHighLow = create('span',undefined,'forecast-data');
    spanHighLow.innerHTML = `${curr.forecast.low}${sym.Degree}/${curr.forecast.high}${sym.Degree}`;
    const conditionSpan = create('span',`${curr.forecast.condition}`,'forecast-data');

    [spanCity,spanHighLow,conditionSpan].map((el) => span.appendChild(el));
    forecast.appendChild(span);

    const divForecastInfo = create('div',undefined,'forecast-info');
    nextDiv.appendChild(divForecastInfo);

    for (let index = 0; index < next.forecast.length; index++) {
        createSpan(next,index,sym).map(e => divForecastInfo.appendChild(e));
    }
}

async function getCode(city){
    try {
        const url = 'http://localhost:3030/jsonstore/forecaster/locations';
        const response = await fetch(url);
        const data = await response.json();

        return data.find((cur) => cur.name.toLowerCase() == city.toLowerCase()).code;
    } catch (error) {
        alert(error);
    }
}

async function getCurr(code){
    try {
        const url = 'http://localhost:3030/jsonstore/forecaster/today/'+ code;
        const response = await fetch(url);
        const data = await response.json();

        return data;
    } catch (error) {
        console.log(error);
    }
}

async function getNext(code){
    try {
        const url = 'http://localhost:3030/jsonstore/forecaster/upcoming/'+ code;
        const response = await fetch(url);
        const data = await response.json();

        return data;
    } catch (error) {
        console.log(error);
    }
}

function create(type,text,att) {
    const result = document.createElement(type);

    if (text) {
        result.textContent = text;
    }
    if (att) {
        result.className = att;
    }
    return result;
}

function createSpan(next,index,symbols) {
    const symbol = next.forecast[index].condition;
    const low = next.forecast[index].low;
    const high = next.forecast[index].high;


    const spanSymbol = create('span', undefined, 'symbol');
    spanSymbol.innerHTML = symbols[symbol];
    const highLow = create('span', undefined, 'forecast-data');
    highLow.innerHTML = `${low}${symbols.Degree}/${high}${symbols.Degree}`
    const condition = create('span',symbol , 'forecast-data');

    return [spanSymbol,highLow,condition]
}