using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gopher;
using Gopher.Controllers;

namespace Gopher.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(null);

            // Act
            ViewResult result = controller.CustomersIndex(null, null, null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
