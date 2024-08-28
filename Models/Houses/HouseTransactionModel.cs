using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace virtual_ex.Models.Houses
{
    //++++++++++++ TODO: I SHOULD DESIGN IN MY CONTROLLER CODE TO RESTRICT A USER FROM RESCHEDULING AGAIN AFTER HIS/HER FIRST SCHEDULED PERIOD HAS BEEN EXPIRED +++++++
    public class HouseTransactionModel
    {
        [Key]
        public Guid TransactionId { get; set; } = Guid.NewGuid();

        public required bool IsNormalBuy { get; set; }
        public required int Quantity { get; set; }
        public required string ScheduleFee { get; set; }
        public bool IsSchedulePeriodExpired { get; set; } = false;
        public bool IsSold { get; set; } = false;

        [Column(TypeName = "datetime")]
        public DateTime ScheduleInitiatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ScheduleInitiatedDateExpired { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? TourDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? SoldDate { get; set; }


        //+++++++ RELATIONSHIPS +++++++
        public Guid? UserBuyerIdRelationship { get; set; }
        public UserBuyerModel? UserBuyerRelationship { get; set; }

        public Guid? HouseIdRelationship { get; set; }
        public HouseModel? HouseRelationship { get; set; }
    }


}
