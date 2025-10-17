using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    internal class BattleManager
    {
        public List<Monster> Monsters { get; private set; }
        private Random rand = new Random();
        public BattleManager()
        {
            Monsters = new List<Monster>();
        }

        public void AddMonsters()
        {
            
            int spawnMonster = rand.Next(1, 5);

            for (int i = 0; i < spawnMonster; i++)
            {
                int spawnMonsterType = rand.Next(1, Monsters.Count + 1);
                switch (spawnMonsterType)
                {
                    case 1:
                        Monsters.Add(new Monster("미니언", 2, 15, 5));
                        break;
                    case 2:
                        Monsters.Add(new Monster("공허충", 3, 10, 9));
                        break;
                    case 3:
                        Monsters.Add(new Monster("대포미니언", 5, 25, 8));
                        break;
                    default:
                        break;
                }
            }
        }

        public float CalcPlayerAttackDamage(Player player)
        {
            float playerAttack = player.CurrentAttackPoint;
            float minDamage = playerAttack * 0.9f;
            float maxDamage = playerAttack * 1.1f;

            float calcDamage = (float)(rand.NextDouble() * (maxDamage - minDamage) + minDamage);

            calcDamage = (float)Math.Round(calcDamage);

            return calcDamage;
        }

        public void DamagedToMonster(Monster monster, float damage)
        {
            monster.CurrentHp(damage);
            Console.WriteLine($"{monster.Name}이(가) {damage}의 피해를 입었습니다.");
            Console.ReadKey();
            if (!monster.CurrentLive())
            {
                Console.WriteLine($"{monster.Name}이(가) 쓰러졌습니다.");
                Console.ReadKey();
            }
        }

        
        private void ClearAllMonsters()   // 전투 종료 시 생성 된 몬스터들을 리스트에서 삭제
        {
            Monsters.Clear();
        }
        
        public void EndBattle()
        {
            ClearAllMonsters();
        }
    }
}
