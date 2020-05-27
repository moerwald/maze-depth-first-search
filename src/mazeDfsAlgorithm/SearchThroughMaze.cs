using System;
using System.Collections.Generic;
using System.Linq;

namespace mazeDfsAlgorithm
{
    public class SearchThroughMaze
    {

        private readonly Maze _maze;
        private readonly Stack<Coordinate> _pathThroughMaze;
        private readonly HashSet<Coordinate> _alreadyVisitedCoordinates;
        private readonly Action<Coordinate> _moveToNext;
        private readonly Action<Coordinate> _cantMoveNext;
        private bool _exitFound;

        public SearchThroughMaze(
            Maze maze, 
            Action<Coordinate> moveToNext,
            Action<Coordinate> cantMoveNext)
        {
            _maze = maze;
            _pathThroughMaze = new Stack<Coordinate>();
            _alreadyVisitedCoordinates = new HashSet<Coordinate>();
            _moveToNext = moveToNext;
            _cantMoveNext = cantMoveNext;
        }

        public List<Coordinate> Search()
        {
            _pathThroughMaze.Push(new Coordinate { X = 0, Y = 0 });

            while (_pathThroughMaze.Any())
            {
                var actCoordinate = _pathThroughMaze.Peek();

                _alreadyVisitedCoordinates.Add(actCoordinate);

                if (_exitFound)
                    return _pathThroughMaze.ToList();

                if (CanMoveDownFrom(actCoordinate))
                    continue;

                if (CanMoveUpFrom(actCoordinate))
                    continue;

                if (CanMoveRightFrom(actCoordinate))
                    continue;

                if (CanMoveLeftFrom(actCoordinate))
                    continue;

                CantMoveGoOneStepBack();
            }

            return new List<Coordinate>();
        }

        private void CantMoveGoOneStepBack()
        {
            var coordinate = _pathThroughMaze.Pop();
            _cantMoveNext?.Invoke(coordinate);
        }

        private bool CanMoveRightFrom(Coordinate coordinate)
            => CanMoveTo(new Coordinate { X = coordinate.X, Y = coordinate.Y + 1 });
        private bool CanMoveLeftFrom(Coordinate coordinate)
            => CanMoveTo(new Coordinate { X = coordinate.X, Y = coordinate.Y - 1 });
        private bool CanMoveDownFrom(Coordinate coordinate)
            => CanMoveTo(new Coordinate { X = coordinate.X + 1, Y = coordinate.Y });
        private bool CanMoveUpFrom(Coordinate coordinate)
            => CanMoveTo(new Coordinate { X = coordinate.X - 1, Y = coordinate.Y });

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

        private void MoveNextTo(Coordinate newCord)
        {
            _pathThroughMaze.Push(newCord);
            _moveToNext?.Invoke(newCord);
        }
    }
}
