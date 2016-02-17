using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Honda";
            currentProduct.ProductId = 2346;
            currentProduct.Description = "Nice car from Japan";
            currentProduct.ProductVendor.CompanyName = "Honda Ltd.";
            var expected = "Hello Honda (2346): Nice car from Japan" + " Available on: ";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHello_ParameterizedConstructor_Test()
        {
            //Arrange
            var currentProduct = new Product("Honda", 2346, "Nice car from Japan");
            var expected = "Hello Honda (2346): Nice car from Japan" + " Available on: ";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHello_ObjectInitializer_Test()
        {
            //Arrange
            var currentProduct = new Product
            {
                ProductName = "Honda",
                ProductId = 2346,
                Description = "Nice car from Japan",
            };

            var expected = "Hello Honda (2346): Nice car from Japan" + " Available on: ";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}