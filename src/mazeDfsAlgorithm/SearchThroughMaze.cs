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

        public SearchThroughMaze(int[,] maze)
        {
            _maze = maze;
            _mazeHight = maze.GetLength(0);
            _mazeWidth = maze.GetLength(1);
        }

        public List<Coordinate> Search(int[,] maze)
        {
            var start = new Coordinate { X = 0, Y = 0 };
            var path = new Stack<Coordinate>();
            var alreadyVisited = new HashSet<Coordinate>();

            path.Push(start);
            while (path.Any())
            {
                var actCoordinate = path.Peek();
                var x = actCoordinate.X;
                var y = actCoordinate.Y;

                alreadyVisited.Add(actCoordinate);

                Coordinate newCord;
                bool newPathFound = false;
                // Move down
                if (!CoordinateIsOutsideOfMaze(x + 1, y))
                {
                    newCord = new Coordinate() { X = x + 1, Y = y };
                    if (maze[x + 1, y] == Exit)
                    {
                        Console.WriteLine("WON (moving down)");
                        path.Push(newCord);

                        return path.ToList();
                    }
                    else if (!CoordinateIsOutsideOfMaze(x + 1, y))
                    {
                        if (maze[x + 1, y] != Wall)
                        {
                            if (!alreadyVisited.Contains(newCord))
                            {
                                path.Push(newCord);
                                Console.WriteLine("Moving Down");
                                newPathFound = true;
                                continue;
                            }
                        }
                    }
                }

                // Move up
                if (!CoordinateIsOutsideOfMaze(x - 1, y))
                {
                    newCord = new Coordinate() { X = x - 1, Y = y };
                    if (maze[x - 1, y] == Exit)
                    {
                        Console.WriteLine("WON (moving up)");
                        path.Push(newCord);

                        return path.ToList();
                    }
                    else if (!CoordinateIsOutsideOfMaze(x - 1, y))
                    {
                        if (maze[x - 1, y] != Wall)
                        {
                            if (!alreadyVisited.Contains(newCord))
                            {
                                path.Push(newCord);
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
                    if (maze[x, y + 1] == Exit)
                    {
                        path.Push(newCord);
                        Console.WriteLine("WON (moving right)");
                        return path.ToList();
                    }
                    else if (!CoordinateIsOutsideOfMaze(x, y + 1))
                    {
                        if (maze[x, y + 1] != Wall)
                        {
                            if (!alreadyVisited.Contains(newCord))
                            {
                                path.Push(newCord);
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
                    if (maze[x, y - 1] == Exit)
                    {
                        path.Push(newCord);
                        Console.WriteLine("WON (moving left)");
                        return path.ToList();
                    }
                    else if (!CoordinateIsOutsideOfMaze(x, y - 1))
                    {
                        if (maze[x, y - 1] != Wall)
                        {
                            if (!alreadyVisited.Contains(newCord))
                            {
                                path.Push(newCord);
                                Console.WriteLine("Moving Left");
                                continue;
                            }
                        }
                    }
                }

                // Backtracking -> remove actual entry from the path stack
                Console.WriteLine("Dead end!");
                path.Pop();
            }

            return new List<Coordinate>();

        }
        private bool CoordinateIsOutsideOfMaze(int nextX, int nextY)
        {
            return (nextY < 0 || nextY >= _mazeWidth) ||
                   (nextX < 0 || nextX >= _mazeHight);
        }

    }
}
