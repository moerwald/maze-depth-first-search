using System;

namespace mazeDfsAlgorithm
{
    public class Maze
    {
        private readonly int[,] _maze;
        private readonly int _mazeHight;
        private readonly int _mazeWidth;

        public Maze(int[,] maze)
        {
            _maze = maze;
            _mazeHight = maze.GetLength(0);
            _mazeWidth = maze.GetLength(1);
        }

        public bool CoordinatesOutsideOfMaze(Coordinate coordinate)
        {
            var x = coordinate.X;
            var y = coordinate.Y;
            return (y < 0 || y >= _mazeWidth) ||
                   (x < 0 || x >= _mazeHight);
        }

        public int GetValueAt(Coordinate coordinate) => _maze[coordinate.X, coordinate.Y];

        internal bool IsExit(Coordinate newCord) => GetValueAt(newCord) == 2;

        internal bool IsWall(Coordinate newCord) => GetValueAt(newCord) == 1;
    }
}
