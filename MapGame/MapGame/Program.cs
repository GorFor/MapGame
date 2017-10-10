using System;

namespace MapGame
{
	class MainClass

	{
		enum MoveDirection { up, down, left, right}

		public static void Main(string[] args)
		{
            /*
			Console.Write("Enter a character: ");
			char c = (char)Console.Read();
			if (Char.IsLetter(c))
			{
				if (Char.IsLower(c))
				{
					Console.WriteLine("The character is lowercase.");
				}
				else
				{
					Console.WriteLine("The character is uppercase.");
				}
			}
			else
			{
				Console.WriteLine("Not an alphabetic character.");
			}
*/
            Console.WriteLine("Select program level (1-4) high=1 lower > 1");

            int level = 0;
            switch (Console.ReadKey().Key) {
                case ConsoleKey.D0: 
                    level = 0;
                    break;
				case ConsoleKey.D1:
					level = 1;
					break;
				case ConsoleKey.D2:
					level = 2;
					break;
				case ConsoleKey.D3:
					level = 3;
					break;
				case ConsoleKey.D4:
					level = 4;
					break;
				default:
                    level = 1;
                    break;
            }

			int numberOfMoves = 0;
			bool exitFound = false;
            Player player = new Player(1, 1);
			Map map = new Map();
			map.setVisibility(player,level);
			map.printMap(player, numberOfMoves);

			while (exitFound == false)
			{
				switch (Console.ReadKey().Key) 
				{
					case ConsoleKey.W:
					case ConsoleKey.UpArrow:	
						numberOfMoves++;
						exitFound = map.MovePlayer(player, (int)MoveDirection.up);
						map.setVisibility(player, level);
						map.printMap(player, numberOfMoves);
						break;

					case ConsoleKey.S:
					case ConsoleKey.DownArrow:
						numberOfMoves++;
						exitFound = map.MovePlayer(player, (int)MoveDirection.down);
						map.setVisibility(player, level);
						map.printMap(player, numberOfMoves);
						break;
						
					case ConsoleKey.A:
					case ConsoleKey.LeftArrow:
						numberOfMoves++;
						exitFound = map.MovePlayer(player, (int)MoveDirection.left);
						map.setVisibility(player, level);
						map.printMap(player, numberOfMoves);
						break;
						
                    case ConsoleKey.D:
					case ConsoleKey.RightArrow:
						numberOfMoves++;
						exitFound = map.MovePlayer(player, (int)MoveDirection.right);
                        map.setVisibility(player, level);
						map.printMap(player, numberOfMoves);
						break;
						
					case ConsoleKey.X:
						exitFound = true;
						break;
						
					default:
						break;
				}  // end of switchc
			}  // end of while
		}  // end of main
	}  // end of MainClass
}  // end of file
