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

        public bool CoordinatesOutsideOfMaze(int x, int y)
        {
            return (y < 0 || y >= _mazeWidth) ||
                   (x < 0 || x >= _mazeHight);
        }

        public bool IsWall(int value) => value == 1;

        public bool IsExit(int mazeValue) => mazeValue == 2;
        public int GetValueAt(int x, int y) => _maze[x, y];
    }
}
