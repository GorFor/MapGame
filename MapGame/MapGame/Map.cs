using System;
namespace MapGame
{
	public class Map
	{
		// ||             

		// Specification of the map and it's content
		static int maxRows      = 20;
		static int maxColumns   = 25;

		static int[,] exitPos 		   = new int[,] 	{ { 8, 8} };
		static int[,] swordRoomPos 	   = new int[,] 	{ { 2,18} };
		static int[,] doorPos 		   = new int[,] 	{ { 4, 4},{ 6, 7},{7,18}, {15,4} };
		static int[,] keyRoomPos       = new int[,] 	{ { 2, 6},{ 3,13},{5, 1} };
		static int[,] superKey2RoomPos = new int[,]     { { 17, 2 } };

		static int[,] monsterRoomPos = new int[,] 	{ { 2,13},{ 4,13},{3,12}, {3,14} };
		static int[,] wallPos        = new int[,]   { 
			                          {1,7}, 
			                          {2,7},
			                          {3,7},
		{4,1},{4,2},{4,3},{4,5},{4,6},{4,7}, 
			                          {5,7},

			                          {7,7},{7,8},{7,9},{7,10},{7,11},{7,12},{7,13},{7,14},{7,15},{7,16},{7,17},   {7,19},{7,20},{7,21},{7,22},{7,23},{7,24},
			                          {8,7},
									  {9,7},
									 {10,7},
                                     {11,7},
									 {12,7},
									 {13,7},
									 {14,7},
  {15,1},{15,2},{15,3},{15,5},{15,6},{15,7},
									 {16,7},
									 {17,7},
									 {18,7}

};
        // Initiate the map 
		MapItem[,] mapContent = new MapItem[maxRows, maxColumns];

        MapColors mapColor = new MapColors();

		enum backgroundColor { white, green, red, blue, yellow };

		// ------------------------------------------
		// Constructor that creates the initial map
		// ------------------------------------------
		public Map()
		{
			for (int ii = 0; ii < maxRows; ii++)
			{
				// Create the map
				for (int jj = 0; jj < maxColumns; jj++)
				{
					if (ii == 0 ||
						ii == maxRows - 1 ||
						jj == 0 ||
						jj == maxColumns - 1)
					{
						// The boundary of the map
						MapItem wall = new Wall();
						mapContent[ii, jj] = wall;
					}

					else 
					{
						// The map area
						MapItem mapItem = new MapItem();
						mapContent[ii, jj] = mapItem;
					}
				}
			}

			// Now add the other details , such as: 
			// exit, doors, keys, monster, inner-walls 

			// Create the sword (of destiny) and set it's position
			SwordRoom sword = new SwordRoom();
			mapContent[swordRoomPos[0, 0], swordRoomPos[0, 1]] = sword;

            // Create the doors and set their positions
            int doorNumber = 0;
			for (int ii = 0; ii < doorPos.Length/2; ii++)
			{ 
				Door door = new Door();
                door.SetNumber(doorNumber);
				mapContent[doorPos[ii, 0], doorPos[ii, 1]] = door;
                doorNumber++;
			}

			// Create the exit door and set it's position
			for (int ii = 0; ii < exitPos.Length / 2; ii++)
			{
				MapItem exit = new Exit();
				mapContent[exitPos[ii, 0], exitPos[ii, 1]] = exit;
			}

			// Create the key rooms and set their positions
			for (int ii = 0; ii < keyRoomPos.Length / 2; ii++)
			{
				KeyRoom keyRoom = new KeyRoom();
				mapContent[keyRoomPos[ii, 0], keyRoomPos[ii, 1]] = keyRoom;
			}

            // Create the super key rooms, here with 2 keys and set their positions
			for (int ii = 0; ii < superKey2RoomPos.Length / 2; ii++)
			{
				MapItem keyRoom = new KeyRoom();
				mapContent[superKey2RoomPos[ii, 0], superKey2RoomPos[ii, 1]] = keyRoom;
			}

			// Create the monsterrooms and set their positions
			for (int ii = 0; ii < monsterRoomPos.Length / 2; ii++)
			{
				MapItem monsterRoom = new MonsterRoom();
				mapContent[monsterRoomPos[ii, 0], monsterRoomPos[ii, 1]] = monsterRoom;
			}

			// Create the inner-walls and set their positions
			for (int ii = 0; ii < wallPos.Length / 2; ii++)
			{
				MapItem wall = new Wall();
				mapContent[wallPos[ii, 0], wallPos[ii, 1]] = wall;
			}
		} // End of constructor



