using System;
namespace MapGame
{
	public class SwordRoom : MapItem
	{

        bool sword = true;

        public bool Sword { get { return sword; } set { sword = value; } }

		public SwordRoom()
		{
			setSymbol("S");
		}
/*
        public void getSword () {
            setSymbol("s");
            sword = false;
        }

        public bool hasSword() {
            return sword;
        }
*/

	}
}
