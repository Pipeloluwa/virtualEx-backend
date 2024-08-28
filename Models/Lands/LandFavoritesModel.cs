using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace virtual_ex.Models.Lands
{
    public class LandFavoritesModel
    {
        [Key]
        public Guid FavoriteId { get; set; } = Guid.NewGuid();

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


        //+++++++ RELATIONSHIPS +++++++
        public Guid? UserIdRelationship { get; set; }
        public UserBuyerModel? UserRelationship { get; set; }

        public Guid? LandIdRelationship { get; set; }
        public LandModel? LandRelationship { get; set; }
    }
}
