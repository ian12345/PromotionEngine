using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class PromotionCalculator
    {
        public int Execute(List<ProductQuantity> products)
        {
            int total = 0;

            foreach (var product in products)
            {
                total += product.Product.PricePerItem * product.Quantity;
            }

            return total;
        }
    }


}
