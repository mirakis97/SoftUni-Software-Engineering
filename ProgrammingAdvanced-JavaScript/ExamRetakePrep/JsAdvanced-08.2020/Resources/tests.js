let { Repository } = require("./solution.js");
let { assert , expect} = require('chai');
describe("Tests …", function () {
    let repo = undefined;
    let props = { name: 'string', age: 'number' };
    entity = { name: 'Pepi', age: 1 };

    beforeEach(function() {
        repo = new Repository(props);
    });

    it('count returns number of stored entities', function() {
        expect(repo.count).to.equal(0);
    });
    it('Add with 1 parameter', function() {
        assert.equal(repo.add(entity),0)
    });
    it('Add with 2 parameter', function() {
        repo.add(entity);
        assert.equal(repo.add(entity),1)
    });
    it('Add with null', function() {
        let nullElement = null
        expect(function() {repo.add(nullElement)}).to.throw();
    });
    it('AddEntity throws with invalid input', function() {
        let invalidIput = { name: 'Mirko'};
        expect(function() {repo.add(invalidIput)}).to.throw();
    });
    it('AddEntity throws with incorect input', function() {
        let invalidIput = { name: 'Pepi', age:'Kiko'};
        expect(function() {repo.add(invalidIput)}).to.throw();
    });
    it('Test getId to work correct', function() {
        repo.add(entity);
        expect(repo.getId(0)).to.eql(entity);
    });
    it('Test getId to throw error', function() {
        repo.add(entity);
        expect(function() {repo.getId(1)}).to.throw;
    });
    it('Test update to work correct', function() {
        let newEntity = { name: 'Mirko', age: 15}
        repo.add(entity);
        repo.update(0,newEntity);
        expect(repo.getId(0)).to.eql(newEntity);
    });
    it('Test update to throw correct', function() {
        let newEntity = { name: 'Mirko', age: 15}
        repo.add(entity);
        expect(function() {repo.update(22,newEntity)}).to.throw;
    });
    // it('Test update to throw with invalid input', function() {
    //     let newEntity = { name: 'Mirko', age: 'Kiki'}
    //     repo.add(entity);
    //     expect(function() {repo.update(22,newEntity)}).to.throw;
    // });
    it('Test delete to work correct', function() {
        repo.add(entity);
        repo.del(0);
        assert.equal(repo.count,0)
    });
    it('Test delete to throw error', function() {
        repo.add(entity);
        expect(function() {repo.del(22)}).to.throw;
    });
    it('creates valdi instantiation of class', () => {
        expect(repo.props).to.eql(props);
        expect(repo.getId, 0);

        repo.add(entity);
        expect(repo.data.size).to.equal(1);
    });
});
