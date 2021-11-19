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
            var target = new PromotionCalculator();

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 1),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 1)
            };

            var total = target.Execute(items);
            Assert.AreEqual(115, total);
        }
    } 
    
    [TestClass]
    public class NItmesPromotionTest
    {
        

        [TestMethod]
        public void NoPromotionsApplicableReturnsFalseTest()
        {
            var target = new NItmesPromotion(3, new Product("A", 50));

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 1),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 1)
            };

            var actual = target.CanExecute(items);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void PromotionApplicableForProductTypeReturnsTrueTest()
        {
            var target = new NItmesPromotion(3, new Product("B", 50));

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 1),
                new ProductQuantity(new Product("B", 30), 3),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 1)
            };

            var actual = target.CanExecute(items);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void PromotionApplicableForProductTypeReturnsFalseWhenOtherProductHasCoorectQuantityTest()
        {
            var target = new NItmesPromotion(3, new Product("B", 50));

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 3),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 1)
            };

            var actual = target.CanExecute(items);
            Assert.IsFalse(actual);
        }
    }
}
