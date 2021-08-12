class ArtGallery{
    constructor(cretor){
        this.cretor = cretor;
        this.possibleArticles = {
            picture: 200,
            photo: 50,
            item: 250,
        }
        this.listOfArticles = [];
        this.guest = [];
    }
    addArticle( articleModel, articleName, quantity ){
        if (!this.possibleArticles.hasOwnProperty(articleModel.toLowerCase())) {
            throw new Error("This article model is not included in this gallery!");
        }
        let article = {
            ArticleModel: articleModel.toLowerCase(),
            ArticleName: articleName,
            Quantity: quantity
        }

        if (this.listOfArticles.some(n => n.ArticleName === articleName && n.ArticleModel === articleModel)) {
            article.Quantity += 1;
            return article;
        }
        this.listOfArticles.push(article);
        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }
    inviteGuest ( guestName, personality){
        if (this.guest.some(n => n.guestName === guestName)) {
            throw new Error(`${guestName} has already been invited.`);
        }
        let guest = {
            GuestName: guestName,
            Points: 0,
            PurchaseArticle: 0
        }
        if (personality ==='Vip') {
            guest.Points = 500
        }
        else if (personality === 'Middle') {
            guest.Points = 250
        }
        else{
            guest.Points = 50
        }
        this.guest.push(guest);
        return `You have successfully invited ${guestName}!`
    }
    buyArticle(articleModel, articleName, guestName) {
        let a = this.listOfArticles.find(x => x.ArticleName === articleName);
        if (a === undefined || a === null || a.ArticleModel !== articleModel.toLowerCase()) {
            throw new Error('This article is not found.');
        }
    
        if (a.quantity === 0) {
            return `The ${articleName} is not available.`;
        }
    
        let g = this.guest.find(x => x.GuestName === guestName);
        if (g === undefined || g === null) {
            return 'This guest is not invited.';
        }
    
        let requiredPoints = this.possibleArticles[articleModel.toLowerCase()]
        if (g.points < requiredPoints) {
            return 'You need to more points to purchase the article.';
        }
        a.quantity = a.quantity - 1;
    
        g.purchaseArticle = g.purchaseArticle + 1;
        g.points = g.points - requiredPoints;
    
        return `${guestName} successfully purchased the article worth ${requiredPoints} points.`;
    }
    showGalleryInfo (criteria){
        if (criteria === 'article') {
            let sb = '';
            sb += `Articles information:\n`;
            for (const article of this.listOfArticles) {
                sb += `${article.ArticleModel} - ${article.ArticleName} - ${article.Quantity}\n`
            }
            return sb;
        }
        else
        {
            let sb = '';
            sb += `Guests information:\n`;
            for (const article of this.listOfArticles) {
                sb += `${article.ArticleModel} - ${article.ArticleName} - ${article.Quantity}\n`
            }
            return sb;
        }
    }
}
const artGallery = new ArtGallery('Curtis Mayfield'); 
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
artGallery.buyArticle('picture', 'Mona Liza', 'John');
artGallery.buyArticle('item', 'Ancient vase', 'Peter');
console.log(artGallery.showGalleryInfo('article'));
console.log(artGallery.showGalleryInfo('guest'));
