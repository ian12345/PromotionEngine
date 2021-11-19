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
                new ProductQuantity(new Product("D", 15), 0)
            };

            var total = target.Execute(items);
            Assert.AreEqual(100, total);
        }

     
        [TestMethod]
        public void ScenarioATest()
        {
            var target = new PromotionCalculator();

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 1),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 0)
            };

            var total = target.Execute(items);
            Assert.AreEqual(100, total);
        }
        [TestMethod]

        public void ScenarioBTest()
        {
            var target = new PromotionCalculator();

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 5),
                new ProductQuantity(new Product("B", 30), 5),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 0)
            };

            var total = target.Execute(items);
            Assert.AreEqual(
                370, total);
        }

        [TestMethod]

        public void ScenarioCTest()
        {
            var target = new PromotionCalculator();

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 3),
                new ProductQuantity(new Product("B", 30), 5),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 1)
            };

            var total = target.Execute(items);
            Assert.AreEqual(
                280, total);
        }
    } 
    
    [TestClass]
    public class NItmesPromotionTest
    {
        

        [TestMethod]
        public void NoPromotionsApplicableReturnsFalseTest()
        {
            var target = new NItmesPromotion(3, new Product("A", 50), 130);

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
            var target = new NItmesPromotion(3, new Product("B", 50), 130);

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
        public void PromotionNotApplicableReturns0Test()
        {
            var target = new NItmesPromotion(3, new Product("A", 50), 130);

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 1),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 1)
            };

            var actual = target.Execute(items);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void PromotionApplicableOnceTest()
        {
            var target = new NItmesPromotion(3, new Product("A", 50), 130);

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 3),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 1)
            };

            var actual = target.Execute(items);
            Assert.AreEqual(130, actual);
        }

        public void PromotionApplicableOnceWithRemainderTest()
        {
            var target = new NItmesPromotion(3, new Product("A", 50), 130);

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 4),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 1)
            };

            var actual = target.Execute(items);
            Assert.AreEqual(130, actual);
        }

        public void PromotionApplicable5timesTest()
        {
            var target = new NItmesPromotion(3, new Product("A", 50), 130);

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 16),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 1)
            };

            var actual = target.Execute(items);
            Assert.AreEqual(650, actual);
        }

    }


    [TestClass]
    public class CombinationPromotionTest
    {


        [TestMethod]
        public void NoPromotionApplicableNoitemCQuantityReturnsFalseTest()
        {
            var target = new CombinationPromotion(new Product("C", 20), new Product("D", 15), 30);

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 1),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 0),
                new ProductQuantity(new Product("D", 15), 1)
            };

            var actual = target.CanExecute(items);
            Assert.IsFalse(actual);
        }
        

        [TestMethod]
        public void NoPromotionApplicableNoitemCReturnsFalseTest()
        {
            var target = new CombinationPromotion(new Product("C", 20), new Product("D", 15), 30);

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 1),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("D", 15), 1)
            };

            var actual = target.CanExecute(items);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void NoPromotionApplicableNoitemDQuantityReturnsFalseTest()
        {
            var target = new CombinationPromotion(new Product("C", 20), new Product("D", 15), 30);

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 1),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 0)
            };

            var actual = target.CanExecute(items);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void PromotionApplicableReturnsTrueTest()
        {
            var target = new CombinationPromotion(new Product("C", 20), new Product("D", 15), 30);

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 1),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 1)
            };

            var actual = target.CanExecute(items);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void NoPromotionApplicableNoitemDReturnsFalseTest()
        {
            var target = new CombinationPromotion(new Product("C", 20), new Product("D", 15), 30);

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 1),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 1)
            };

            var actual = target.CanExecute(items);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void NoPromotionApplicableReturns0Test()
        {
            var target = new CombinationPromotion(new Product("C", 20), new Product("D", 15), 30);

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 1),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 0)
            };

            var actual = target.Execute(items);
            Assert.AreEqual(actual, 0);
        }


        [TestMethod]
        public void OnePromotionApplicableReturns30Test()
        {
            var target = new CombinationPromotion(new Product("C", 20), new Product("D", 15), 30);

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 1),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), 1),
                new ProductQuantity(new Product("D", 15), 1)
            };

            var actual = target.Execute(items);
            Assert.AreEqual(actual, 30);
        }

        [TestMethod]
        public void NPromotionsApplicableReturnsNtimes30Test()
        {
            int quantity = new Random(((int)DateTime.Now.Ticks)).Next(0, 400);
            var target = new CombinationPromotion(new Product("C", 20), new Product("D", 15), 30);

            var items = new List<ProductQuantity>
            {
                new ProductQuantity(new Product("A", 50), 1),
                new ProductQuantity(new Product("B", 30), 1),
                new ProductQuantity(new Product("C", 20), quantity),
                new ProductQuantity(new Product("D", 15), quantity)
            };

            var actual = target.Execute(items);
            Assert.AreEqual(actual, 30 * quantity);
        }
    }
    }
