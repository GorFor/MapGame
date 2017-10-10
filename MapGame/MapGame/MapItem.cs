using System;
namespace MapGame
{
	public class MapItem
	{
        
		String symbol = ".";
		Boolean visible = true;

		public MapItem()
		{
			setSymbol(".");
		}

		public void setSymbol(String value)
		{
			symbol = value;
		}

		public void setVisiblity(bool value)
		{
			visible = value;
		}

		public String printSymbol()
		{
			if (visible)
				return symbol;
			else
				return " ";
		}
	}
}
