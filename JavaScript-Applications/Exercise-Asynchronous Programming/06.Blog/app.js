function attachEvents() {
    const viewButton = document.getElementById('btnViewPost');
    viewButton.addEventListener('click', getCurrPost);

    document.getElementById('btnLoadPosts').addEventListener('click', getPost);

}

attachEvents();

async function getPost() {
    const url = `http://localhost:3030/jsonstore/blog/posts`;

    const response = await fetch(url);
    const data = await response.json();

    const select = document.getElementById('posts');
    select.innerHTML = '';
    Object.values(data).map(option).forEach(o => select.appendChild(o));
}
function option(post) {
    const result = document.createElement('option');
    result.value = post.id;
    result.textContent = post.title;

    return result;
}
function getCurrPost() {
    const postId = document.getElementById('posts').value;
    getCommentsByPost(postId);
}

async function getCommentsByPost(postId) {
    const commentUl = document.getElementById('post-comments');
    commentUl.innerHTML = '';

    const [postResponse, commentsResponse] = await Promise.all([
        fetch('http://localhost:3030/jsonstore/blog/posts/' + postId),
        fetch(`http://localhost:3030/jsonstore/blog/comments`)
    ]);

    const postsData = await postResponse.json();
    document.getElementById('post-title').textContent = postsData.title;
    document.getElementById('post-body').textContent = postsData.body;

    const commentsData = await commentsResponse.json();
    const comment = Object.values(commentsData).filter(c => c.postId == postId);

    comment.map(createComment).forEach(c => commentUl.appendChild(c));
}

function createComment(currComment) {
    const comment = document.createElement('li');
    comment.textContent = currComment.text;
    comment.id = currComment.id;
    return comment;
}