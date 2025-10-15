using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    public class Player
    {
        private int BaseHp = 100;
        private int BaseStamina = 80;
        public int Level { get; private set; } = 1;
        public string Name { get; set; }
        public string Job { get; set; }
        public float BaseAttackPoint { get; set; } = 2;
        public int BaseDefencePoint { get; set; } = 3;
        public int CurrentHp { get; private set; }
        public int Gold { get; private set; } = 1000;
        public int Exp { get; private set; } = 0;
        public int CurrentStamina { get; private set; }


        public float CurrentAttackPoint
        {
            get
            {
                return BaseAttackPoint + (Level * 1) + SumEquipWeaponAp;
            }
        }

        public int CurrentDefencePoint
        {
            get
            {
                return BaseDefencePoint + (Level * 2) + (int)SumEquipArmorGp;
            }
        }

        public int MaxHp
        {
            get
            {
                return BaseHp + (Level * 50);
            }
        }


        public int MaxExp
        {
            get
            {
                return Level * 100;
            }
        }

        public int MaxStamina
        {
            get
            {
                return BaseStamina + (Level * 20);
            }
        }

        public Player(string name, string job)
        {
            Name = name;
            Job = job;
            CurrentHp = MaxHp;
            CurrentStamina = MaxStamina;
        }
        public int DamagedHp(int damage)
        {
            CurrentHp -= damage;
            if (CurrentHp > MaxHp)
            {
                CurrentHp = MaxHp;
                return CurrentHp;
            }
            return CurrentHp;
        }

        public int AddGold(int gold)
        {
            Gold += gold;
            return Gold;
        }

        public int SubGold(int gold)
        {
            Gold -= gold;
            return Gold;
        }

        public int UseStamina(int stamina)
        {
            CurrentStamina -= stamina;
            return CurrentStamina;
        }

        public int HealStamina(int stamina)
        {
            CurrentStamina += stamina;
            if (CurrentStamina > MaxStamina)
            {
                CurrentStamina = MaxStamina;
            }
            return CurrentStamina;
        }

        public void AddExp(int getExp)
        {
            Exp += getExp;
            CheckLevelUp();
        }

        private bool CheckLevelUp()
        {
            bool levelUp = false;
            while (Exp >= MaxExp)
            {
                Exp -= MaxExp;
                LevelUp();
                levelUp = true;
            }
            return levelUp;
        }

        private void LevelUp()
        {
            Level++;
            CurrentHp = MaxHp;
            CurrentStamina = MaxStamina;
        }

        public List<Item> Inventory { get; private set; } = new List<Item>();

        public float SumEquipWeaponAp
        {
            get
            {
                float sum = 0f;
                for (int i = 0; i < Inventory.Count; i++)
                {
                    if (Inventory[i].IsEquipped && Inventory[i].Type == "Weapon")
                    {
                        sum += Inventory[i].Value;
                    }
                }
                return sum;
            }
        }

        public float SumEquipArmorGp
        {
            get
            {
                float sum = 0f;
                for (int i = 0; i < Inventory.Count; i++)
                {
                    if (Inventory[i].IsEquipped && Inventory[i].Type == "Armor")
                    {
                        sum += Inventory[i].Value;
                    }
                }
                return sum;
            }
        }
    }
}