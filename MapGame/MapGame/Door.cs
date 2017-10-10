using System;
namespace MapGame
{
	public class Door : MapItem
	{
        bool closed = true;
        int number;

        public Door() {
            closed = true;
            setSymbol("D");
        }

        ~Door()
		{
            Console.WriteLine("door deleted");
		}

        public void SetNumber(int inNumber) {
            this.number = inNumber;
        }
		public int GetNumber()
		{
			return number;
		}

		public void SetOpen() {
			closed = false;
			setSymbol("d");
        }

		public void SetClosed() {
			closed = true;
			setSymbol("D");
		}

		public bool IsOpen() {
            return !closed;   
        }

	}
}
