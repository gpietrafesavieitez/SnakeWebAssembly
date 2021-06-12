namespace SnakeWebAssembly.Pages.Snake
{
    public enum Direction
    {
        LEFT = 0,
        UP = 1,
        RIGHT = 2,
        DOWN = 3
    }

    public class Board
    {
        public int TabX { get; set; }
        public int TabY { get; set; }

        public Board(int tabX, int tabY)
        {
            TabX = tabX;
            TabY = tabY;
        }
    }
}
