using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soul.practice
{
    public enum MonsterType
    {
        None = 0,
        Bear = 1,
        Dog = 2,
        Rabbit = 3
    }

    public class Monster : Creature
    {
        protected MonsterType monsterType;

        protected Monster(MonsterType type) : base(CreatureType.Monster)
        {
            monsterType = type;
        }

        public void SetAbilities(int strength, int constitution, int dexterity, int mentality, int intelligence, int charisma)
        {
            base.strength = strength;
            base.constitution = constitution;
            base.dexterity = dexterity;
            base.mentality = mentality;
            base.intelligence = intelligence;
            base.charisma = charisma;
        }
    }
    
    public class Bear : Monster
    {
        public Bear() : base(MonsterType.Bear)
        {
            SetLevel(1);
            SetAbilities(18, 18, 18, 3, 3, 6);
            SetStatus();
            SetWeapon(2, 10);
        }
    }

    public class Dog : Monster
    {
        public Dog() : base(MonsterType.Dog)
        {
            SetLevel(1);
            SetAbilities(9, 10, 11, 5, 5, 5);
            SetStatus();
            SetWeapon(1, 4);
        }
    }

    public class Rabbit : Monster
    {
        public Rabbit() : base(MonsterType.Rabbit)
        {
            SetLevel(1);
            SetAbilities(3, 6, 9, 3, 3, 4);
            SetStatus();
            SetWeapon(0, 1);
        }
    }
}
