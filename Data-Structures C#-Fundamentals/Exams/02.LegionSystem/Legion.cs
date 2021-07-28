namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using _02.LegionSystem.Interfaces;

    public class Legion : IArmy
    {
        private LinkedList<IEnemy> warriors;
        public Legion()
        {
            warriors = new LinkedList<IEnemy>();
        }
        public int Size => warriors.Count;

        public bool Contains(IEnemy enemy)
        {
            if (!this.warriors.Contains(enemy))
            {
                return true;
            }
            return false;
        }

        public void Create(IEnemy enemy)
        {
            warriors.AddFirst(enemy);
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            IEnemy enemy = null;
            foreach (var attackSpeed in warriors)
            {
                if (attackSpeed.AttackSpeed == speed)
                {
                    enemy = attackSpeed;
                }
            }
            return enemy;
        }

        public List<IEnemy> GetFaster(int speed)
        {
            List<IEnemy> result = this.warriors.Where(e => e.AttackSpeed > speed).ToList();

            return result;
        }

        public IEnemy GetFastest()
        {
             this.EnsureNotEmpty();
            return warriors.First();
        }

        public IEnemy[] GetOrderedByHealth()
        {
            var enemies = new HashSet<IEnemy>();
            foreach (var enemy in warriors.OrderByDescending(a => a.Health))
            {
                enemies.Add(enemy);
            }
            return enemies.ToArray();
        }

        public List<IEnemy> GetSlower(int speed)
        {
            List<IEnemy> result = this.warriors.Where(e => e.AttackSpeed < speed).ToList();

            return result;
        }

        public IEnemy GetSlowest()
        {
            this.EnsureNotEmpty();
            return warriors.Last();
        }

        public void ShootFastest()
        {
            this.EnsureNotEmpty();
            warriors.RemoveLast();
        }

        public void ShootSlowest()
        {
            this.EnsureNotEmpty();
            warriors.RemoveFirst();
        }

        private void EnsureNotEmpty()
        {
            if (this.warriors.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
        }
    }
}
