using System;
using Xunit;

namespace PacmanTests
{
    public class MapTest
    {
        [Fact]
        public void MapShould_HaveATwoDimensionalArrayOfSquares()
        {
            var map = new Map();
            var result = map.Grid;
            Assert.IsType<[,]Square>(result);
        }
    }
}