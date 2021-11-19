using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class NItmesPromotion 
    {
        private readonly int _numberOfItems;
        private readonly Product _product;

        public NItmesPromotion(int numberOfItems, Product product)
        {
            _numberOfItems = numberOfItems;
            _product = product;
        }

        public bool CanExecute(List<ProductQuantity> products) {
            return products.Any(x=> x.Product.Type == _product.Type && x.Quantity >= _numberOfItems);
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