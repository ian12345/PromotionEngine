using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;

namespace PromotionEngineTests
{
    [TestClass]
    public class PromotionCalculatorTest
    {
        [TestMethod]
        public void CanConstructCalculatorTest()
        {
            var con = new PromotionCalculator();
        }

        [TestMethod]
        public void NoPromotionsApplicableTest()
        {
            var con = new PromotionCalculator();

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 1),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 1)
            };

            var total = con.Execute(items);
            Assert.AreEqual(115, total);
        }
    }
}
