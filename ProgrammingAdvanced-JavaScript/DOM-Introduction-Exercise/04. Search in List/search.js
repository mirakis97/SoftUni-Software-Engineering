function search() {

   const towns = document.querySelectorAll('#towns li');
   const input = document.getElementById('searchText').value;

   let count = 0;
   for (const town of towns) {
      if (town.textContent.toLowerCase().includes(input.toLowerCase())) {
         count++;
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
      }
   }


   document.getElementById('result').textContent = `${count} matches found`;
}
