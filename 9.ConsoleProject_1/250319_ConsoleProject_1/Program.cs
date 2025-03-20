using System.Numerics;
using System.Reflection.Emit;

namespace _250319_김채윤
{
    internal class Program
    {

        static void Main(string[] args)
        {   bool gameOver = false;
            Position player;
            char[,] map;
            Start(out player, out map);
            while (gameOver == false)
            {
                Render(player, map); // 그림
                ConsoleKey key = Input();  // 입력
                Update(key, ref player, map); // 처리
            }
            End();
        }
        static void Start(out Position player, out char[,] map)
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("*       소코반 게임         *");
            Console.WriteLine("*****************************");
            Console.WriteLine("\n▶  게임을 시작하시려면 아무키나 눌러주세요");
            ConsoleKey key = Console.ReadKey(true).Key;
            Console.Clear();
            Console.CursorVisible = false; // 커서 보이지 않게
            player.x = 4;
            player.y = 4;

            map = new char[8, 8]
                {
                    {'▒','▒','▒','▒','▒','▒','▒','▒'},
                    {'▒',' ',' ',' ','□',' ',' ','▒'},
                    {'▒',' ',' ',' ','■',' ',' ','▒'},
                    {'▒',' ',' ',' ',' ',' ',' ','▒'},
                    {'▒','□',' ','■',' ',' ','■','▒'},
                    {'▒',' ',' ',' ',' ','■','□','▒'},
                    {'▒',' ',' ',' ',' ','□',' ','▒'},
                    {'▒','▒','▒','▒','▒','▒','▒','▒'},
                };
        }

        static void Render(Position player, char[,] map)
        {
            Console.SetCursorPosition(0, 0); // 깜빡임 사라짐
            PrintMap(map); //맵을 먼저 그려야 플레이어가 안가려짐
            Printplayer(player);
        }
        static void PrintMap(char[,] map)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }
        static void Printplayer(Position player) // 해당 함수를 처리하기 위한 임력
        {
            Console.SetCursorPosition(player.x, player.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("P");
            Console.ResetColor();
            
        }
        // 키를 입력받는 기능
        static ConsoleKey Input()
        {
            return Console.ReadKey(true).Key;
        }
        //입력 후 움직일 수 있게
        static void Update(ConsoleKey key, ref Position player, char[,]map)
        {
            switch(key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (map[player.y, player.x - 1] != '▒')
                    {
                        player.x--;
                    }
                    else if(map[player.y, player.x - 1] == '■')
                    {
                        // 1. 박스 뒤에 벽이나 박스
                        if (map[player.y, player.x-1] == '▒' ||
                            map[player.y, player.x-1] == '■')
                        {

                        }
                        // 골
                        else if (map[player.y, player.x - 2] == '□')
                        {
                            map[player.y, player.x-2]='▣';
                            player.x--;
                        }
                        // 빈칸
                        else if (map[player.y, player.x-2]==' ')
                        {
                            map[player.y, player.x-2]='■';
                            player.x--;
                        }
                    }
                        break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (map[player.y, player.x + 1] != '▒')
                    {
                        player.x++;
                    }
                        break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (map[player.y-1, player.x] != '▒')
                    {
                        player.y--;
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (map[player.y+1, player.x] != '▒')
                    {
                        player.y++;
                    }
                    break;

            }
            
        }
        static void End()
        {
            
        }
        //  플레이어 위치
        struct Position
        {
            public int x;
            public int y;
        }
        
    }
}