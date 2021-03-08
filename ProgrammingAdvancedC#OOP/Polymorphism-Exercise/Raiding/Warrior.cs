using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {

        private const int basePower = 100;

        public Warrior(string name)
            : base(name, basePower)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Warrior)} - {Name} hit for {Power} damage";

        }
    }
}