		// ------------------------------------------
		// Print the whole map
		// ------------------------------------------
		public void printMap(Player player, int numberOfMoves)
		{
            int bgColor = mapColor.getgbColor();

			switch (bgColor) {

                case 0:
                    Console.BackgroundColor = ConsoleColor.White;
                    break;

                case 1:
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;

                case 2:
                    Console.BackgroundColor = ConsoleColor.Red;
					break;

				case 3:
                    Console.BackgroundColor = ConsoleColor.Blue;
					break;

				case 4:
                    Console.BackgroundColor = ConsoleColor.Yellow;
					break;

				default:
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
			}
                                  
         	Console.ForegroundColor = ConsoleColor.Black;
         	Console.Clear();

			String mapLine = "";
			for (int ii = 0; ii < maxRows; ii++)
			{
				mapLine = "";
				for (int jj = 0; jj < maxColumns; jj++)
				{
                    if (ii == player.GetPosX()
                        && jj == player.GetPosY()) {
                        mapLine = mapLine + player.GetPlayerSymbol();
					} else {                       
				    	MapItem mapItem = mapContent[ii, jj];
				    	mapLine = mapLine + mapItem.printSymbol();
					}
				}
				Console.WriteLine(mapLine);
			}

			Console.WriteLine("NumberOfMoves      : " + numberOfMoves);
			// Pick up the monster points
			Console.WriteLine("Monster points     : " + player.getMonsterPoints());
			// Has the player a key
            Console.WriteLine("Player has a key   : " + (player.hasKey() ? "Yes" : "No"));
			// Has the player a sword
            Console.WriteLine("Player has a sword : " + (player.hasSword() ? "Yes" : "No"));
			// Player position
			Console.WriteLine("Player position    : " + player.GetPosX() + "," + player.GetPosY());
			// Door status
			Door door = new Door();
			for (int ii = 0; ii < doorPos.Length / 2; ii++) {
				door = (Door)mapContent[doorPos[ii, 0], doorPos[ii, 1]];
				Console.WriteLine("Door " + door.GetNumber() + " open?    : " + (door.IsOpen() ? " Yes" : " No") + " " + doorPos[ii, 0] + "," + doorPos[ii, 1] );
			}

			return;
		}  // End of print map

