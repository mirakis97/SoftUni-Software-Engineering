using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characters;
        private List<Item> items;

        public WarController()
        {
            this.characters = new List<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            Character character = null;
            string typeOfCharacter = args[0];
            string nameOfCharacter = args[1];

            if (typeOfCharacter == "Warrior")

            {
                character = new Warrior(nameOfCharacter);
            }
            else if (typeOfCharacter == "Priest")
            {
                character = new Priest(nameOfCharacter);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, typeOfCharacter));
            }

            characters.Add(character);

            return $"{nameOfCharacter} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            Item item = null;

            string itemType = args[0];
            if (itemType == "HealthPotion")

            {
                item = new HealthPotion();
            }
            else if (itemType == "FirePotion")
            {
                item = new FirePotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemType));
            }
            items.Add(item);
            return $"{itemType} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            var character = this.characters.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (!items.Any())
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
            }
            var pickedItem = this.items.Last();
            character.Bag.AddItem(pickedItem);

            return $"{characterName} picked up {pickedItem.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            if (!characters.Any(x => x.Name == characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Character character = characters.FirstOrDefault(x => x.Name == characterName);
            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{characterName} used {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var character in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine(character.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            Warrior attacker = (Warrior)this.characters.Where(c => c.GetType().Name == nameof(Warrior)).FirstOrDefault(c => c.Name == attackerName);
            Character receiver = this.characters.FirstOrDefault(x => x.Name == receiverName);

            StringBuilder sb = new StringBuilder();
            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            else if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (!attacker.IsAlive)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            if (!receiver.IsAlive)
            {
                throw new ArgumentException(ExceptionMessages.AffectedCharacterDead);
            }

            attacker.Attack(receiver);

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];
            Priest healer = (Priest)this.characters.Where(c => c.GetType().Name == nameof(Priest)).FirstOrDefault(c => c.Name == healerName);
            Character healerReceiver = this.characters.FirstOrDefault(x => x.Name == healingReceiverName);

            StringBuilder sb = new StringBuilder();
            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            else if (healerReceiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            if (!healer.IsAlive)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer));
            }

            if (!healerReceiver.IsAlive)
            {
                throw new ArgumentException(ExceptionMessages.AffectedCharacterDead);
            }

            healer.Heal(healerReceiver);

            sb.AppendLine($"{healer.Name} heals {healerReceiver.Name} for {healer.AbilityPoints}! {healerReceiver.Name} has {healerReceiver.Health} health now!");

            return sb.ToString().TrimEnd();
        }
    }
}
