using FakeAxeAndDummy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Tests.Fakes
{
    public class FakeTarget : ITarget
    {
        public void TakeAttack(int attackPoints)
        {
        }
        public int Health => 0;
        public int GiveExperience() { return 20; }
        public bool IsDead() { return true; }

    }
}
