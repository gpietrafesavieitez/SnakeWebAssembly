using System.Collections.Generic;
using System.Linq;

namespace SnakeWebAssembly.Pages.Snake
{
    public class Player
    {
        public Pixel Head { get; set; }
        public List<Pixel> Body { get; set; }
        public bool IsCrashing { get; set; }
        public bool GameOver { get; set; } = false;
        public int Points { get; set; } = 0;

        public Player(int posX, int posY)
        {
            Body = new();
            Body.Add(new Pixel(posX, posY));
            Head = Body[0];
            IsCrashing = false;
        }

        // Se añade un nuevo pixel a la lista con las coordenadas del ultimo elemento
        public void Grow()
        {
            Body.Add(new Pixel(Body.Last().PosX, Body.Last().PosY));
        }

        // Comprueba si hay alguna parte de la serpiente en un pixel concreto
        public bool Check(Pixel pixel)
        {
            foreach (var body in Body)
            {
                if(body.PosX == pixel.PosX && body.PosY == pixel.PosY)
                {
                    return true;
                }
            }
            return false;
        }
        
        public void Move(Direction dir)
        {
            // Guardamos las posiciones de la serpiente antigua
            int[] lastBodyX = new int[Body.Count];
            int[] lastBodyY = new int[Body.Count];
            for (int i = 0; i < Body.Count; i++)
            {
                lastBodyX[i] = Body[i].PosX;
                lastBodyY[i] = Body[i].PosY;
            }
            // Movemos la cabeza en la direccion indicada
            switch (dir)
            {
                case Direction.LEFT:
                    Head.PosX--;
                    break;
                case Direction.UP:
                    Head.PosY--;
                    break;
                case Direction.RIGHT:
                    Head.PosX++;
                    break;
                case Direction.DOWN:
                    Head.PosY++;
                    break;
            }
            // Ahora cada elemento obtendrá la posicion que tenía elemento anterior
            for (int i = 0; i < Body.Count - 1; i++)
            {
                Body[i + 1].PosX = lastBodyX[i];
                Body[i + 1].PosY = lastBodyY[i];
                // Si las coordenadas de la cabeza son las mismas que las de alguna parte del nuevo cuerpo 
                if (Head.PosX == Body[i + 1].PosX && Head.PosY == Body[i + 1].PosY)
                {
                    IsCrashing = true;
                }
            }
        }
    }
}