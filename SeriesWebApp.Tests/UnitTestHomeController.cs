using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Net.Http;
using SeriesWebApp.Controllers;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace SeriesWebApp.Tests
{
    [TestClass]
    public class UnitTestHomeController
    {
        [TestMethod]
        public void generate_series_with_maxTerm_four_returns_List()
        {
            // Arrange
            var expected = new List<int>(new int[] { 1, 1, 1, 3, 5, 9, 17, 31, 57, 105, 193, 355, 653, 1201, 2209 });
            var controller = new HomeController();

            // Act
            IHttpActionResult actionResult = controller.Get(15);
            var contentResult = actionResult as OkNegotiatedContentResult<List<int>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            CollectionAssert.AreEqual(expected, contentResult.Content);
        }

        [TestMethod]
        public void find_seriesElement_with_maxTerm_fifteen_And_divisor_three_And_term_four_returns_oneHundredFive()
        {
            // Arrange
            var expected = new List<int>(new int[] { 105 });
            var controller = new HomeController();

            // Act
            IHttpActionResult actionResult = controller.FindElement(15, 3, 4);
            var contentResult = actionResult as OkNegotiatedContentResult<int[]>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            CollectionAssert.AreEqual(expected, contentResult.Content);
        }

        [TestMethod]
        public void FindElementReturnsBadRequest()
        {
            // Arrange            
            var controller = new HomeController();

            // Act
            IHttpActionResult actionResult = controller.FindElement(15, 0, 0);

            // Assert 
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void GetReturnsBadRequest()
        {
            // Arrange            
            var controller = new HomeController();

            // Act
            IHttpActionResult actionResult = controller.Get(0);

            // Assert 
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void GetReturnsOk()
        {
            // Arrange            
            var controller = new HomeController();

            // Act
            IHttpActionResult actionResult = controller.Get(15);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<List<int>>));
        }

        [TestMethod]
        public void FindElementReturnsOk()
        {
            // Arrange            
            var controller = new HomeController();

            // Act
            IHttpActionResult actionResult = controller.FindElement(15, 3, 4);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<int[]>));
        }
    }
}
