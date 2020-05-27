using mazeDfsAlgorithm;
using System;
using System.Linq;
using System.Threading;

namespace MazeResolvingVisualizerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var maze = new int[,]{
                {0, 0 , 0, 0, 0, 0, 0},
                {1, 1 , 0, 1, 0, 1, 1},
                {0, 1 , 0, 1, 0, 0, 0},
                {1, 1 , 1, 1, 1, 1, 0},
                {0, 1 , 0, 0, 0, 0, 0},
                {1, 1 , 0, 0, 1, 1, 0},
                {0, 2 , 0, 0, 0, 1, 0},
                };
            var mazeObject = new Maze(maze);
            var algo = new SearchThroughMaze(mazeObject, coord =>
            {
                mazeObject.SetValueAt(coord, 8);
                RedrawMaze(mazeObject);
            });
            var result = algo.Search();

            var origForeGroundColor = Console.ForegroundColor;
            Console.WriteLine("====================");
            if (result.Any())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Way throuhg maze successfully found");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No way through maze found");
            }

            Console.ForegroundColor = origForeGroundColor;
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
