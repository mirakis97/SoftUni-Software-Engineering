function solve() {

  let text = [...document.getElementById('text').value.split(' ')].map(w => w.toLowerCase());
  let currCase = document.getElementById('naming-convention').value;
  let res;

  if (currCase !== 'Camel Case' && currCase != 'Pascal Case') {
      document.getElementById('result').textContent = 'Error!';
  } else {

      res = text.map(w => w[0].charAt(0).toUpperCase() + w.slice(1)).join('');

      if (currCase === 'Camel Case') {
          res = res.charAt(0).toLowerCase() + res.slice(1);
      }


      document.getElementById('result').textContent = res;

  }
}