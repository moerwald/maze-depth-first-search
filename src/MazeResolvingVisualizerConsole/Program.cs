using mazeDfsAlgorithm;
using System;
using System.Linq;

namespace MazeResolvingVisualizerConsole
{
    class Program
    {
        static void Main()
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
            var mazeDrawer = new ConsoleMazeDrawer();
            var algo = new SearchThroughMaze(
                mazeObject,
                coord => Redraw(coord, mazeObject, mazeDrawer, 8),
                deadCord => Redraw(deadCord, mazeObject, mazeDrawer, 0)
                );
            var result = algo.Search();

            PrintResult(result);
        }

        private static void Redraw(
            Coordinate coord, 
            Maze mazeObject, 
            ConsoleMazeDrawer mazeDrawer,
            int newValue)
        {
            mazeObject.SetValueAt(coord, newValue);
            mazeDrawer.RedrawMaze(mazeObject);
        }

        private static void PrintResult(System.Collections.Generic.List<Coordinate> result)
        {
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
    }
}
