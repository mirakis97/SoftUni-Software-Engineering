function solve(input) {

  const arr = JSON.parse(input);

  let titles = Array.from(new Set(arr.map(x => Object.keys(x)).flat()));

  let result = '<table>\n';
  
  result += '<tr><th>' + titles.join('</th><th>') + '</th></tr>\n';

  result = arr.reduce((acc, obj) => {

      let innerLine = '<td>' + titles.map(t => {

          let value = obj[t]
              .toString()
              .replace(/&/g, "&amp;")
              .replace(/</g, "&lt;")
              .replace(/>/g, "&gt;")
              .replace(/"/g, "&quot;")
              .replace(/'/g, "&#39;");
          ;


          return value;
      }).join('</td><td>') + '</td>';
    

      return acc + '<tr>' + innerLine + '</tr>\n';
  }, result);


  result += '</table>';
  return result;


}

    console.log(solve(['[{"Name":"Stamat","Score":5.5},{"Name":"Rumen","Score":6}]']));
