using System;
using Xunit;
using ChildrensGame.Core;

namespace ChildrensGame.Test
{
    public class GameTests
    {
        [Fact]
        public void GenerateSequence_Valid_Success()
        {
            int[] expected = { 0, 1, 2, 3, 4 };
            var manifest = new GameManifest() { Id = 1, ChildrenCount = 5, EliminateEach = 3 };
            var game = new Game(manifest);
            Assert.Equal(expected, game.Children.ToArray());
        }

        [Fact]
        public void GenerateSequence_Invalid_ExceptionThrown()
        {
            var manifest = new GameManifest() { Id = 1, ChildrenCount = 0, EliminateEach = 3 };
            Exception ex = Assert.Throws<ArgumentException>(() => new Game(manifest));
            Assert.Equal("Invalid: size must be larger than 0", ex.Message);
        }

        [Fact]
        public void GetEliminationSequence_Valid_Success()
        {
            var manifest = new GameManifest() { Id = 1, ChildrenCount = 5, EliminateEach = 3 };
            var game = new Game(manifest);
            var result = game.Play();

            int expectedWinner = 3;
            string expectedResult = "\nId=1\nWinner=3\nEliminationOrder=[2,0,4,1]\n";
            int[] expectedOrderOfElimination = { 2, 0, 4, 1 };

            Assert.Equal(expectedOrderOfElimination, result.EliminationOrder);
            Assert.Equal(expectedWinner, result.Winner);
            Assert.Equal(expectedResult, result.ToString());

        }

        [Fact]
        public void GetEliminationSequence_Invalid_ExceptionThrown()
        {
            var manifest = new GameManifest() { Id = 1, ChildrenCount = 5, EliminateEach = 0 };
            var game = new Game(manifest);
            var argumentException = Assert.Throws<ArgumentException>(() => game.Play());
            Assert.Equal("Invalid: seed must be larger than 0", argumentException.Message);
        }

        [Fact]
        public void ToString_Success()
        {
            var manifest = new GameManifest() { Id = 1, ChildrenCount = 5, EliminateEach = 5 };
            var game = new Game(manifest);

            var expected = "\nId=1\nChildrenCount=5\nSeed=5\n";

            Assert.Equal(expected, game.ToString());
        }
    }
}
