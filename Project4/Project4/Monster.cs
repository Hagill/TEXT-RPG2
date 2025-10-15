using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    internal class Monster
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public float Hp { get; set; }
        public int AttackPoint { get; set; }
        public bool IsLive { get; set; } = true;

        public Monster(string name, int level, float hp, int attackPoint)
        {
            Name = name;
            Level = level;
            Hp = hp;
            AttackPoint = attackPoint;
        }

        public float CurrentHp(float damaged)
        {
            Hp -= damaged;
            return Hp;
        }

        public bool CurrentLive()
        {
            if (Hp <= 0)
            {
                IsLive = false;
                return IsLive;
            }
            else
            {
                return IsLive;
            }
        }
    }
}