		// --------------------------------------------
		// Set the visibility around the player
		// --------------------------------------------
		public void setVisibility(Player player, int level)
		{
            int playerPosX = player.GetPosX();
            int playerPosY = player.GetPosY();

			bool initialVisibleValue = false;
            // Set the initial value
            if (level == 0)
                initialVisibleValue = true;
            
            for (int ii = 1; ii < maxRows - 1; ii++)
            {
                for (int jj = 1; jj < maxColumns - 1; jj++)
                {
                    mapContent[ii, jj].setVisiblity(initialVisibleValue);
                }
            }

            if (initialVisibleValue == true)
                return;

			// Set the area around the player to visible
			int pointsAroundPlayer = level;
			for (int ii = 1; ii < maxRows - 1; ii++)
			{
				for (int jj = 1; jj < maxColumns - 1; jj++)
				{
					// Show the player and the surrounding items
					if (ii == playerPosX && jj == playerPosY)
						mapContent[ii, jj].setVisiblity(true);

                    for (int areaAroundX = 0; areaAroundX < pointsAroundPlayer + 1; areaAroundX++) {

                        for (int areaAroundY = 0; areaAroundY < pointsAroundPlayer + 1; areaAroundY++)
                        {
                            if (ii == playerPosX + areaAroundX && jj == playerPosY)
                                mapContent[ii, jj].setVisiblity(true);

                            else if (ii == playerPosX - areaAroundX && jj == playerPosY)
                                mapContent[ii, jj].setVisiblity(true);

                            else if (ii == playerPosX && jj == playerPosY + areaAroundY)
                                mapContent[ii, jj].setVisiblity(true);

                            else if (ii == playerPosX && jj == playerPosY - areaAroundY)
                                mapContent[ii, jj].setVisiblity(true);

                            else if (ii == playerPosX + areaAroundX && jj == playerPosY + areaAroundY)
                                mapContent[ii, jj].setVisiblity(true);

                            else if (ii == playerPosX - areaAroundX && jj == playerPosY - areaAroundY)
                                mapContent[ii, jj].setVisiblity(true);

                            else if (ii == playerPosX - areaAroundX && jj == playerPosY + areaAroundY)
                                mapContent[ii, jj].setVisiblity(true);

                            else if (ii == playerPosX + areaAroundX && jj == playerPosY - areaAroundY)
                                mapContent[ii, jj].setVisiblity(true);
                        }    
					}
				}
			}
			return;
		}

		// --------------------------------------------------
		// Different actions when the player is moving around
		// --------------------------------------------------
		public bool MovePlayer(Player player, int moveDirection)
		{

		   // enum backgroundColor { green, red, blue, yellow };

		    Wall wall = new Wall();
			Exit exit = new Exit();
			Door door = new Door();

			MonsterRoom monster   = new MonsterRoom();
			KeyRoom     keyRoom   = new KeyRoom();
			SwordRoom   swordRoom = new SwordRoom();
			MapItem     mapItem   = new MapItem();

			bool exitFound = false;
			int playerPosX = player.GetPosX();
			int playerPosY = player.GetPosY();

			int nextPosX = 0;
			int nextPosY = 0;

			// Check the move direction
			if (moveDirection == 0 && playerPosX > 1) {
				// UP
				nextPosX = playerPosX - 1;
				nextPosY = playerPosY;
			}
			else if (moveDirection == 1 && playerPosX < maxRows - 2) {
				// DOWN
				nextPosX = playerPosX + 1;
				nextPosY = playerPosY;
			}
			else if (moveDirection == 2 && playerPosY > 1) {
				// LEFT
				nextPosX = playerPosX;
				nextPosY = playerPosY - 1;
			}
            else if (moveDirection == 3 && playerPosY < maxColumns - 2) {
				// RIGHT
				nextPosX = playerPosX;
				nextPosY = playerPosY + 1;
			}

			// ---------------------------------------
			// Now check where the player has gone 
			// ---------------------------------------
			// Have we reach the exit door? 
			if (mapContent[nextPosX, nextPosY].GetType() == exit.GetType()) {
                mapColor.setgbColor((int)backgroundColor.green);
				player.SetPosX(nextPosX);
				player.SetPosY(nextPosY);
				return true;
			}

			// A wall stands in the way
			if (mapContent[nextPosX, nextPosY].GetType() == wall.GetType())
				return false;

			// Can we come trough the door, we must have a key
            // when entered the door remove the key
			// the door can of course already be open
			if (mapContent[nextPosX, nextPosY].GetType() == door.GetType())
			{
			    door = (Door)mapContent[nextPosX, nextPosY];
				if (door.IsOpen()) {
                    mapColor.setgbColor((int)backgroundColor.white);
				}
				else if (!player.hasKey()) {
					return false;
				}
				else if (player.hasKey()) {
					player.setKey(false);
					door.SetOpen();
					mapContent[nextPosX, nextPosY] = door;
					mapColor.setgbColor((int)backgroundColor.white);
				}
			}
			// Is this a key-rooom? Pick up the key if so! 
			else if (mapContent[nextPosX, nextPosY].GetType() == keyRoom.GetType()) {
				keyRoom = (KeyRoom)mapContent[nextPosX, nextPosY];
                if (keyRoom.hasKey()) {
                    keyRoom.takeKey();
                    player.setKey(true);
                    mapColor.setgbColor((int)backgroundColor.yellow);
				}
			}
			// Is this the sword room, get the sword if so! 
			else if (mapContent[nextPosX, nextPosY].GetType() == swordRoom.GetType())
			{
				swordRoom = (SwordRoom)mapContent[nextPosX, nextPosY];
                if (swordRoom.Sword.Equals(true)) {
                    //swordRoom.Sword.
                    player.setSword(true);
                    mapColor.setgbColor((int)backgroundColor.red);
					mapContent[nextPosX, nextPosY] = swordRoom;
				}
			}
			// Have we entered a monster room? Not good! 
			else if (mapContent[nextPosX, nextPosY].GetType() == monster.GetType()) {
				monster = (MonsterRoom)mapContent[nextPosX, nextPosY];
				player.addMonsterPoints(monster.getPoints());
                monster.setPoints(0);
				mapContent[nextPosX, nextPosY] = monster;
			}

			// move the player
            player.SetPosX(nextPosX);
			player.SetPosY(nextPosY);

           // ~Door();

			return exitFound;
		}

	}
	/*
        public struct Coordinates
        {
            public readonly int x;
            public readonly int y;

            public Coordinates(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }
*/

