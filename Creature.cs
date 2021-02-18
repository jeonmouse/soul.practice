using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soul.practice
{
    public enum CreatureType
    {
        None = 0,
        Player = 1,
        Monster = 2
    }

    public class Creature
    {
        protected int level;
        protected int strength;
        protected int constitution;
        protected int dexterity;
        protected int mentality;
        protected int intelligence;
        protected int charisma;

        protected int hp;
        protected int sp;
        protected int minDamage;
        protected int maxDamage;

        protected CreatureType type;

        protected Creature(CreatureType type)
        {
            this.type = type;
        }

        public void SetLevel(int level)
        {
            this.level = level;
        }

        public virtual void SetStatus()
        {
            hp = level * constitution;
            sp = 0;
        }

        public void SetWeapon(int min, int max)
        {
            this.minDamage = min;
            this.maxDamage = max;
        }

        public int GetHp() { return hp; }

        public bool IsDead() { return hp <= 0; }

        public void OnDamaged(int damage)
        {
            hp -= damage;
            if (hp < 0)
                hp = 0;
        }

        public int GetAttack()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            return random.Next(minDamage, maxDamage + 1);
        }
    }
}
