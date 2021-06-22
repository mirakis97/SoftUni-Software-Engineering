let { Repository } = require("./solution.js");
const { assert, expect } = require('chai');

describe("Tests …", () => {
    let repo = undefined;
    let props = { name: 'string', age: 'number' };
    entity = { name: 'Pepi', age: 1 };

    beforeEach(function() {
        repo = new Repository(props);
    });


    it('count returns number of stored entities', function() {
        expect(repo.count).to.equal(0);
    });

    it('tests addEntity with one parameter', () => {
        assert.equal(repo.add(entity), 0);
    });

    it('tests addEntity with two parameters', () => {
        repo.add(entity)
        assert.equal(repo.add(entity), 1);
    });

    it('tests addEntity with null', () => {
        let nullEntity = null;
        expect(function() { repo.add(nullEntity) }).to.throw();
    });

    it('tests addEntity with missing property', () => {
        let invalidEntity = { name: 'Pepi' };
        expect(function() { repo.add(invalidEntity) }).to.throw();
    });

    it('tests addEntity with invalid type property', () => {
        let invalidEntity = { name: 'Pepi', age: 'G' };
        expect(function() { repo.add(invalidEntity) }).to.throw();
    });

    it('tests getID', () => {
        repo.add(entity);
        expect(repo.getId(0)).to.eql(entity);
    });

    it('tests getID with invalid parameter', () => {
        repo.add(entity);
        expect(function() { repo.getId(2) }).to.throw();
    });

    it('tests update with valid id', () => {
        let newEntity = { name: 'Bibi', age: 3 };
        repo.add(entity);
        repo.update(0, newEntity);
        expect(repo.getId(0)).to.eql(newEntity);
    });


    it('tests update with invalid id', () => {
        let newEntity = { name: 'Bibi', age: 3 };
        repo.add(entity);
        expect(function() { repo.update(22, newEntity) }).to.throw();
    });

    it('tests del', () => {
        repo.add(entity);
        repo.del(0);
        assert.equal(repo.count, 0);
    });

    it('tests del with invalid id', () => {
        repo.add(entity);
        expect(function() { repo.del(33) }).to.throw();

    });

    it('creates valdi instantiation of class', () => {
        expect(repo.props).to.eql(props);
        expect(repo.getId, 0);

        repo.add(entity);
        expect(repo.data.size).to.equal(1);
    });




});
