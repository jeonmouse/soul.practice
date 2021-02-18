using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soul.practice
{
    public enum ClassType
    {
        Ranger = 0,
        Fighter = 1,
        Mage = 2,
        Archer = 3,
        Rogue = 4,
        Ghost = 5,
        Sentinel = 6,
        Druid = 7,
        Knight = 8,
        Berserker = 9,
        Gladiator = 10,
        Paladin = 11,
        Darkknight = 12,
        Archmage = 13,
        Sage = 14,
        Battlemage = 15,
        Priest = 16,
        Warlock = 17,
        None = int.MaxValue
    }

    public class Player : Creature
    {
        const int MAX_ABILITY = 18;
        protected ClassType classType;

        protected Player(ClassType classType) : base(CreatureType.Player)
        {
            this.classType = classType;
        }

        public ClassType GetClassType() { return classType; }

        public void SetAbilities()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int strength = random.Next(8, MAX_ABILITY);
            int constitution = random.Next(8, MAX_ABILITY);
            int dexterity = random.Next(8, MAX_ABILITY);
            int mentality = random.Next(8, MAX_ABILITY);
            int intelligence = random.Next(8, MAX_ABILITY);
            int charisma = random.Next(8, MAX_ABILITY);

            base.strength = strength;
            base.constitution = constitution;
            base.dexterity = dexterity;
            base.mentality = mentality;
            base.intelligence = intelligence;
            base.charisma = charisma;

            Console.WriteLine("STR: " + strength.ToString());
            Console.WriteLine("CON: " + constitution.ToString());
            Console.WriteLine("DEX: " + dexterity.ToString());
            Console.WriteLine("MEN: " + mentality.ToString());
            Console.WriteLine("INT: " + intelligence.ToString());
            Console.WriteLine("CHA: " + charisma.ToString());
        }
    }

    public class Fighter : Player
    {
        public Fighter() : base(ClassType.Fighter)
        {
            SetLevel(1);
            SetAbilities();
            SetStatus();
            SetWeapon(2, 8);

            Console.WriteLine("HP: " + hp.ToString());
            Console.WriteLine("SP: " + sp.ToString());
            Console.WriteLine("Damage: " + minDamage.ToString() + " - " + maxDamage.ToString());
        }
    }

    public class Ranger : Player
    {
        public Ranger() : base(ClassType.Ranger)
        {
            SetLevel(1);
            SetAbilities();
            SetStatus();
            SetWeapon(2, 8);

            Console.WriteLine("HP: " + hp.ToString());
            Console.WriteLine("SP: " + sp.ToString());
            Console.WriteLine("Damage: " + minDamage.ToString() + " - " + maxDamage.ToString());
        }
    }

    public class Mage : Player
    {
        public Mage() : base(ClassType.Mage)
        {
            SetLevel(1);
            SetAbilities();
            SetStatus();
            SetWeapon(1, 8);

            Console.WriteLine("HP: " + hp.ToString());
            Console.WriteLine("SP: " + sp.ToString());
            Console.WriteLine("Damage: " + minDamage.ToString() + " - " + maxDamage.ToString());
        }

        public override void SetStatus()
        {
            hp = (constitution - 2) * level;
            sp = mentality * level;
        }
    }
}
