function loadCommits() {
    const name = document.querySelector('#username').value;
    const repo = document.querySelector('#repo').value;
    const commits = document.querySelector('#commits');
	const url = `https://api.github.com/repos/${name}/${repo}/commits`;

    commits.innerHTML = '';
	fetch(url)
	.then((response) => {
		if(response.status == 404){
			throw new Error(`<li>${response.status} (${response.statusText})</li>`);
		}
		return response.json()
	})
	.then((data) => {
		data.forEach(d => {
			const li = document.createElement('li');
            li.textContent = `${d.commit.author.name}: ${d.commit.message}`;
            commits.appendChild(li);
		});
	})
	.catch(error => {
		commits.innerHTML = error.message;
	});
}