using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestClass]
    public class AxeTests
    {
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            NUnit.Framework.Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability dosen`t change after attack.");
        }
        [Test]
        public void BrokenAxeCantAttack()
        {
            Axe axe = new Axe(1, 1);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            NUnit.Framework.Assert.That(() => axe.Attack(dummy),
              Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }


    }
}
