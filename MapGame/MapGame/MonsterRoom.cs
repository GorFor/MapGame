using System;
namespace MapGame
{
	public class MonsterRoom : MapItem
	{
		int points = 25;

		public MonsterRoom() {
			setSymbol("M");
		}

		public int getPoints() {
			return points;
		}

        public void setPoints(int newPoints) {
            points = newPoints;

        //    if (points == 0) 
                setSymbol("m");
        }
	}
}
