class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        }
        let username = this._likes[0];
        if (this._likes.length === 1) {
            return `${username} likes this story!`;
        }

        return `${username} and ${this._likes.length - 1} others like this story!`;
    }
    like(username) {
        if (this._likes.includes(username)) {
            throw new Error(`You can't like the same story twice!`);
        }
        if (username === this.creator) {
            throw new Error(`You can't like your own story!`);
        }

        this._likes.push(username);
        return `${username} liked ${this.title}!`;
    }
    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error(`You can't dislike this story!`);
        }

        this._likes.pop(username);
        return `${username} disliked ${this.title}`;
    }
    comment(username, content, id) {
        if (id === undefined || !this._comments.some(c => c.Id === id)) {
            let newComment = {
                Id: this._comments.length + 1,
                Username: username,
                Content: content,
                Replies: []
            };
            this._comments.push(newComment);
            return `${username} commented on ${this.title}`;
        }

        let commetnToReplay = this._comments.find(c => c.Id === id);
        let replyNextId = commetnToReplay.Replies.length + 1;
        let replyId = Number(`${commetnToReplay.Id}.${replyNextId}`);
        let reply = {
            Id: replyId,
            Username: username,
            Content: content,
        }
        commetnToReplay.Replies.push(reply);
        return `You replied successfully`;
    }

    toString(sortingType) {
        let sortVersion = {
            asc: (a, b) => a.Id - b.Id,
            desc: (a, b) => b.Id - a.Id,
            username: (a, b) => a.Username.localeCompare(b.Username)
        }
        let comments = this._comments.sort(sortVersion[sortingType]);
        comments.forEach(c => c.Replies.sort(sortVersion[sortingType]));
        let commentsStringArr = [];
        for (const comment of comments) {
            let commentsString = `-- ${comment.Id}. ${comment.Username}: ${comment.Content}`;
            let repliesString = comment.Replies
                .map(r => `--- ${r.Id}. ${r.Username}: ${r.Content}`).join('\n');
            repliesString = comment.Replies.length > 0
                ? `\n${repliesString}`
                : '';
            let combinedString = `${commentsString}${repliesString}`;
            commentsStringArr.push(combinedString);
        }

        let fullCommentsString = this._comments.length > 0
            ? `\n${commentsStringArr.join('\n')}`
            : '';

        return `Title: ${this.title}
Creator: ${this.creator}
Likes: ${this._likes.length}
Comments:${fullCommentsString}`;
    }
}