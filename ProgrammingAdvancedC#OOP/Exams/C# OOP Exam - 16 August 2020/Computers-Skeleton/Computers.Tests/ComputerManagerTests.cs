using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computers;
        [SetUp]
        public void Setup()
        {
            this.computers = new ComputerManager();
        }

        [Test]
        public void Ctor_Working()
        {
            Computer computer = new Computer("Asus", "RX-200", 1000);

            Assert.AreEqual("Asus", computer.Manufacturer);
            Assert.AreEqual("RX-200", computer.Model);
            Assert.AreEqual(1000, computer.Price);
            Assert.IsNotNull(computer);
        }

        [Test]
        public void ComputersCount_IfNotEmpty()
        {
            Computer computer = new Computer("Asus", "RX-200", 1000);

            computers.AddComputer(computer);

            Assert.That(computers.Count, Is.EqualTo(1));
        }
        [Test]
        public void ComputersCount_WorkingRight()
        {
            Assert.That(computers.Count, Is.Zero);
        }

        [Test]
        public void ComputerIfAllreadyExist_ThrowsExeption()
        {
            Computer computer = new Computer("Asus", "RX-200", 1000);

            computers.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => computers.AddComputer(computer));
        }
        [Test]
        public void ValidateNullValue_Message()
        {
            Assert.Throws<ArgumentNullException>(() => computers.AddComputer(null));
        }
        [Test]
        public void RemoveComputers_Test()
        {
            Computer computer = new Computer("Asus", "RX-200", 1000);

            computers.AddComputer(computer);
            Assert.That(computers.RemoveComputer("Asus", "RX-200"), Is.EqualTo(computer));
        }
        [Test]
        public void RemoveComputers_ThrowsException()
        {
            Computer computer = new Computer("Asus", "RX-200", 1000);

            computers.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computers.RemoveComputer("Assssus", "RX-200"));
        }
        [Test]
        public void RemoveComputers_ReturnsCount()
        {
            Computer computer = new Computer("Asus", "RX-200", 1000);

            computers.AddComputer(computer);
            computers.RemoveComputer("Asus", "RX-200");
            Assert.AreEqual(0,computers.Count );
        }
        [Test]
        public void GetComp_IsNull()
        {
            Assert.Throws<ArgumentException>(() => computers.GetComputer("HP", "hp"));
        }

        [Test]
        public void GetComp_ReturnValue()
        {
            Computer computer = new Computer("Asus", "ROG", 1000);
            computers.AddComputer(computer);

            Assert.That(computers.GetComputer("Asus", "ROG"), Is.EqualTo(computer));
        }
        [Test]
        public void GetComp_ByManufacturer()
        {
            Computer computer = new Computer("Asus", "Rog", 1000);
            computers.AddComputer(computer);

            var result = computers.GetComputersByManufacturer("Asus");

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.AreEqual(result, computers.Computers);
        }

        [Test]
        public void GetComp_IReadOnly()
        {
            Computer computer1 = new Computer("Asus", "Rog", 1000);
            Computer computer2 = new Computer("Lenovo", "P-100", 1000);

            computers.AddComputer(computer1);
            computers.AddComputer(computer2);

            var comps = computers.Computers;
            Assert.That(comps.Count, Is.EqualTo(computers.Count));
        }
        [Test]
        public void GetComp_ThrowsExp()
        {
            Computer computer = new Computer("Asus", "Rog", 1000);
            computers.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => computers.GetComputer("Asus",null));
        }
        [Test]
        public void GetComp_ThrowsExpWithManufacturerNull()
        {
            Computer computer = new Computer("Asus", "Rog", 1000);
            computers.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => computers.GetComputer(null, "Rog"));
        }
        [Test]
        public void GetByManufacturer_ThrowsExeption()
        {
            Assert.Throws<ArgumentNullException>(() => computers.GetComputersByManufacturer(null));
        }
        [Test]
        public void GetAllByManufacturerShouldReturnCorrectCollection()
        {
            Computer computer = new Computer("Asus", "Rog", 1000);

            computers.AddComputer(computer);
            computers.AddComputer(new Computer("Asus", "Rx-200", 899.99m));
            computers.AddComputer(new Computer("Lenovo", "P-200", 420));
            var collection = computers.GetComputersByManufacturer("Asus");

            Assert.That(collection.Count, Is.EqualTo(2));

        }
    }
}