function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);


   function onClick() {

       const input = JSON.parse(document.querySelector('#inputs textarea').value);

       const allReastaurants = {};

       input.forEach(e => {

           const [restaurantName, restaurantData] = e.split(' - ');
           const workersData = restaurantData.split(', ');

           let workers = [];

           for (const data of workersData) {
               const [name, salary] = data.split(' ');

               const worker = {
                   name,
                   salary,
               }

               workers.push(worker);
           }

           if (allReastaurants[restaurantName]) {
               workers = workers.concat(allReastaurants[restaurantName].workers);
           };

           workers.sort((a, b) => b.salary - a.salary);

           const avgSalary = workers.reduce((sum, worker) => sum + Number(worker.salary), 0) / workers.length;

           const bestSalary = Number(workers[0].salary);


           allReastaurants[restaurantName] = {
               workers,
               avgSalary,
               bestSalary,
           }
       });


       let bestName = undefined;
       let bestSalary = 0;

       for (const restaurant in allReastaurants) {
           let currAvgSalary = allReastaurants[restaurant].avgSalary;

           if (allReastaurants[restaurant].avgSalary > bestSalary) {
               bestSalary = currAvgSalary;
               bestName = restaurant;
           }
       }

       const bestRestaurant = allReastaurants[bestName];

       const restaurantOutput = document.querySelector('#bestRestaurant>p');

       restaurantOutput.textContent =
           `Name: ${bestName} Average Salary: ${bestRestaurant.avgSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

       const workersOutput = document.querySelector('#workers>p');

       let workersText = [];

       bestRestaurant.workers.forEach(w => {
           workersText.push(`Name: ${w.name} With Salary: ${w.salary}`)
       });


       workersOutput.textContent = workersText.join(' ');

   }
}