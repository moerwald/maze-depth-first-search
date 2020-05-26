using System.Collections.Generic;
using System.Linq;

namespace mazeDfsAlgorithm
{
    public class SearchThroughMaze
    {

        private readonly Maze _maze;
        private readonly Stack<Coordinate> _pathThroughMaze;
        private readonly HashSet<Coordinate> _alreadyVisitedCoordinates;
        private bool _exitFound;

        public SearchThroughMaze(int[,] maze)
        {
            _maze = new Maze(maze);
            _pathThroughMaze = new Stack<Coordinate>();
            _alreadyVisitedCoordinates = new HashSet<Coordinate>();
        }

        public List<Coordinate> Search()
        {
            var start = new Coordinate { X = 0, Y = 0 };

            _pathThroughMaze.Push(start);
            while (_pathThroughMaze.Any())
            {
                var actCoordinate = _pathThroughMaze.Peek();

                _alreadyVisitedCoordinates.Add(actCoordinate);

                if (_exitFound)
                    return _pathThroughMaze.ToList();

                if (CanMoveDown(actCoordinate))
                    continue;

                if (CanMoveUp(actCoordinate))
                    continue;

                if (CanMoveRight(actCoordinate))
                    continue;

                if (CanMoveLeft(actCoordinate))
                    continue;

                CantMoveGoOneStepBack();
            }

            return new List<Coordinate>();
        }

        private void CantMoveGoOneStepBack() => _pathThroughMaze.Pop();

        private bool CanMoveRight(Coordinate coordinate) 
            => CanMoveTo(new Coordinate { X = coordinate.X, Y = coordinate.Y + 1 });
        private bool CanMoveLeft(Coordinate coordinate) 
            => CanMoveTo(new Coordinate { X = coordinate.X, Y = coordinate.Y - 1 });
        private bool CanMoveDown(Coordinate coordinate) 
            => CanMoveTo(new Coordinate { X = coordinate.X + 1, Y = coordinate.Y  });
        private bool CanMoveUp(Coordinate coordinate) 
            => CanMoveTo(new Coordinate { X = coordinate.X - 1, Y = coordinate.Y  });

        private bool CanMoveTo(Coordinate coordinate)
        {
            var canMoveToCoordinate = false;
            if (_maze.CoordinatesOutsideOfMaze(coordinate))
                return canMoveToCoordinate;

            if (_maze.IsExit(coordinate))
            {
                MoveNextTo(coordinate);
                _exitFound = true;
                canMoveToCoordinate = true;
            }
            else if (!_maze.IsWall(coordinate))
            {
                if (CoordinateWasNotVisited(coordinate))
                {
                    MoveNextTo(coordinate);
                    canMoveToCoordinate = true;
                }
            }

            return canMoveToCoordinate;
        }

        private bool CoordinateWasNotVisited(Coordinate newCord) => !_alreadyVisitedCoordinates.Contains(newCord);

        private void MoveNextTo(Coordinate newCord) => _pathThroughMaze.Push(newCord);
    }
}
