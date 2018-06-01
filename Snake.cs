using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Snake : Figure
    {
        public Direction direction;
        public Snake(point tail, int lenght, Direction _direction)
        {
            direction = _direction;
            pList = new List<point>();
            for (int i = 0; i < lenght; i++)
            {
                point p = new point( tail );
                p.Move(i, direction);
                pList.Add( p );
            }
        }

        internal void Move()
        {
            point tail = pList.First();
            pList.Remove(tail);
            point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        public point GetNextPoint()
        {
            point head = pList.Last();
            point nextPoint = new point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }
        
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.left;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.right;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.down;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.up;
        }

        public bool Eat(point food)
        {
            point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
                return false;
        }
    }
}
