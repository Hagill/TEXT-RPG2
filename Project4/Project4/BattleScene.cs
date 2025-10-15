using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Project4
{
    internal class BattleScene : Scene
    {
        private BattleManager battleManager;
        private Player player;


        public BattleScene(BattleManager battleManager, Player player)
        {
            this.battleManager = battleManager;
            this.player = player;
        }

        internal override void Show()
        {
            battleManager.AddMonsters();
            DisplayBattleScene();
        }

        private void DisplayBattleScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!!\n");
                foreach (var monster in battleManager.Monsters)
                {
                    if (monster.IsLive)
                    {
                        Console.WriteLine($"Lv.{monster.Level,2} {monster.Name} HP {monster.Hp}");
                    }
                    else
                    {
                        Console.WriteLine($"Lv.{monster.Level,2} {monster.Name} Dead");
                    }
                }
                Console.WriteLine("\n");
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv.{player.Name} ({player.Job})");
                Console.WriteLine($"HP {player.CurrentHp,4}/{player.MaxHp,-4}\n");
                Console.WriteLine("1. 공격");
                Console.WriteLine("0. 도망치기");

                int playerSelect = InputHandler.GetUserActionInput();

                switch (playerSelect)
                {
                    case 1:
                        Console.WriteLine("공격을 선택하셨습니다.");
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.WriteLine("도망치기를 선택하셨습니다.");
                        battleManager.EndBattle();
                        GameManager.Instance.currentState = GameState.Home;
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void DisplayAttackScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!!\n");

                int index = 1;

                foreach (var monster in battleManager.Monsters)
                {
                    if (monster.IsLive)
                    {
                        Console.WriteLine($"{index} Lv.{monster.Level,2} {monster.Name} HP {monster.Hp}");
                    }
                    else
                    {
                        Console.WriteLine($"{index} Lv.{monster.Level,2} {monster.Name} Dead");
                    }
                    index++;
                }
                Console.WriteLine("\n");
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv.{player.Name} ({player.Job})");
                Console.WriteLine($"HP {player.CurrentHp,4}/{player.MaxHp,-4}\n");
                Console.WriteLine("0. 취소");

                int playerSelect = InputHandler.GetUserActionInputInBattle();

                if (playerSelect <= battleManager.Monsters.Count)
                {
                    int monsterIndex = playerSelect - 1;
                    if (!battleManager.Monsters[monsterIndex].IsLive)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                    }
                    else
                    {
                        battleManager.DamagedToMonster(battleManager.Monsters[monsterIndex], player.CurrentAttackPoint);
                    }
                }
                switch (playerSelect)
                {
                    case 1:
                        Console.WriteLine("공격을 선택하셨습니다.");
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.WriteLine("취소를 선택하셨습니다.");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
