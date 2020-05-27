using System;

namespace mazeDfsAlgorithm
{
    public class Maze
    {
        private readonly int[,] _maze;
        public int Height {get; private set;}
        public int Width { get; private set; }

        public Maze(int[,] maze)
        {
            _maze = maze;
            Height = maze.GetLength(0);
            Width = maze.GetLength(1);
        }

        public bool CoordinatesOutsideOfMaze(Coordinate coordinate)
        {
            var x = coordinate.X;
            var y = coordinate.Y;
            return (y < 0 || y >= Width) ||
                   (x < 0 || x >= Height);
        }

        public int GetValueAt(Coordinate coordinate) => _maze[coordinate.X, coordinate.Y];
        public void SetValueAt(Coordinate coordinate, int newValue) => _maze[coordinate.X, coordinate.Y] = newValue;

        internal bool IsExit(Coordinate newCord) => GetValueAt(newCord) == 2;

        internal bool IsWall(Coordinate newCord) => GetValueAt(newCord) == 1;
    }
}
