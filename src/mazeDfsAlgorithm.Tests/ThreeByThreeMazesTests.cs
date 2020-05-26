using NUnit.Framework;

namespace mazeDfsAlgorithm.Tests
{
    public class ThreeByThreeMazesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MazeIsSolveable_Variant1()
        {
            var maze = new int [,]{
                {0, 1 , 0, },
                {0, 1 , 0, },
                {0, 0 , 2, },
                };

            var result = new SearchThroughMaze(
                new Maze(maze), 
                newCord => { })
                .Search();

            Assert.IsTrue(result[4].Equals(new Coordinate { X = 0, Y = 0 }));
            Assert.IsTrue(result[3].Equals(new Coordinate { X = 1, Y = 0 }));
            Assert.IsTrue(result[2].Equals(new Coordinate { X = 2, Y = 0 }));
            Assert.IsTrue(result[1].Equals(new Coordinate { X = 2, Y = 1 }));
            Assert.IsTrue(result[0].Equals(new Coordinate { X = 2, Y = 2 }));
        }

        [Test]
        public void MazeIsSolveable_Variant2()
        {
            var maze = new int [,]{
                {0, 0 , 0, },
                {0, 1 , 0, },
                {0, 1 , 2, },
                };

            var result = new SearchThroughMaze(
                new Maze(maze), 
                newCord => { })
                .Search();

            Assert.IsTrue(result[4].Equals(new Coordinate { X = 0, Y = 0 }));
            Assert.IsTrue(result[3].Equals(new Coordinate { X = 0, Y = 1 }));
            Assert.IsTrue(result[2].Equals(new Coordinate { X = 0, Y = 2 }));
            Assert.IsTrue(result[1].Equals(new Coordinate { X = 1, Y = 2 }));
            Assert.IsTrue(result[0].Equals(new Coordinate { X = 2, Y = 2 }));
        }

        [Test]
        public void MazeIsUnsolvable()
        {
            var maze = new int [,]{
                {0, 1 , 0, },
                {1, 1 , 0, },
                {0, 1 , 2, },
                };

            var result = new SearchThroughMaze(
                new Maze(maze), 
                newCord => { })
                .Search();

            Assert.IsTrue(result.Count == 0);
        }
    }
}