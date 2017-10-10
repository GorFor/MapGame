using System;
namespace MapGame
{
    public class Player {

		String Symbol = "@";

		bool key = false;
        bool sword = false;

		int monsterPoints = 0;

        int posX;
        int posY;

		public Player(int x, int y) {
            posX = x;
            posY = y;
		}

        public string GetPlayerSymbol() {
            return Symbol;
        }

        public int GetPosX() {
            return posX;
        }

		public int GetPosY() {
			return posY;
		}

		public void SetPosX(int x) {
			posX = x;
		}

		public void SetPosY(int y) {
			posY = y;
		}

		public void setKey(bool value) {
			key = value;
		}

		public bool hasKey() {
			return key;
		}

		public void setSword(bool value) {
			sword = value;
		}

		public bool hasSword() {
			return sword;
		}

		public int getMonsterPoints() {
			return monsterPoints;
		}

		public void addMonsterPoints(int newMonsterPoints) {
			monsterPoints = monsterPoints + newMonsterPoints;
		}

	}
}
