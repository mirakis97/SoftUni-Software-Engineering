function solution(command){ 
    const commands = {
        'upvote': () => { this.upvotes++; },
        'downvote': () => { this.downvotes++; },
        'score': () => {
            let totalVotes = this.downvotes + this.upvotes;
            let totalScore = this.upvotes - this.downvotes;
            let inflationAmount = Math.ceil(Math.max(this.downvotes, this.upvotes) * 0.25);
            let inflatedUpvotes = totalVotes > 50 ? this.upvotes + inflationAmount : this.upvotes;
            let inflatedDownvotes = totalVotes > 50 ? this.downvotes + inflationAmount : this.downvotes;
 
 
            let rating = 'new';
            if(totalVotes < 10) {
                rating = 'new';
            }
            else if((this.upvotes / totalVotes) > 0.66) {
                rating = 'hot';
            } else if(this.downvotes <= this.upvotes && totalVotes > 100) {
                rating = 'controversial';
            } else if (this.downvotes > this.upvotes){
                rating = 'unpopular';
            } 
 
            return [inflatedUpvotes, inflatedDownvotes, totalScore, rating];
        }
    };
 
    return commands[command]();
}
 