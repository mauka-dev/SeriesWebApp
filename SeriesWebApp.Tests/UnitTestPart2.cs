using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeriesWebApp.BusinessLayer;

namespace SeriesWebApp.Tests
{
    /// <summary>
    /// Summary description for UnitTestPart2
    /// </summary>
    [TestClass()]
    public class UnitTestPart2
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void find_seriesElement_with_negative_divisor_throws_exception()
        {
            // arrange
            ComplexSeries objSeriesGenerator = new ComplexSeries();

            // act
            var actual = objSeriesGenerator.FindSeriesElement(15, -1, 1);

            // assert is handled by the ExpectedException            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void find_seriesElement_with_negative_index_throws_exception()
        {
            // arrange
            ComplexSeries objSeriesGenerator = new ComplexSeries();

            // act
            var actual = objSeriesGenerator.FindSeriesElement(15, 3, -1);

            // assert is handled by the ExpectedException            
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void find_seriesElement_with_divisor_zero_throws_exception()
        {
            // arrange
            ComplexSeries objSeriesGenerator = new ComplexSeries();

            // act
            var actual = objSeriesGenerator.FindSeriesElement(15, 0, 1);

            // assert is handled by the ExpectedException            
        }

        [TestMethod]
        public void find_seriesElement_with_maxTerm_fifteen_And_divisor_three_And_index_one_returns_three()
        {
            // arrange
            ComplexSeries objSeriesGenerator = new ComplexSeries();
            var expected = 3;

            // act
            var actual = objSeriesGenerator.FindSeriesElement(15, 3, 1);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void find_seriesElement_with_maxTerm_fifteen_And_divisor_three_And_index_two_returns_nine()
        {
            // arrange
            ComplexSeries objSeriesGenerator = new ComplexSeries();
            var expected = 9;

            // act
            var actual = objSeriesGenerator.FindSeriesElement(15, 3, 2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void find_seriesElement_with_maxTerm_fifteen_And_divisor_three_And_index_three_returns_fiftySeven()
        {
            // arrange
            ComplexSeries objSeriesGenerator = new ComplexSeries();
            var expected = 57;

            // act
            var actual = objSeriesGenerator.FindSeriesElement(15, 3, 3);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
