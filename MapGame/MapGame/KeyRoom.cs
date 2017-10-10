using System;
namespace MapGame
{
	public class KeyRoom : MapItem
	{

        bool key = true;
            
		public KeyRoom() {
			setSymbol("N"); 
		}

        public void takeKey () {
            key = false;
            setSymbol("n");
        }

        public bool hasKey() {
            return key;
        }

	}
}
