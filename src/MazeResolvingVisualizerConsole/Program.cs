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
                {1, 1 , 1, 1, 0},
                {0, 0 , 0, 0, 0},
                {0, 1 , 1, 1, 1},
                {0, 0 , 0, 0, 2},
                };
            var mazeObject = new Maze(maze);
            var algo = new SearchThroughMaze(mazeObject, coord =>
            {
                mazeObject.SetValueAt(coord, 8);
                RedrawMaze(mazeObject);
            });
            algo.Search();
        }

        private static void RedrawMaze(Maze mazeObject)
        {
            Console.Clear();

            for (int y = 0; y < mazeObject.Height; y++)
            {
                for (int x = 0; x < mazeObject.Height; x++)
                {
                    Thread.Sleep(50);
                    Console.Write($"{mazeObject.GetValueAt(new Coordinate() { X = x, Y = y })} ");
                }
                Console.WriteLine();
            }

            Thread.Sleep(1000);
        }
    }
}
