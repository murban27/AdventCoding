using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public enum DirectionPossibilities
    {
        Up,
        Down,
        Left,
        Right,
        UpRight,
        UpLeft,
        DownRight,
        DownLeft

    }
    public class Direction
    {
        public HashSet<(DirectionPossibilities Direction, int X, int Y)> Values { get; set; } = new HashSet<(DirectionPossibilities, int, int)>(); char[,] _field;
        public List<DirectionPossibilities> _possibilities = new List<DirectionPossibilities>();
        int maxY;
        int maxX;
        const int minY = 0;
        const int minX = 0;
        public Direction(char[,] field)
        {
            _field = field;
            maxX = field.GetLength(0);
            maxY = field.GetLength(1);
        }
        public void SetPossibilities(int currentfieldx, int currentfieldy)
        {
            _possibilities.Clear();
            if (currentfieldx + 3 < maxX)
            {
                _possibilities.Add(DirectionPossibilities.Down);
                if (currentfieldy - 3 > minY)
                {
                    _possibilities.Add(DirectionPossibilities.Left);
                    _possibilities.Add(DirectionPossibilities.DownLeft);
                }
                if (currentfieldy + 3 < maxY)
                {
                    _possibilities.Add(DirectionPossibilities.Right);
                    _possibilities.Add(DirectionPossibilities.DownRight);
                }
            }
            if (currentfieldx - 3 >= minX)
            {
                _possibilities.Add(DirectionPossibilities.Up);
                if (currentfieldy - 3 >= minY)
                {
                    _possibilities.Add(DirectionPossibilities.Left);
                    _possibilities.Add(DirectionPossibilities.UpLeft);
                }
                if (currentfieldy + 3 < maxY)
                {
                    _possibilities.Add(DirectionPossibilities.Right);
                    _possibilities.Add(DirectionPossibilities.UpRight);
                }
            }
        }


        public bool Search(DirectionPossibilities directionPossibilities, int xPosition, int yPosition)
        {

            var possibilities = GetValues(directionPossibilities);
            string searchWord = "XMAS";
            int runningCut = 0;
            string word = "";
            for (int x = 0; x < searchWord.Length; x++)
            {
                if (Values.Contains((directionPossibilities, xPosition + possibilities.Item1 * x, yPosition + possibilities.Item2 * x)))
                    continue;
                else
                    Values.Add((directionPossibilities, xPosition + possibilities.Item1 * x, yPosition + possibilities.Item2 * x));

                int newX = xPosition + possibilities.Item1 * x;
                int newY = yPosition + possibilities.Item2 * x;
                word += _field[newX, newY];

            }
            if (word == searchWord)
                return true;
            else
            {
                return false;
            }

        }

        public (int, int) GetValues(DirectionPossibilities direction)
        {
            int x, y;
            switch (direction)
            { 
            
                case DirectionPossibilities.Up:
                    return (-1, 0);
                case DirectionPossibilities.Down:
                    return (1, 0);
                case DirectionPossibilities.Right:
                    return (0, 1);
                case DirectionPossibilities.Left:
                    return (0, -1);
                case DirectionPossibilities.UpRight:
                    return (-1, 1);
                case DirectionPossibilities.UpLeft:
                    return (-1, -1);
                case DirectionPossibilities.DownRight:
                    return (1, 1);
                case DirectionPossibilities.DownLeft:
                    return (1, -1);
                default:
                    return (0, 0);
            }


        }


    }
}

            
    
