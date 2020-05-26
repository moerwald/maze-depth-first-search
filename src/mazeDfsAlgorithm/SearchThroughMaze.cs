using System.Collections.Generic;
using System.Linq;

namespace mazeDfsAlgorithm
{

    public class SearchThroughMaze
    {
        private const int Wall = 1;
        private const int Exit = 2;

        private readonly Maze _maze;
        private readonly Stack<Coordinate> _pathThroughMaze;
        private bool _exitFound;

        public HashSet<Coordinate> _alreadyVisitedCoordinates { get; private set; }

        public SearchThroughMaze(int[,] maze)
        {
            _maze = new Maze(maze);
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

        private void CantMoveGoOneStepBack() => _pathThroughMaze.Pop();

        private bool CanMoveRight(int x, int y) => CanMoveTo(x, y + 1);
        private bool CanMoveLeft(int x, int y) => CanMoveTo(x, y - 1);

        private bool CanMoveDown(int x, int y) => CanMoveTo(x + 1, y);
        private bool CanMoveUp(int x, int y) => CanMoveTo(x - 1, y);

        private bool CanMoveTo(int x, int y)
        {
            var newPathFound = false;
            if (_maze.CoordinatesOutsideOfMaze(x, y))
                return newPathFound;

            var newCord = new Coordinate() { X = x, Y = y };
            var mazeValue = _maze.GetValueAt(x, y);
            if (mazeValue == Exit)
            {
                AddMoveToMazePath(newCord);
                _exitFound = true;
                newPathFound = true;
            }
            else if (mazeValue != Wall)
            {
                if (CoordinateWasNotVisited(newCord))
                {
                    AddMoveToMazePath(newCord);
                    newPathFound = true;
                }
            }

            return newPathFound;
        }

        private bool CoordinateWasNotVisited(Coordinate newCord) => !_alreadyVisitedCoordinates.Contains(newCord);

        private void AddMoveToMazePath(Coordinate newCord) => _pathThroughMaze.Push(newCord);
    }
}
