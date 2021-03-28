using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private Dictionary<string, UnitDriver> drivers;
        private RaceEntry races;
        [SetUp]
        public void Setup()
        {
            this.races = new RaceEntry();
            this.drivers = new Dictionary<string, UnitDriver>();
        }

        [Test]
        public void DriversCount_WorkingRight()
        {
            var driverCount = this.drivers.Count;

            Assert.That(driverCount, Is.EqualTo(races.Counter));
        }

        [Test]
        public void Ctor_WorkingRight()
        {
            Assert.That<RaceEntry>(races, Is.EqualTo(races));
        }

        [Test]
        public void AddDriver_ThrowsExeption_WhenDriverDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => races.AddDriver(null));
        }
        [Test]
        public void AddDriver_ThrowsExeption_WhenDriverNameExist()
        {

            Assert.Throws<InvalidOperationException>(() =>
                {
                    var unitDriver = new UnitDriver("Peshi", new UnitCar("model", 10, 10));
                    races.AddDriver(unitDriver);
                    races.AddDriver(unitDriver);
                    races.AddDriver(unitDriver);
                });
        }
        [Test]
        public void AddDriver()
        {
            var unitDriver = new UnitDriver("Peshi", new UnitCar("model", 10, 10));
            var result = races.AddDriver(unitDriver);

            Assert.AreEqual("Driver Peshi added in race.", result);
            Assert.AreEqual(1, races.Counter);
        }
        [Test]
        public void CalculateAverageHorsePower_ThrowsExeption_WhenThereAreNotEnoughPartipacital()
        {
            var unitDriver = new UnitDriver("Peshi", new UnitCar("model", 10, 10));
            var result = races.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                races.CalculateAverageHorsePower();
            });
        }
        [Test]
        public void CalculateAverageHorsePower_WhenItShouldWork()
        {
            var unitCar1 = new UnitCar("VW", 100, 2000);
            var unitDriver1 = new UnitDriver("Kiro", unitCar1);

            var unitCar2 = new UnitCar("BMW", 100, 3000);
            var unitDriver2 = new UnitDriver("Ivan", unitCar2);

            var unitCar3 = new UnitCar("Pesho", 100, 1000);
            var unitDriver3 = new UnitDriver("Qna", unitCar3);

            races.AddDriver(unitDriver1);
            races.AddDriver(unitDriver2);
            races.AddDriver(unitDriver3);

            var result = races.CalculateAverageHorsePower();

            Assert.AreEqual(100,result);
        }

    }
}