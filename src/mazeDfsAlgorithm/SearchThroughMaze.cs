using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace mazeDfsAlgorithm
{
    public class SearchThroughMaze
    {
        private const int Wall = 1;
        private const int Exit = 2;
        private readonly int[,] _maze;
        private readonly int _mazeHight;
        private readonly int _mazeWidth;
        private readonly Stack<Coordinate> _path;
        private bool _exitFound;

        public SearchThroughMaze(int[,] maze)
        {
            _maze = maze;
            _mazeHight = maze.GetLength(0);
            _mazeWidth = maze.GetLength(1);
            _path = new Stack<Coordinate>();
        }

        public List<Coordinate> Search()
        {
            var start = new Coordinate { X = 0, Y = 0 };
            var alreadyVisited = new HashSet<Coordinate>();

            _path.Push(start);
            while (_path.Any())
            {
                var actCoordinate = _path.Peek();
                var x = actCoordinate.X;
                var y = actCoordinate.Y;

                alreadyVisited.Add(actCoordinate);

                if (_exitFound)
                    return _path.ToList();

                if (CanMoveDown(alreadyVisited, x, y))
                    continue;

                if (CanMoveUp(alreadyVisited, x, y))
                    continue;

                if (CanMoveRight(alreadyVisited, x, y))
                    continue;

                if (CanMoveRight(alreadyVisited, x, y))
                    continue;

                // Backtracking -> remove actual entry from the path stack
                Console.WriteLine("Dead end!");
                _path.Pop();
            }

            return new List<Coordinate>();

        }

        private bool CanMoveRight(HashSet<Coordinate> alreadyVisited, int x, int y)
            => CanMoveTo(_path, alreadyVisited, x, y + 1);
        private bool CanMoveLeft(HashSet<Coordinate> alreadyVisited, int x, int y)
            => CanMoveTo(_path, alreadyVisited, x, y - 1);

        private bool CanMoveDown(HashSet<Coordinate> alreadyVisited, int x, int y)
            => CanMoveTo(_path, alreadyVisited, x + 1, y);
        private bool CanMoveUp(HashSet<Coordinate> alreadyVisited, int x, int y)
            => CanMoveTo(_path, alreadyVisited, x - 1, y);

        private bool CanMoveTo(
            Stack<Coordinate> path,
            HashSet<Coordinate> alreadyVisited,
            int x,
            int y)
        {
            var newPathFound = false;
            if (!CoordinateIsOutsideOfMaze(x, y))
            {
                var newCord = new Coordinate() { X = x, Y = y };
                var mazeValue = _maze[x, y];
                if (mazeValue == Exit)
                {
                    Console.WriteLine("WON (moving down)");
                    path.Push(newCord);
                    _exitFound = true;
                    newPathFound = true;
                }
                else if (mazeValue != Wall)
                {
                    if (!alreadyVisited.Contains(newCord))
                    {
                        path.Push(newCord);
                        Console.WriteLine("Moving Down");
                        newPathFound = true;
                    }
                }
            }

            return newPathFound;
        }

        private bool CoordinateIsOutsideOfMaze(int nextX, int nextY)
        {
            return (nextY < 0 || nextY >= _mazeWidth) ||
                   (nextX < 0 || nextX >= _mazeHight);
        }

    }
}
