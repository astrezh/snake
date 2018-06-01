using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class point
    {
        public int x;
        public int y;
        public char sym;

        public point()
        {
        }
        public point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public point(point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int offset, Direction direction)
        {
            if(direction == Direction.right)
            {
                x = x + offset;
            }
            else if(direction == Direction.left)
            {
                x = x - offset;
            }
            else if(direction == Direction.up)
            {
                y = y - offset;
            }
            else if(direction == Direction.down)
            {
                y = y + offset;
            }

        }

        internal bool IsHit(point p)
        {
            return p.x == this.x && p.y == this.y;
        }


        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym );
        }

        public void Clear()
        {
            sym = ' ';
            Draw();
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }
    }
}
