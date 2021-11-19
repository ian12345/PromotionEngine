using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class CombinationPromotion : IPromotion
    {
        private readonly Product _productOne;
        private Product _productTwo;
        private readonly int _promotionPrice;

        public CombinationPromotion(Product productOne, Product productTwo, int promotionPrice)
        {
            _productOne = productOne;
            _productTwo = productTwo;
            _promotionPrice = promotionPrice;
        }
        public bool CanExecute(List<ProductQuantity> products)
        {
            return !products.Any(x => x.Product.Type == _productOne.Type && x.Quantity > 0) && !products.Any(x => x.Product.Type == _productTwo.Type && x.Quantity > 0);            
        }

        public int Execute(List<ProductQuantity> products)
        {
            int productOneQuantity = products.Where(x => x.Product.Type == _productOne.Type && x.Quantity > 0).Sum(x=>x.Quantity);
            int productTwoQuantity = products.Where(x => x.Product.Type == _productTwo.Type && x.Quantity > 0).Sum(x=>x.Quantity);
            var quants = new List<int> { productOneQuantity, productTwoQuantity };
            int numberOfTImesOfferApplies = quants.Min();

            RemovePromotionEligbleProducts(products, numberOfTImesOfferApplies);
            return numberOfTImesOfferApplies * _promotionPrice;
        }

        private void RemovePromotionEligbleProducts(List<ProductQuantity> products, int numberOfTImesOfferApplies)
        {
            if (numberOfTImesOfferApplies == 0) return;
            var productOne = products.First(x => x.Product.Type == _productOne.Type);
            var productTwo = products.First(x => x.Product.Type == _productTwo.Type);
            productOne.Quantity -= numberOfTImesOfferApplies;
            productTwo.Quantity -= numberOfTImesOfferApplies;

        }
    }


    public class NItmesPromotion : IPromotion
    {
        private readonly int _numberOfItems;
        private readonly Product _product;
        private readonly int _promotionPrice;

        public NItmesPromotion(int numberOfItems, Product product, int promotionPrice)
        {
            _numberOfItems = numberOfItems;
            _product = product;
            _promotionPrice = promotionPrice;
        }

        public bool CanExecute(List<ProductQuantity> products)
        {
            return products.Any(x => x.Product.Type == _product.Type && x.Quantity >= _numberOfItems);
        }

        public int Execute(List<ProductQuantity> products)
        {
            var productsEligible = products.Where(x => x.Product.Type == _product.Type && x.Quantity >= _numberOfItems);
            int total = 0;
            foreach (var prod in productsEligible)
            {
                var numberOfTimesPromotionApplies = prod.Quantity / _numberOfItems;

                RemovePromotionEligbleProducts(prod, numberOfTimesPromotionApplies);
                total += numberOfTimesPromotionApplies * _promotionPrice;
            }
           
            return total;
        }

        private void RemovePromotionEligbleProducts(ProductQuantity prod, int numberOfTImesOfferApplies)
        {
            if (numberOfTImesOfferApplies == 0) return;
            prod.Quantity -= numberOfTImesOfferApplies * _numberOfItems;           

        }
    }


    public class ProductQuantity
    {
        public ProductQuantity(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Product
    {
        public Product(string type, int pricePerItem)
        {
            Type = type;
            PricePerItem = pricePerItem;
        }
        public string Type { get; set; }

        public int PricePerItem { get; set; }
    }


}