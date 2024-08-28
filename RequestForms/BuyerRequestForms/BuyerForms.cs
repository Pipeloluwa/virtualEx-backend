using virtual_ex.Models.Houses;
using virtual_ex.Models;

namespace virtual_ex.RequestForms.BuyerRequestForms
{
    public class BuyerReviewRegisterForm
    {
        public required string ProductId {  get; set; }
        public required double Rating { get; set; }
        public required string Review { get; set; }
    }


    public class BuyerReviewUpdateForm
    {
        public required string ReviewId { get; set; }
        public required double Rating { get; set; }
        public required string Review { get; set; }
    }


    public class BuyerProductForm
    {
        public required string ProductId { get; set; }
    }


    public class BuyerTransactionForm
    {
        public required string ProductId { get; set; }
        public required bool IsNormalBuy { get; set; }
        public required int Quantity { get; set; }
    }


}