	// --------------------------------------------
	// get the players current position
	// --------------------------------------------
	/*
			public Coordinates getPlayerCurrentPos()
			{
				Player player = new Player(1,1);
				bool playerPositionFound = false;
				int playerCurrentPosX = 0;
				int playerCurrentPosY = 0;

				// Get the current position for the player
				// Serach until we have found a position where there is an object of the same type as the player
				for (playerCurrentPosX = 0; playerCurrentPosX<maxRows; playerCurrentPosX++)
				{
					for (playerCurrentPosY = 0; playerCurrentPosY<maxColumns; playerCurrentPosY++)
					{
						if (mapContent[playerCurrentPosX, playerCurrentPosY].GetType() == player.GetType())
						{
							// Here is the current position of the player
							playerPositionFound = true;
							break;
						}
					}

					if (playerPositionFound)
						break;
				}

				return new Coordinates(playerCurrentPosX, playerCurrentPosY);
			}   
	*/
	/*
			public bool MovePlayer1(Player player, int moveDirection)
			{
				Wall wall = new Wall();
				Exit exit = new Exit();
				Door door = new Door();

				MonsterRoom monster = new MonsterRoom();
				KeyRoom keyRoom     = new KeyRoom();
				MapItem mapItem     = new MapItem();

				bool exitFound = false;
				int playerPosX = player.GetPosX();
				int playerPosY = player.GetPosY();

				int nextPosX = 0;
				int nextPosY = 0;

				// Check the move direction
				if (moveDirection == 0 && playerPosX > 1)
				{
					// UP
					nextPosX = playerPosX - 1;
					nextPosY = playerPosY;

					// Have we reach the exit door? 
					if (mapContent[playerPosX - 1, playerPosY].GetType() == exit.GetType())
						return true;

					// A wall in the way?
					if (mapContent[playerPosX - 1, playerPosY].GetType() == wall.GetType())
						return false;

					// Can we come trough the door, we must have a key, when entered remove the key
					if (mapContent[playerPosX - 1, playerPosY].GetType() == door.GetType()
						&& !player.hasKey())
						return false;

					if (mapContent[playerPosX - 1, playerPosY].GetType() == door.GetType()
							 && player.hasKey())
						player.setKey(false);

					// Is this a key-rooom? Pick up the key if so! 
					else if (mapContent[playerPosX - 1, playerPosY].GetType() == keyRoom.GetType())
						player.setKey(true);

					// Have we entered a monster room? Not good! 
					else if (mapContent[playerPosX - 1, playerPosY].GetType() == monster.GetType())
						player.addMonsterPoints(monster.getMonsterPoints());

					player.SetPosX(playerPosX - 1);

				}
				else if (moveDirection == 1 && playerPosX < maxRows - 2)
				{
					// Console.WriteLine("down");
					// DOWN
					// Have we reach the exit door? 
					if (mapContent[playerPosX + 1, playerPosY].GetType() == exit.GetType())
						return true;

					// a wall
					if (mapContent[playerPosX + 1, playerPosY].GetType() == wall.GetType())
						return false;

					// Can we come trough the door, we must have a key, when entered remove the key
					// the door can already be open
					if (mapContent[playerPosX + 1, playerPosY].GetType() == door.GetType()) {

						door = (Door)mapContent[playerPosX + 1, playerPosY];

						if (door.IsOpen()) {
							;
						}
						else if (!player.hasKey()) {
							return false;
						}
						else if (player.hasKey() ) {
							player.setKey(false);
							door.SetOpen();
							mapContent[playerPosX + 1, playerPosY] = door;
						}
					}
					// ||             
					// Is this a key-rooom? Pick up the key if so! 
					else if (mapContent[playerPosX + 1, playerPosY].GetType() == keyRoom.GetType()){
						player.setKey(true);
					} 
					// Have we entered a monster room? Not good! 
					else if (mapContent[playerPosX + 1, playerPosY].GetType() == monster.GetType()) {
						player.addMonsterPoints(monster.getMonsterPoints());
					}   

					// move the player
					player.SetPosX(playerPosX + 1);
				}
				else if (moveDirection == 2 && playerPosY > 1)
				{
					// LEFT
					// Have we reach the exit door? 
					if (mapContent[playerPosX, playerPosY - 1].GetType() == exit.GetType()) {
						player.SetPosY(playerPosY - 1);
						return true;
					}

					if (mapContent[playerPosX, playerPosY - 1].GetType() == wall.GetType())
						return false;

					// Can we come trough the door, we must have a key, when entered remove the key
					if (mapContent[playerPosX, playerPosY - 1].GetType() == door.GetType()
						&& !player.hasKey())
						return false;

					if (mapContent[playerPosX, playerPosY - 1].GetType() == door.GetType()
						&& player.hasKey())
						player.setKey(false);

					// Is this a key-rooom? Pick up the key if so! 
					else if (mapContent[playerPosX, playerPosY - 1].GetType() == keyRoom.GetType())
						player.setKey(true);

					// Have we entered a monster room? Not good! 
					else if (mapContent[playerPosX, playerPosY - 1].GetType() == monster.GetType())
						player.addMonsterPoints(monster.getMonsterPoints());

					player.SetPosY(playerPosY - 1);
				}
				else if (moveDirection == 3 && playerPosY < maxColumns - 2)
				{
					Console.WriteLine("right");
					// RIGHT
					// Have we reach the exit door? 
					if (mapContent[playerPosX, playerPosY + 1].GetType() == exit.GetType())
						return true;

					if (mapContent[playerPosX, playerPosY + 1].GetType() == wall.GetType())
						return false;

					// Can we come trough the door, we must have a key, when entered remove the key
					if (mapContent[playerPosX, playerPosY + 1].GetType() == door.GetType()
						&& !player.hasKey())
						return false;

					// Can we come trough the door, we must have a key, when entered remove the key
					if (mapContent[playerPosX, playerPosY + 1].GetType() == door.GetType()
						&& player.hasKey())
						player.setKey(false);

					// Is this a key-rooom? Pick up the key if so! 
					else if (mapContent[playerPosX, playerPosY + 1].GetType() == keyRoom.GetType())
						player.setKey(true);

					// Have we entered a monster room? Not good! 
					else if (mapContent[playerPosX, playerPosY + 1].GetType() == monster.GetType())
						player.addMonsterPoints(monster.getMonsterPoints());

					// Move the player
					player.SetPosY(playerPosY + 1);
				}

				return exitFound;
			}
	*/

}
