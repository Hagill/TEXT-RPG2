using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    internal class PlayerInfo : Scene
    {
        private Player player;

        public PlayerInfo(Player player)
        {
            this.player = player;
        }

        internal override void Show()
        {
            DisplayPlayerinfo();
        }

        public void DisplayPlayerinfo()
        {
            bool keep = true;
            while (keep)
            {
                Console.Clear();
                Console.WriteLine($"\nLv.{player.Level}\n\n{player.Name}({player.Job})\n\n공격력: {player.CurrentAttackPoint:F1}\n방어력: {player.CurrentDefencePoint}" +
                                  $"\n체력: {player.CurrentHp}/{player.MaxHp}\nGold: {player.Gold}");
                Console.WriteLine("\n1.\n0. 나가기");

                int input = InputHandler.GetUserActionInput();
                if (input == 0)
                {
                    keep = false;
                    GameManager.Instance.currentState = GameState.Home;
                    Console.WriteLine("메인 화면으로 돌아갑니다.");
                    Console.WriteLine("\n아무 키나 눌러 다음으로 진행해주세요.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                }
            }
        }
    }
}
