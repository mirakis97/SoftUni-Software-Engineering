using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extended;
        [SetUp]
        public void Setup()
        {
            this.extended = new ExtendedDatabase();
        }

        [Test]
        public void Add_ThrowsExeption_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                this.extended.Add(new Person(i, $"Username{i}"));
            }
            Assert.Throws<InvalidOperationException>(() => this.extended.Add(new Person(16, "InvalidUsername")));
        }
        [Test]
        public void Add_ThrowsExeption_WhenUsernameIsUsed()
        {
            string username = "Mirko";

            this.extended.Add(new Person(1, username));

            Assert.Throws<InvalidOperationException>(() => this.extended.Add(new Person(2, username)));
        }
        [Test]
        public void Add_ThrowsExeption_WhenIdIsUsed()
        {
            long Id = 1;
            this.extended.Add(new Person(Id, "RandomNais"));
            Assert.Throws<InvalidOperationException>(() => this.extended.Add(new Person(Id, "RandomNais2")));
        }

        [Test]
        public void Add_IncreasesCounter_WhenUserIsValid()
        {
            this.extended.Add(new Person(1, "Gogi"));
            this.extended.Add(new Person(2, "Pesho"));

            int expectedCount = 2;
            Assert.That(this.extended.Count, Is.EqualTo(expectedCount));
        }
        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.extended.Remove());
        }
        [Test]
        public void Remove_RemovesElementsFromDatabase()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                this.extended.Add(new Person(i, $"Username{i}"));
            }

            this.extended.Remove();
            Assert.That(this.extended.Count, Is.EqualTo(n - 1));
            Assert.Throws<InvalidOperationException>(() => this.extended.FindById(n - 1));
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_ThrowsException_WhenArgumentIsNotValid(string username)
        {
            Assert.Throws<ArgumentNullException>(() => this.extended.FindByUsername(username));
        }

        [Test]
        public void FindByUsername_ThrowsException_WhenUsernameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.extended.FindByUsername("Username"));
        }

        [Test]
        public void FindByUsername_ThrowsException_ReturnExpectedUser_WhenUserExist()
        {
            Person person = new Person(1, "Gogi");

            this.extended.Add(person);

            Person dbPerson = this.extended.FindByUsername(person.UserName);
            Assert.That(person, Is.EqualTo(dbPerson));
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-25)]
        public void FindById_ThrowsExeption_WhenIsLessThanZero(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.extended.FindById(id));

        }
        [Test]

        public void FindById_ThrowsExeption_WhenUserIdDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.extended.FindById(100));
        }
        [Test]
        public void FindById_ReturnsExepctedUser()
        {
            Person person = new Person(1, "Gogi");
            this.extended.Add(person);

            Person dbPerson = this.extended.FindById(person.Id);
            Assert.That(person, Is.EqualTo(dbPerson));

        }
        [Test]
        public void Ctor_ThrowsExeption_WhenCapacityIsExceeded()
        {
            Person[] arguments = new Person[17];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"Username{i}");
            }
            Assert.Throws<ArgumentException>(() => this.extended = new ExtendedDatabase(arguments));
        }

        [Test]
        public void Ctor_AddInitialPeopleToDatabase()
        {
            Person[] arguments = new Person[5];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"Username{i}");
            }
            this.extended = new ExtendedDatabase(arguments);

            Assert.That(this.extended.Count, Is.EqualTo(arguments.Length));

            foreach (var person in arguments)
            {
                Person dbPerson = this.extended.FindById(person.Id);
                Assert.That(person, Is.EqualTo(dbPerson));
            }
        }
    }
}
