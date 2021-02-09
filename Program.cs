using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soul.practice
{
    class Program
    {
        enum ClassType
        {
            Ranger = 0,
            Fighter = 1,
            Mage = 2,
            Archer = 3,
            Rogue = 4,
            Ghost = 5,
            Sentinel = 6,
            Druid = 7,
            Knight = 8,
            Berserker = 9,
            Gladiator = 10,
            Paladin = 11,
            Darkknight = 12,
            Archmage = 13,
            Sage = 14,
            Battlemage = 15,
            Priest = 16,
            Warlock = 17,
            None = int.MaxValue
        }

        struct Player
        {
            public int hp;
            public int attack;
        }
        
        enum MonsterType
        {
            Slime = 0,
            Orc = 1,
            Skeleton = 2,
            None = int.MaxValue
        }

        struct Monster
        {
            public int hp;
            public int attack;
        }

        static ClassType ChooseClass()
        {
            Console.WriteLine("직업을 선택하세요!");
            Console.WriteLine("[1]파이터");
            Console.WriteLine("[2]레인저");
            Console.WriteLine("[3]메이지");

            ClassType choice = ClassType.None;
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    choice = ClassType.Fighter;
                    break;
                case "2":
                    choice = ClassType.Ranger;
                    break;
                case "3":
                    choice = ClassType.Mage;
                    break;
            }

            return choice;
        }

        static void CreatePlayer(ClassType choice, out Player player)
        {
            int strength = 16;
            int constitution = 15;
            int dexterity = 19;
            int mentality = 18;
            int intelligence = 14;
            int charisma = 20;

            switch (choice)
            {
                case ClassType.Fighter:
                    player.hp = constitution;
                    player.attack = 8;
                    break;
                case ClassType.Ranger:
                    player.hp = constitution;
                    player.attack = 10;
                    break;
                case ClassType.Mage:
                    player.hp = constitution - 2;
                    player.attack = 8;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }

        static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new Random();
            int randMonster = rand.Next(0, 3);
            switch (randMonster)
            {
                case (int)MonsterType.Slime:
                    Console.WriteLine("슬라임이 스폰되었습니다!");
                    monster.hp = 2;
                    monster.attack = 2;
                    break;
                case (int)MonsterType.Orc:
                    Console.WriteLine("오크가 스폰되었습니다!");
                    monster.hp = 4;
                    monster.attack = 4;
                    break;
                case (int)MonsterType.Skeleton:
                    Console.WriteLine("스켈레톤이 스폰되었습니다!");
                    monster.hp = 3;
                    monster.attack = 3;
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }
       
        static void EnterField()
        {
            while (true)
            {
                Console.WriteLine("필드에 접속했습니다!");

                // 몬스터 생성
                Monster monster;
                CreateRandomMonster(out monster);

                Console.WriteLine("[1] 전투모드로 돌입");
                Console.WriteLine("[2] 일정 확률로 마을로 도망");
            }
        }

        static void EnterGame()
        {
            while (true)
            {
                Console.WriteLine("마을에 접속했습니다!");
                Console.WriteLine("[1] 필드로 간다");
                Console.WriteLine("[2] 마을로 돌아가기");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    EnterField();
                }
                else if (input == "2")
                {
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                ClassType choice = ChooseClass();
                if (choice != ClassType.None)
                {
                    // 캐릭터 생성
                    Player player;
                    CreatePlayer(choice, out player);

                    EnterGame();
                }
                
            }
        }
    }
}
