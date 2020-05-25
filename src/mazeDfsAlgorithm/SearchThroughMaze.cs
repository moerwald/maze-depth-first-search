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

                // Move down
                if (
                    CanMoveTo(_path, alreadyVisited, x + 1, y)
                    )
                    continue;

                // Move up
                Coordinate newCord;
                if (!CoordinateIsOutsideOfMaze(x - 1, y))
                {
                    newCord = new Coordinate() { X = x - 1, Y = y };
                    if (_maze[x - 1, y] == Exit)
                    {
                        Console.WriteLine("WON (moving up)");
                        _path.Push(newCord);

                        return _path.ToList();
                    }
                    else if (!CoordinateIsOutsideOfMaze(x - 1, y))
                    {
                        if (_maze[x - 1, y] != Wall)
                        {
                            if (!alreadyVisited.Contains(newCord))
                            {
                                _path.Push(newCord);
                                Console.WriteLine("Moving Up");
                                continue;
                            }
                        }
                    }
                }

                // Move right
                if (!CoordinateIsOutsideOfMaze(x, y + 1))
                {
                    newCord = new Coordinate() { X = x, Y = y + 1 };
                    if (_maze[x, y + 1] == Exit)
                    {
                        _path.Push(newCord);
                        Console.WriteLine("WON (moving right)");
                        return _path.ToList();
                    }
                    else if (!CoordinateIsOutsideOfMaze(x, y + 1))
                    {
                        if (_maze[x, y + 1] != Wall)
                        {
                            if (!alreadyVisited.Contains(newCord))
                            {
                                _path.Push(newCord);
                                Console.WriteLine("Moving Right");
                                continue;
                            }
                        }
                    }
                }

                // Move left
                if (!CoordinateIsOutsideOfMaze(x, y - 1))
                {
                    newCord = new Coordinate() { X = x, Y = y - 1 };
                    if (_maze[x, y - 1] == Exit)
                    {
                        _path.Push(newCord);
                        Console.WriteLine("WON (moving left)");
                        return _path.ToList();
                    }
                    else if (!CoordinateIsOutsideOfMaze(x, y - 1))
                    {
                        if (_maze[x, y - 1] != Wall)
                        {
                            if (!alreadyVisited.Contains(newCord))
                            {
                                _path.Push(newCord);
                                Console.WriteLine("Moving Left");
                                continue;
                            }
                        }
                    }
                }

                // Backtracking -> remove actual entry from the path stack
                Console.WriteLine("Dead end!");
                _path.Pop();
            }

            return new List<Coordinate>();

        }

        private bool CanMoveTo(
            Stack<Coordinate> path, 
            HashSet<Coordinate> alreadyVisited, 
            int x, 
            int y)
        {
            var newPathFound = false;
            if (!CoordinateIsOutsideOfMaze(x , y))
            {
                var newCord = new Coordinate() { X = x , Y = y };
                if (_maze[x , y] == Exit)
                {
                    Console.WriteLine("WON (moving down)");
                    path.Push(newCord);
                    _exitFound = true;
                    newPathFound = true;
                }
                else if (!CoordinateIsOutsideOfMaze(x , y))
                {
                    if (_maze[x , y] != Wall)
                    {
                        if (!alreadyVisited.Contains(newCord))
                        {
                            path.Push(newCord);
                            Console.WriteLine("Moving Down");
                            newPathFound = true;
                        }
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
