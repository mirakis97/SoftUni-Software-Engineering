using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Assert = NUnit.Framework.Assert;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int hp = 10;
        private const int exp = 10;
        private const int atk = 10;

        Dummy dummy;


        [SetUp]
        public void Init()
        {
            dummy = new Dummy(10, 10);
        }

        [Test]
        public void DummyLoosesHealthAfterAttack()
        {


            dummy.TakeAttack(atk);

            Assert.That(dummy.Health, Is.EqualTo(0), "Dummy Healt doesn't change after attack");
        }


        [Test]
        public void DummyThrowsExceptionIfAttacked()
        {


            dummy.TakeAttack(atk);

            var ex = Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(atk));

            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));

        }


        [Test]
        public void DummyCanGiveExperience()
        {
            var hero = new Hero("Pepi");

            hero.Attack(dummy);

            Assert.That(hero.Experience, Is.EqualTo(10), "Dummy doesn't give experience when dead");
        }

        [Test]
        public void AliveDummyCantGiveExperience()
        {
            var hero = new Hero("Mirko");

            dummy = new Dummy(20, 10);

            hero.Attack(dummy);

            var ex = Assert.Throws<InvalidOperationException>((() => dummy.GiveExperience()));

            Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
        }
    }
}
