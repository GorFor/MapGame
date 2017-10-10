using System;
namespace MapGame
{
    public class MapColors
    {
        enum backgroundColor { white, green, red, blue, yellow };

        int bgColor = (int)backgroundColor.white;

        public MapColors() {
            
        }

        public int getgbColor() {
            return bgColor;            
        }
	
        public void setgbColor(int color) {
            bgColor = color;
		}
	}
}
