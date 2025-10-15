using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    public class Item
    {
        public string Name { get; set; }
        public string Type { get; set; }  // "Armor" 또는 "Weapon"
        public float Value { get; set; }  // 방어력 또는 공격력 수치
        public string Info { get; set; }
        public bool IsEquipped { get; set; }
        public int Price { get; set; }


        public Item(string name, string type, float value, string info, int price)
        {
            Name = name;
            Type = type;
            Value = value;
            Info = info;
            IsEquipped = false;
            Price = price;
        }

        public static int ItemTypeOrder(string itemType)
        {
            switch (itemType)
            {
                case "Weapon": return 1;
                case "Armor": return 2;
                default: return 999;
            }
        }
    }
}
