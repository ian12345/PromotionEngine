using System.Collections.Generic;

namespace PromotionEngine
{
    public interface IPromotion
    {
        bool CanExecute(List<ProductQuantity> products);
        int Execute(List<ProductQuantity> products);
    }
}