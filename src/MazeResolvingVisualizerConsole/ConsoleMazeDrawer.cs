using mazeDfsAlgorithm;
using System;
using System.Threading;

namespace MazeResolvingVisualizerConsole
{
    internal class ConsoleMazeDrawer : IMazeDrawer
    {
        private ConsoleColor _defaultConsoleColor;

        public ConsoleMazeDrawer()
        {
            _defaultConsoleColor = Console.ForegroundColor;
        }
        public void RedrawMaze(Maze mazeObject)
        {
            Console.Clear();

            for (int x = 0; x < mazeObject.Height; x++)
            {
                for (int y = 0; y < mazeObject.Width; y++)
                {
                    Thread.Sleep(10);

                    var mazeValue = mazeObject.GetValueAt(new Coordinate() { X = x, Y = y });
                    SwitchConsoleColor(mazeValue);

                    Console.Write($"{mazeValue} ");
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = _defaultConsoleColor;
            Thread.Sleep(200);
        }

        private void SwitchConsoleColor(int mazeValue)
        {
            if (mazeValue == 8)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = _defaultConsoleColor;
            }
        }
    }
}
