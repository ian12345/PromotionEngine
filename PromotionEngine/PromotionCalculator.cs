using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class PromotionCalculator
    {
        List<IPromotion> _activePromotions = new List<IPromotion>
        {
            new NItmesPromotion(3, new Product("A", 50), 130),
            new NItmesPromotion(2, new Product("B", 30), 45),
            new CombinationPromotion(new Product("C", 20), new Product("D", 15), 30)
        };

        public int Execute(List<ProductQuantity> products)
        {
            int total = 0;
            var productsCopy = products.ToList(); // added so that the original list is not affected.

            total = _activePromotions.Where(x => x.CanExecute(productsCopy)).Sum(x=> x.Execute(productsCopy));

            foreach (var product in productsCopy)
            {
                total += product.Product.PricePerItem * product.Quantity;
            }

            return total;
        }
    }


}
