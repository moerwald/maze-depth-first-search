using mazeDfsAlgorithm;
using System;
using System.Threading;

namespace MazeResolvingVisualizerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var maze = new int[,]{
                {0, 0 , 0, 0, 0},
                {1, 1 , 0, 1, 0},
                {0, 1 , 0, 0, 0},
                {0, 1 , 0, 1, 1},
                {0, 1 , 0, 1, 0},
                {1, 1 , 0, 0, 1},
                {2, 0 , 0, 0, 0},
                };
            var mazeObject = new Maze(maze);
            var algo = new SearchThroughMaze(mazeObject, coord =>
            {
                mazeObject.SetValueAt(coord, 8);
                RedrawMaze(mazeObject);
            });
            if (algo.Search().Count == 0)
            {
                Console.WriteLine("No way through maze found");
            }

        }

        private static void RedrawMaze(Maze mazeObject)
        {
            Console.Clear();
            var foreGroundColor = Console.ForegroundColor;

            for (int x = 0; x < mazeObject.Height; x++)
            {
                for (int y = 0; y < mazeObject.Width; y++)
                {
                    Thread.Sleep(10);

                    var mazeValue = mazeObject.GetValueAt(new Coordinate() { X = x, Y = y });
                    if (mazeValue == 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = foreGroundColor;
                    }

                    Console.Write($"{mazeValue} ");
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = foreGroundColor;
            Thread.Sleep(200);
        }
    }
}
