using Xunit;
using SimpleAlgebra.utils;
using SimpleAlgebra.Models;

namespace SimpleAlgebra.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(63, 9 * 7);
        }

        [Fact]
        public void FailingTest()
        {
            //Test to see where double equality ends - apparently this still passes
            Assert.Equal(0.0000000000000000001, 0.0000000000000000001);
        }

        [Fact]
        public void CoordinateTest()
        {
            //Arrange
            int[] coordinates = new int[] {Calc.ReselectIfZero(12), Calc.ReselectIfZero(12)};

            Assert.InRange(coordinates[0] * coordinates[1], -144, 144);
        }

        [Fact]
        public void StandardLineTest1()
        {
            //Arrange
            StandardLine standardline = new StandardLine();

            //Act
            int maxValue = 144;

            //Assert
            Assert.True(maxValue >= standardline.referencePtSL2[0] * standardline.referencePtSL2[1]);
        }

        [Fact]
        public void ZeroPolyTest()
        {
            //Arrange
            int[] zeroes123 = new int[] {1,2,3};
            int[] coefficients123 = Calc.ZeroesToPolyCoefficients(zeroes123);

            //Assert
            Assert.Equal(1,coefficients123[0]);
            Assert.Equal(-6,coefficients123[1]);
            Assert.Equal(11,coefficients123[2]);
            Assert.Equal(-6,coefficients123[3]);
        }

        [Fact]
        public void PolyPathStrTest()
        {
            //Intentional Fail
            //Arrange
            double[] coefs1 = new double[] { 1.0, 0.0, -25.0 };
            string pathStr1 = SVG.SVGPolyPath(-10.0, 10.0, 5.0, coefs1);

            Assert.Equal("", pathStr1);
        }

        [Fact]
        public void QuadraticDemoPath()
        {
            //Arrange
            QuadraticDemo qDemo = new QuadraticDemo();

            Assert.Equal("", qDemo.DoubleUniqueReal1);
        }
    }
}