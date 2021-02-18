using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soul.practice
{
    public enum GameMode
    {
        None,
        Lobby,
        Town,
        Field
    }

    public class Game
    {
        private GameMode mode = GameMode.Lobby;
        private Player player = null;
        private Monster monster = null;
        private Random random = new Random();

        public void Process()
        {
            switch (mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
            }
        }

        private void ProcessLobby()
        {
            Console.WriteLine("직업을 선택하세요");
            Console.WriteLine("[1] 파이터");
            Console.WriteLine("[2] 레인저");
            Console.WriteLine("[3] 메이지");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    player = new Fighter();
                    mode = GameMode.Town;
                    break;
                case "2":
                    player = new Ranger();
                    mode = GameMode.Town;
                    break;
                case "3":
                    player = new Mage();
                    mode = GameMode.Town;
                    break;
            }
        }

        private void ProcessTown()
        {
            Console.WriteLine("마을에 입장했습니다");
            Console.WriteLine("[1] 필드로 가기");
            Console.WriteLine("[2] 로비로 돌아가기");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    mode = GameMode.Field;
                    break;
                case "2":
                    mode = GameMode.Lobby;
                    break;
            }
        }

        private void ProcessField()
        {
            Console.WriteLine("필드에 입장했습니다");
            Console.WriteLine("[1] 싸우기");
            Console.WriteLine("[2] 일정 확률로 마을 돌아가기");

            CreateRandomMonster();

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ProcessFight();
                    break;
                case "2":
                    TryEscape();
                    break;
            }
        }

        private void TryEscape()
        {
            int randValue = random.Next(0, 101);
            if (randValue < 33)
            {
                mode = GameMode.Town;
            }
            else
            {
                ProcessFight();
            }
        }

        private void ProcessFight()
        {
            while (true)
            {
                int damage = player.GetAttack();
                monster.OnDamaged(damage);

                Console.WriteLine($"주인공이 몬스터에게 {damage.ToString()} 만큼 피해를 입혔습니다");
                
                if (monster.IsDead())
                {
                    Console.WriteLine("승리했습니다");
                    // Console.WriteLine($"남은 체력: {player.GetHp()}");
                    break;
                }
                
                damage = monster.GetAttack();
                player.OnDamaged(damage);

                Console.WriteLine($"몬스터가 주인공에게 {damage.ToString()} 만큼 피해를 입혔습니다");

                if (player.IsDead())
                {
                    Console.WriteLine("패배했습니다");
                    mode = GameMode.Lobby;
                    break;
                }

                Console.WriteLine($"주인공 체력: {player.GetHp()}");
                Console.WriteLine($"몬스터 체력: {monster.GetHp()}");
            }
        }

        private void CreateRandomMonster()
        {
            int randValue = random.Next(0, 3);
            switch (randValue)
            {
                case 0:
                    monster = new Rabbit();
                    Console.WriteLine("토끼가 나타났습니다");
                    break;
                case 1:
                    monster = new Dog();
                    Console.WriteLine("개가 나타났습니다");
                    break;
                case 2:
                    monster = new Bear();
                    Console.WriteLine("곰이 나타났습니다");
                    break;
            }
        }
    }

   
}
