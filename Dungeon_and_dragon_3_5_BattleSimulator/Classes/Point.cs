using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_and_Dragon_3_5_BattleSimulator.Classes
{
    public class Point
    {
        private int x;
        private int y;
        private bool filled;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public bool Filled
        {
            get { return filled; }
        }
        public void togglefilled()
        {
            filled = !filled;
        }
        public double Distance(Point _goal, bool tonearest = false)
        {
            double result = Math.Sqrt(Math.Pow(((double)_goal.X - (double)X), 2) + Math.Pow(((double)_goal.Y - (double)Y), 2));
            if (tonearest)
            {
                result = (Math.Round(result * 2)) / 2;
            }
            return result;
        }
        public bool isAdjacent(Point _goal)
        {
            if (_goal == null)
            {
                return false;
            }
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (X - i == _goal.X && Y - j == _goal.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool isOnField(Point _goal)
        {
            if (_goal.X == X && _goal.Y == Y)
            {
                return true;
            }
            return false;
        }
        public Point getDelta(Point OtherPoint)
        {
            int X_delta = X - OtherPoint.X;
            int Y_delta = Y - OtherPoint.Y;
            return new Point(X_delta, Y_delta);
        }
        public Point addPoint(Point OtherPoint)
        {
            int X_delta = X + OtherPoint.X;
            int Y_delta = Y + OtherPoint.Y;
            return new Point(X_delta, Y_delta);
        }
    }
}
