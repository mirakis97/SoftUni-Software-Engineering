namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        [SetUp]
        public void SetUp()
        {
            this.aquarium = new Aquarium("Azis", 3);

        }
        [Test]
        public void Ctor_ShouldSetCorrectValue()
        {
            var expectedName = "Azis";
            var expectedCapacity = 3;
            var expectedFishCount = 0;
            var actualName = this.aquarium.Name;
            var actualCapacity = this.aquarium.Capacity;
            var actualFishCount = this.aquarium.Count;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedCapacity, actualCapacity);
            Assert.AreEqual(expectedFishCount, expectedFishCount);
        }

        [TestCase("")]
        [TestCase(null)]
        public void InvalidName_ShouldThrowArgumentNullExceptionWithNullOrEmptyString(string input)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(input, 3));
        }
        [Test]
        public void InvalidCapacity_ShouldThrowArgumentExceptionWithNegariveValue()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Azis", -3));
        }
        [Test]
        public void Add_ShouldWorkCorrect()
        {
            var fish = new Fish("Nemo");

            this.aquarium.Add(fish);
            var count = 1;
            var actualCOunt = this.aquarium.Count;

            Assert.AreEqual(count, actualCOunt);
        }
        [Test]
        public void Add_ShouldThrowInvalidOperation()
        {
            var fish = new Fish("Nemo");
            var fishTwo = new Fish("Nemo2");
            var fishThree = new Fish("Nemo3");

            this.aquarium.Add(fish);
            this.aquarium.Add(fishTwo);
            this.aquarium.Add(fishThree);

            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(new Fish("Nemo")));

        }
        [Test]
        public void Remove_ShouldWorkCorrect()
        {
            var fish = new Fish("Nemo");
            this.aquarium.Add(fish);

            this.aquarium.RemoveFish(fish.Name);

            var count = 0;
            var actualCOunt = this.aquarium.Count;

            Assert.AreEqual(count, actualCOunt);

        }
        [Test]
        public void Remove_ShouldThrowInvalidOperationExceptionWithNoExistingName()
        {
            var fish = new Fish("Nemo");

            this.aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish(("NoExistingName")));
        }

        [Test]
        public void Sellfish_ShouldWorkCorrect()
        {
            var fish = new Fish("Nemo");

            this.aquarium.Add(fish);

            var actual = this.aquarium.SellFish(fish.Name);

            Assert.AreSame(fish, actual);
        }
        [Test]
        public void Sellfish_ShouldThrowInvalidOperationExceptionWithNoExistingName()
        {
            var fish = new Fish("Nemo");
            this.aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish(("NoExistingName")));
        }


        [Test]
        public void Report_ShouldReturnCorrectInfo()
        {
            var fish = new Fish("Nemo");
            var fishTwo = new Fish("Nemo2");
            var fishThree = new Fish("Nemo3");

            this.aquarium.Add(fish);
            this.aquarium.Add(fishTwo);
            this.aquarium.Add(fishThree);

            var expected = $"Fish available at Azis: Nemo, Nemo2, Nemo3";
            var actual = this.aquarium.Report();

            Assert.AreEqual(expected,actual);
        }
    }
}
