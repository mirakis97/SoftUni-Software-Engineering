function loadRepos() {
	const name = document.querySelector('#username').value;
	const url = 'https://api.github.com/users/testnakov/repos';
	fetch(url)
	.then((response) => {
		if(response.status == 404){
			throw new Error("User not found")
		}
		console.log(response);
		return response.json()
	})
	.then((data) => {
		console.log(data);
		const ul = document.querySelector('#repos');
		ul.innerHTML = '';

		data.forEach(d => {
			const a = document.createElement('a');
			const li = document.createElement('li');

			a.setAttribute('herf',d.html_url);
			a.textContent = d.full_name;

			li.append(a);
			ul.append(li);
		});
	})
	.catch(error => {
		alert(error.message)
	});
}