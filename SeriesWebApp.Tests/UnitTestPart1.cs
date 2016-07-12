using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeriesWebApp.BusinessLayer;
using System.Collections.Generic;

namespace SeriesWebApp.Tests
{
    [TestClass()]
    public class UnitTestPart1
    {

        [TestMethod]
        public void generate_series_with_negative_seqNo_returns_emptyList()
        {
            // arrange
            ComplexSeries objSeriesGenerator = new ComplexSeries();
            var expected = new List<int>(); //blank list

            // act
            var actual = objSeriesGenerator.GenerateSeries(15, -1);

            //assert
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void generate_series_with_zero_seqNo_returns_emptyList()
        {
            // arrange
            ComplexSeries objSeriesGenerator = new ComplexSeries();
            var expected = new List<int>(); //blank list

            // act
            var actual = objSeriesGenerator.GenerateSeries(15, 0);

            //assert
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void generate_series_with_negative_term_returns_emptyList()
        {
            // arrange
            ComplexSeries objSeriesGenerator = new ComplexSeries();
            var expected = new List<int>(); //blank list

            // act
            var actual = objSeriesGenerator.GenerateSeries(-4);

            //assert
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void generate_series_with_maxTerm_ten_And_seqNo_two_returns_List()
        {
            // arrange
            ComplexSeries objSeriesGenerator = new ComplexSeries();
            var expected = new List<int>(new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 });

            // act
            var actual = objSeriesGenerator.GenerateSeries(10, 2);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void generate_series_with_maxTerm_fifteen_And_seqNo_three_returns_List()
        {
            // arrange
            ComplexSeries objSeriesGenerator = new ComplexSeries();
            var expected = new List<int>(new int[] { 1, 1, 1, 3, 5, 9, 17, 31, 57, 105, 193, 355, 653, 1201, 2209 });

            // act
            var actual = objSeriesGenerator.GenerateSeries(15, 3);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
