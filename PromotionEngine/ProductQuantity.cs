using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class CombinationPromotion : IPromotion
    {
        private readonly List<Product> _promotionProducts;

        public CombinationPromotion(List<Product> products)
        {

            _promotionProducts = products;

        }
        public bool CanExecute(List<ProductQuantity> products)
        {
            throw new System.NotImplementedException();
        }

        public int Execute(List<ProductQuantity> products)
        {
            throw new System.NotImplementedException();
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
                var numberOfTimesPromotinApplies = prod.Quantity / _numberOfItems;
        
                
                total += numberOfTimesPromotinApplies * _promotionPrice;
            }
            return total;
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