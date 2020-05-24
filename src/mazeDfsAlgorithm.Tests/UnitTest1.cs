using NUnit.Framework;

namespace mazeDfsAlgorithm.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var maze = new int [,]{
                {0, 1 , 0, },
                {0, 1 , 0, },
                {0, 0 , 2, },
                };

            var result = SearchThroughMaze.Search(maze);

            // 0 , 0
            // 1 , 0
            // 2 , 0
            // 2 , 1
            // 2 , 2
            foreach (var entry in result)
                System.Console.WriteLine($"X: {entry.X}, Y: {entry.Y}");
            Assert.IsTrue(result[4].Equals(new Coordinate { X = 0, Y = 0 }));
            Assert.IsTrue(result[3].Equals(new Coordinate { X = 1, Y = 0 }));
            Assert.IsTrue(result[2].Equals(new Coordinate { X = 2, Y = 0 }));
            Assert.IsTrue(result[1].Equals(new Coordinate { X = 2, Y = 1 }));
            Assert.IsTrue(result[0].Equals(new Coordinate { X = 2, Y = 2 }));
        }

        [Test]
        public void Test_3x3_maze_2()
        {
            var maze = new int [,]{
                {0, 0 , 0, },
                {0, 1 , 0, },
                {0, 1 , 2, },
                };

            var result = SearchThroughMaze.Search(maze);

            // 0 , 0
            // 1 , 0
            // 2 , 0
            // 2 , 1
            // 2 , 2
            foreach (var entry in result)
                System.Console.WriteLine($"X: {entry.X}, Y: {entry.Y}");
            Assert.IsTrue(result[4].Equals(new Coordinate { X = 0, Y = 0 }));
            Assert.IsTrue(result[3].Equals(new Coordinate { X = 0, Y = 1 }));
            Assert.IsTrue(result[2].Equals(new Coordinate { X = 0, Y = 2 }));
            Assert.IsTrue(result[1].Equals(new Coordinate { X = 1, Y = 2 }));
            Assert.IsTrue(result[0].Equals(new Coordinate { X = 2, Y = 2 }));
        }

        [Test]
        public void Test2()
        {
            var maze = new int [,]{
                {0, 1 , 0, 0, 0},
                {0, 1 , 0, 1, 0},
                {0, 1 , 0, 1, 0},
                {0, 1 , 0, 1, 0},
                {0, 0 , 0, 1, 2},
                };

            var result = SearchThroughMaze.Search(maze);

            // 0 , 0
            // 1 , 0
            // 2 , 0
            // 3 , 0
            // 4 , 0
            // 4 , 1
            // 4 , 2
            // 3 , 2
            // 2 , 2
            // 1 , 2
            // 0 , 2
            Assert.IsTrue(result[16].Equals(new Coordinate { X = 0, Y = 0 }));
            Assert.IsTrue(result[15].Equals(new Coordinate { X = 1, Y = 0 }));
            Assert.IsTrue(result[14].Equals(new Coordinate { X = 2, Y = 0 }));
            Assert.IsTrue(result[13].Equals(new Coordinate { X = 3, Y = 0 }));
            Assert.IsTrue(result[12].Equals(new Coordinate { X = 4, Y = 0 }));
            Assert.IsTrue(result[11].Equals(new Coordinate { X = 4, Y = 1 }));
            Assert.IsTrue(result[10].Equals(new Coordinate { X = 4, Y = 2 }));
            Assert.IsTrue(result[9].Equals(new Coordinate { X = 3, Y = 2 }));
            Assert.IsTrue(result[8].Equals(new Coordinate { X = 2, Y = 2 }));
            Assert.IsTrue(result[7].Equals(new Coordinate { X = 1, Y = 2 }));
            Assert.IsTrue(result[6].Equals(new Coordinate { X = 0, Y = 2 }));
            Assert.IsTrue(result[5].Equals(new Coordinate { X = 0, Y = 3 }));
            Assert.IsTrue(result[4].Equals(new Coordinate { X = 0, Y = 4 }));
            Assert.IsTrue(result[3].Equals(new Coordinate { X = 1, Y = 4 }));
            Assert.IsTrue(result[2].Equals(new Coordinate { X = 2, Y = 4 }));
            Assert.IsTrue(result[1].Equals(new Coordinate { X = 3, Y = 4 }));
            Assert.IsTrue(result[0].Equals(new Coordinate { X = 4, Y = 4 }));
        }

        [Test]
        public void Test22()
        {
            var maze = new int [,]{
                {0, 1 , 0, 0, 0},
                {0, 1 , 0, 1, 0},
                {0, 1 , 0, 1, 0},
                {0, 1 , 0, 1, 0},
                {0, 0 , 0, 1, 0},
                };

            var result = SearchThroughMaze.Search(maze);
            Assert.IsTrue(result.Count == 0);
        }
    }
}