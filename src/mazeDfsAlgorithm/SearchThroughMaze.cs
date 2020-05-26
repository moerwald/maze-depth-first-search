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
        private readonly Stack<Coordinate> _pathThroughMaze;
        private bool _exitFound;

        public HashSet<Coordinate> _alreadyVisitedCoordinates { get; private set; }

        public SearchThroughMaze(int[,] maze)
        {
            _maze = maze;
            _mazeHight = maze.GetLength(0);
            _mazeWidth = maze.GetLength(1);
            _pathThroughMaze = new Stack<Coordinate>();
        }

        public List<Coordinate> Search()
        {
            var start = new Coordinate { X = 0, Y = 0 };
            _alreadyVisitedCoordinates = new HashSet<Coordinate>();

            _pathThroughMaze.Push(start);
            while (_pathThroughMaze.Any())
            {
                var actCoordinate = _pathThroughMaze.Peek();
                var x = actCoordinate.X;
                var y = actCoordinate.Y;

                _alreadyVisitedCoordinates.Add(actCoordinate);

                if (_exitFound)
                    return _pathThroughMaze.ToList();

                if (CanMoveDown(x, y))
                    continue;

                if (CanMoveUp(x, y))
                    continue;

                if (CanMoveRight(x, y))
                    continue;

                if (CanMoveLeft(x, y))
                    continue;

                CantMoveGoOneStepBack();
            }

            return new List<Coordinate>();
        }

        private void CantMoveGoOneStepBack()
        {
            _pathThroughMaze.Pop();
        }

        private bool CanMoveRight(int x, int y) => CanMoveTo(x, y + 1);
        private bool CanMoveLeft(int x, int y) => CanMoveTo(x, y - 1);

        private bool CanMoveDown(int x, int y) => CanMoveTo(x + 1, y);
        private bool CanMoveUp(int x, int y) => CanMoveTo(x - 1, y);

        private bool CanMoveTo(int x, int y)
        {
            var newPathFound = false;
            if (CoordinateIsOutsideOfMaze(x, y))
                return newPathFound;

            var newCord = new Coordinate() { X = x, Y = y };
            var mazeValue = _maze[x, y];
            if (mazeValue == Exit)
            {
                _pathThroughMaze.Push(newCord);
                _exitFound = true;
                newPathFound = true;
            }
            else if (mazeValue != Wall)
            {
                if (
                    !_alreadyVisitedCoordinates.Contains(newCord)
                    )
                {
                    _pathThroughMaze.Push(newCord);
                    newPathFound = true;
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
