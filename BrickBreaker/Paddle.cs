using System.Drawing;
using System.Drawing.Drawing2D;

namespace BrickBreaker
{
    public class Paddle
    {
        public int x, y, height, speed;
        public float width;
        public Color colour;

        public Paddle(int _x, int _y, float _width, int _height, int _speed, Color _colour)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            speed = _speed;
            colour = _colour;
        }

        public void Move(string direction)
        {
            if (direction == "left")
            {
                x -= speed;
            }
            if (direction == "right")
            {
                x += speed;
            }
        }

    }
}
