using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    internal enum GameState
    {
        None,// 게임 종료
        Home,// 메인 화면
        Stat,// 상태창
        Battle,// 전투
        Example1,
        Example2,
    }

    internal class GameManager
    {
        /* 싱글톤 */
        //============================================================//
        private static GameManager instance;
        internal static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
        internal Player CurrentPlayer { get; private set; }
        internal BattleManager BattleManager { get; private set; }

        /* 게임 상태 */
        //============================================================//
        internal GameState currentState;
        internal Dictionary<GameState, Scene> scenes;

        /* 생성자 */
        //============================================================//
        internal GameManager()
        {
            CurrentPlayer = new Player("Chad", "전사");
            // 예제 확인하려면 currentState = GameState.Example1
            currentState = GameState.Home;
            scenes = new Dictionary<GameState, Scene>();
            BattleManager = new BattleManager();

            // 씬을 매니저에 추가하는 방법 예시
            scenes.Add(GameState.Home, new Home());
            scenes.Add(GameState.Stat, new PlayerInfo(CurrentPlayer));
            scenes.Add(GameState.Battle, new BattleScene(BattleManager, CurrentPlayer));
        }

        internal void Run()
        {
            while (currentState != GameState.None)
            {
                scenes[currentState].Show();
            }
        }
    }
}

