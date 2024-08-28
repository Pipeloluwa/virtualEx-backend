using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace virtual_ex.Models.Houses
{
    public class HouseFavoritesModel
    {
        [Key]
        public Guid FavoriteId { get; set; } = Guid.NewGuid();

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


        //+++++++ RELATIONSHIPS +++++++
        public Guid? UserIdRelationship { get; set; }
        public UserBuyerModel? UserRelationship { get; set; }

        public Guid? HouseIdRelationship { get; set; }
        public HouseModel? HouseRelationship { get; set; }
    }
}
