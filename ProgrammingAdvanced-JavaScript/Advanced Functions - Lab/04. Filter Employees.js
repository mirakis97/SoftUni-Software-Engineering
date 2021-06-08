function filter(data, criteria) {

    let employees = JSON.parse(data);

    if (criteria !== 'all') {

        let [criteriaKey, criteriaValue] = criteria.split('-');

        employees = employees.filter(emp => emp[criteriaKey] === criteriaValue);

    }

    let result = [];
    let count = 0;

    employees.map(emp => {
        result.push(`${count++}. ${emp.first_name} ${emp.last_name} - ${emp.email}`);
    });


    console.log(result.join('\n'));

}

const data = `[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`, 
'gender-Female'
