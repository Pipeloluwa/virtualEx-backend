using System.ComponentModel.DataAnnotations.Schema;
using virtual_ex.Models.Houses;
using virtual_ex.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using virtual_ex.Models.Lands;
using virtual_ex.Models.Materials;
using Google.Api.Gax;
using System.Linq;

namespace virtual_ex.ResponseForms.BuyerResponseForms
{

    public class BuyerHouseBaseResponse(HouseModel? houseModel)
    {
        public string? HouseId { get; set; } = houseModel.HouseId.ToString();
        public int? NoOfHouse { get; set; } = houseModel.NoOfHouse;
        public string? Title { get; set; } = houseModel.Title;
        public string? Price { get; set; } = houseModel.Price;
        public string? CrossedPrice { get; set; } = houseModel.CrossedPrice;
        public string? Location { get; set; } = houseModel.Location;
        public string? CoverPicture { get; set; } = houseModel.CoverPicture;
        public double? Rating { get; set; } = houseModel.Rating;

    }




    public class BuyerHousePictureResponse(HousePictureModel housePictureModel)
    {
        public string? Picture { get; set; } = housePictureModel.Picture;
    }



    public class BuyerHouseAmenityResponse(HouseAmenityModel houseAmenityModel)
    {
        public string? Amenity { get; set; } = houseAmenityModel.Amenity;
    }



    public class BuyerHousePlacesNearbyResponse(HousePlacesNearbyModel housePlacesNearbyModel)
    {
        public string? Place { get; set; } = housePlacesNearbyModel.Place;

    }



    public class BuyerHouseReviewResponse(HouseReviewModel houseReviewModel)
    {
        public double? UserRating { get; set; } = houseReviewModel.UserRating;
        public string? Review { get; set; } = houseReviewModel.Review;
        public UserModel? UserModelRelationship { get; set; } = houseReviewModel.UserModelRelationship;
        public HouseModel? HouseRelationship { get; set; } = houseReviewModel.HouseRelationship;

    }



    public class BuyerHouseSellerProfileResponse(UserSellerModel userSellerModel)
    {
        public string? FirstName { get; set; } = userSellerModel.FirstName;
        public bool? IsAnOrganization { get; set; } = userSellerModel.IsAnOrganization;
        public string? ProfilePicture { get; set; } = userSellerModel.ProfilePicture;
        public string? Email { get; set; } = userSellerModel.UserRelationship.Email;
        public string? PhoneNumber { get; set; } = userSellerModel.UserRelationship.PhoneNumber;

    }




    public class BuyerHouseAgentProfileResponse(UserAgentModel userAgentModel)
    {
        public string? FirstName { get; set; } = userAgentModel.FirstName;
        public string? ProfilePicture { get; set; } = userAgentModel.ProfilePicture;
        public string? Email { get; set; } = userAgentModel.UserRelationship.Email;
        public string? PhoneNumber { get; set; } = userAgentModel.UserRelationship.PhoneNumber;


    }



    public class BuyerHouseOneResponse(HouseModel houseModel): BuyerHouseBaseResponse(houseModel)
    {
        public bool? IsScheduled { get; set; } = houseModel.IsScheduled;
        public string? Category {  get; set; } = houseModel.Category;
        public string? Video {  get; set; } = houseModel.Video;
        public string? Description {  get; set; } = houseModel.Description;
        public BuyerHousePictureResponse? HousePicturesRelationship {  get; set; } = houseModel.HousePicturesRelationship
                .Select(model => new BuyerHousePictureResponse(model))
                as BuyerHousePictureResponse;
        public BuyerHouseSellerProfileResponse? UserSellerRelationship { get; set; } = new BuyerHouseSellerProfileResponse(houseModel.UserSellerRelationship);
        public BuyerHouseAgentProfileResponse? AgentRelationship { get; set; } = new BuyerHouseAgentProfileResponse(houseModel.AgentRelationship);

        public ICollection<BuyerHouseAmenityResponse>? HouseAmenitiesRelationship {  get; set; } = houseModel.HouseAmenitiesRelationship
                .Select(model => new BuyerHouseAmenityResponse(model))
                .ToList();
        public ICollection<BuyerHousePlacesNearbyResponse>? HousePlacesNearbyRelationship {  get; set; } = houseModel.HousePlacesNearbyRelationship
                .Select(model => new BuyerHousePlacesNearbyResponse(model))
                .ToList();
        public ICollection<BuyerHouseReviewResponse>? HouseReviewRelationship {  get; set; } = houseModel.HouseReviewRelationship
                .Select(model => new BuyerHouseReviewResponse(model))
                .ToList();


    }


    public class BuyerHouseFavoritesResponse(HouseFavoritesModel houseFavoritesModel)
    {
        public string? FavoriteId { get; set; }= houseFavoritesModel.FavoriteId.ToString();
        public string? CreatedDate { get; set; }= houseFavoritesModel.CreatedDate.ToString();


        //+++++++ RELATIONSHIPS +++++++
        public string? HouseIdRelationship { get; set; }= houseFavoritesModel.HouseIdRelationship.ToString();
        public BuyerHouseBaseResponse? HouseRelationship { get; set; }= new BuyerHouseBaseResponse(houseFavoritesModel.HouseRelationship);

    }



}
