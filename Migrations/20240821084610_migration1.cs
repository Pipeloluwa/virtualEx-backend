using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace virtual_ex.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserSelectedLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseAmenityModel",
                columns: table => new
                {
                    HouseAmenitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amenity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseAmenityModel", x => x.HouseAmenitiesId);
                });

            migrationBuilder.CreateTable(
                name: "HousePlacesNearbyModel",
                columns: table => new
                {
                    PlacesNearbyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousePlacesNearbyModel", x => x.PlacesNearbyId);
                });

            migrationBuilder.CreateTable(
                name: "LandAmenityModel",
                columns: table => new
                {
                    LandAmenitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amenity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandAmenityModel", x => x.LandAmenitiesId);
                });

            migrationBuilder.CreateTable(
                name: "LandPlacesNearbyModel",
                columns: table => new
                {
                    PlacesNearbyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Places = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandPlacesNearbyModel", x => x.PlacesNearbyId);
                });

            migrationBuilder.CreateTable(
                name: "MaterialAmenityModel",
                columns: table => new
                {
                    MaterialAmenitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amenity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialAmenityModel", x => x.MaterialAmenitiesId);
                });

            migrationBuilder.CreateTable(
                name: "MaterialPlacesNearbyModel",
                columns: table => new
                {
                    PlacesNearbyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Places = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialPlacesNearbyModel", x => x.PlacesNearbyId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleSettingsModels",
                columns: table => new
                {
                    SchedulId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NormalScheduledFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomScheduledFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaximumFridayTourSchedule = table.Column<int>(type: "int", nullable: false),
                    MaximumSaturdayTourSchedule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleSettingsModels", x => x.SchedulId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAgentModels",
                columns: table => new
                {
                    UserAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAgentEngaged = table.Column<bool>(type: "bit", nullable: false),
                    EngagementExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIdRelationship = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MeansOfIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAgentModels", x => x.UserAgentId);
                    table.ForeignKey(
                        name: "FK_UserAgentModels_AspNetUsers_UserIdRelationship",
                        column: x => x.UserIdRelationship,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserBuyerModels",
                columns: table => new
                {
                    UserBuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIdRelationship = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBuyerModels", x => x.UserBuyerId);
                    table.ForeignKey(
                        name: "FK_UserBuyerModels_AspNetUsers_UserIdRelationship",
                        column: x => x.UserIdRelationship,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserSellerModels",
                columns: table => new
                {
                    UserSellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAnOrganization = table.Column<bool>(type: "bit", nullable: true),
                    UserIdRelationship = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MeansOfIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSellerModels", x => x.UserSellerId);
                    table.ForeignKey(
                        name: "FK_UserSellerModels_AspNetUsers_UserIdRelationship",
                        column: x => x.UserIdRelationship,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HouseModel",
                columns: table => new
                {
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsScheduled = table.Column<bool>(type: "bit", nullable: false),
                    AllowMultipleSchedule = table.Column<bool>(type: "bit", nullable: false),
                    NoOfHouse = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrossedPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ObtainableRatings = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserSellerIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseModel", x => x.HouseId);
                    table.ForeignKey(
                        name: "FK_HouseModel_UserAgentModels_AgentIdRelationship",
                        column: x => x.AgentIdRelationship,
                        principalTable: "UserAgentModels",
                        principalColumn: "UserAgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseModel_UserSellerModels_UserSellerIdRelationship",
                        column: x => x.UserSellerIdRelationship,
                        principalTable: "UserSellerModels",
                        principalColumn: "UserSellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandModel",
                columns: table => new
                {
                    LandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsScheduled = table.Column<bool>(type: "bit", nullable: false),
                    AllowMultipleSchedule = table.Column<bool>(type: "bit", nullable: false),
                    NoOfLand = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrossedPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlacesNearby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    ObtainableRatings = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserSellerIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandModel", x => x.LandId);
                    table.ForeignKey(
                        name: "FK_LandModel_UserAgentModels_AgentIdRelationship",
                        column: x => x.AgentIdRelationship,
                        principalTable: "UserAgentModels",
                        principalColumn: "UserAgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandModel_UserSellerModels_UserSellerIdRelationship",
                        column: x => x.UserSellerIdRelationship,
                        principalTable: "UserSellerModels",
                        principalColumn: "UserSellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialModel",
                columns: table => new
                {
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsScheduled = table.Column<bool>(type: "bit", nullable: false),
                    AllowMultipleSchedule = table.Column<bool>(type: "bit", nullable: false),
                    NoOfMaterial = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrossedPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlacesNearby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    ObtainableRatings = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserSellerIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialModel", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_MaterialModel_UserAgentModels_AgentIdRelationship",
                        column: x => x.AgentIdRelationship,
                        principalTable: "UserAgentModels",
                        principalColumn: "UserAgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialModel_UserSellerModels_UserSellerIdRelationship",
                        column: x => x.UserSellerIdRelationship,
                        principalTable: "UserSellerModels",
                        principalColumn: "UserSellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseFavoritesModel",
                columns: table => new
                {
                    FavoriteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HouseIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseFavoritesModel", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_HouseFavoritesModel_HouseModel_HouseIdRelationship",
                        column: x => x.HouseIdRelationship,
                        principalTable: "HouseModel",
                        principalColumn: "HouseId");
                    table.ForeignKey(
                        name: "FK_HouseFavoritesModel_UserBuyerModels_UserIdRelationship",
                        column: x => x.UserIdRelationship,
                        principalTable: "UserBuyerModels",
                        principalColumn: "UserBuyerId");
                });

            migrationBuilder.CreateTable(
                name: "HouseJoinHouseAmenityModel",
                columns: table => new
                {
                    HouseAmenityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseJoinHouseAmenityModel", x => new { x.HouseAmenityId, x.HouseModelId });
                    table.ForeignKey(
                        name: "FK_HouseJoinHouseAmenityModel_HouseAmenityModel_HouseAmenityId",
                        column: x => x.HouseAmenityId,
                        principalTable: "HouseAmenityModel",
                        principalColumn: "HouseAmenitiesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseJoinHouseAmenityModel_HouseModel_HouseModelId",
                        column: x => x.HouseModelId,
                        principalTable: "HouseModel",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseJoinPlacesNearbyModel",
                columns: table => new
                {
                    HouseModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlacesNearbyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseJoinPlacesNearbyModel", x => new { x.HouseModelId, x.PlacesNearbyId });
                    table.ForeignKey(
                        name: "FK_HouseJoinPlacesNearbyModel_HouseModel_HouseModelId",
                        column: x => x.HouseModelId,
                        principalTable: "HouseModel",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseJoinPlacesNearbyModel_HousePlacesNearbyModel_PlacesNearbyId",
                        column: x => x.PlacesNearbyId,
                        principalTable: "HousePlacesNearbyModel",
                        principalColumn: "PlacesNearbyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HousePictureModel",
                columns: table => new
                {
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HouseIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousePictureModel", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_HousePictureModel_HouseModel_HouseIdRelationship",
                        column: x => x.HouseIdRelationship,
                        principalTable: "HouseModel",
                        principalColumn: "HouseId");
                });

            migrationBuilder.CreateTable(
                name: "HouseReviewModel",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRating = table.Column<double>(type: "float", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModelRelationshipId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HouseIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserSellerModelUserSellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseReviewModel", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_HouseReviewModel_AspNetUsers_UserModelRelationshipId",
                        column: x => x.UserModelRelationshipId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HouseReviewModel_HouseModel_HouseIdRelationship",
                        column: x => x.HouseIdRelationship,
                        principalTable: "HouseModel",
                        principalColumn: "HouseId");
                    table.ForeignKey(
                        name: "FK_HouseReviewModel_UserSellerModels_UserSellerModelUserSellerId",
                        column: x => x.UserSellerModelUserSellerId,
                        principalTable: "UserSellerModels",
                        principalColumn: "UserSellerId");
                });

            migrationBuilder.CreateTable(
                name: "HouseTransactionModel",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsNormalBuy = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ScheduleFee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSchedulePeriodExpired = table.Column<bool>(type: "bit", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    ScheduleInitiatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ScheduleInitiatedDateExpired = table.Column<DateTime>(type: "datetime", nullable: true),
                    TourDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SoldDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserBuyerIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HouseIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseTransactionModel", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_HouseTransactionModel_HouseModel_HouseIdRelationship",
                        column: x => x.HouseIdRelationship,
                        principalTable: "HouseModel",
                        principalColumn: "HouseId");
                    table.ForeignKey(
                        name: "FK_HouseTransactionModel_UserBuyerModels_UserBuyerIdRelationship",
                        column: x => x.UserBuyerIdRelationship,
                        principalTable: "UserBuyerModels",
                        principalColumn: "UserBuyerId");
                });

            migrationBuilder.CreateTable(
                name: "LandFavoritesModel",
                columns: table => new
                {
                    FavoriteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LandIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandFavoritesModel", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_LandFavoritesModel_LandModel_LandIdRelationship",
                        column: x => x.LandIdRelationship,
                        principalTable: "LandModel",
                        principalColumn: "LandId");
                    table.ForeignKey(
                        name: "FK_LandFavoritesModel_UserBuyerModels_UserIdRelationship",
                        column: x => x.UserIdRelationship,
                        principalTable: "UserBuyerModels",
                        principalColumn: "UserBuyerId");
                });

            migrationBuilder.CreateTable(
                name: "LandJoinLandAmenityModel",
                columns: table => new
                {
                    LandAmenityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LandModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandJoinLandAmenityModel", x => new { x.LandAmenityId, x.LandModelId });
                    table.ForeignKey(
                        name: "FK_LandJoinLandAmenityModel_LandAmenityModel_LandAmenityId",
                        column: x => x.LandAmenityId,
                        principalTable: "LandAmenityModel",
                        principalColumn: "LandAmenitiesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandJoinLandAmenityModel_LandModel_LandModelId",
                        column: x => x.LandModelId,
                        principalTable: "LandModel",
                        principalColumn: "LandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandJoinPlacesNearbyModel",
                columns: table => new
                {
                    LandModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlacesNearbyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandJoinPlacesNearbyModel", x => new { x.LandModelId, x.PlacesNearbyId });
                    table.ForeignKey(
                        name: "FK_LandJoinPlacesNearbyModel_LandModel_LandModelId",
                        column: x => x.LandModelId,
                        principalTable: "LandModel",
                        principalColumn: "LandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandJoinPlacesNearbyModel_LandPlacesNearbyModel_PlacesNearbyId",
                        column: x => x.PlacesNearbyId,
                        principalTable: "LandPlacesNearbyModel",
                        principalColumn: "PlacesNearbyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandPictureModel",
                columns: table => new
                {
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LandIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandPictureModel", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_LandPictureModel_LandModel_LandIdRelationship",
                        column: x => x.LandIdRelationship,
                        principalTable: "LandModel",
                        principalColumn: "LandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandReviewModel",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRating = table.Column<double>(type: "float", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModelRelationshipId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LandIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserSellerModelUserSellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandReviewModel", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_LandReviewModel_AspNetUsers_UserModelRelationshipId",
                        column: x => x.UserModelRelationshipId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandReviewModel_LandModel_LandIdRelationship",
                        column: x => x.LandIdRelationship,
                        principalTable: "LandModel",
                        principalColumn: "LandId");
                    table.ForeignKey(
                        name: "FK_LandReviewModel_UserSellerModels_UserSellerModelUserSellerId",
                        column: x => x.UserSellerModelUserSellerId,
                        principalTable: "UserSellerModels",
                        principalColumn: "UserSellerId");
                });

            migrationBuilder.CreateTable(
                name: "LandTransactionModel",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsNormalBuy = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ScheduleFee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSchedulePeriodExpired = table.Column<bool>(type: "bit", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    ScheduleInitiatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ScheduleInitiatedDateExpired = table.Column<DateTime>(type: "datetime", nullable: true),
                    TourDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SoldDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserBuyerIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LandIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandTransactionModel", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_LandTransactionModel_LandModel_LandIdRelationship",
                        column: x => x.LandIdRelationship,
                        principalTable: "LandModel",
                        principalColumn: "LandId");
                    table.ForeignKey(
                        name: "FK_LandTransactionModel_UserBuyerModels_UserBuyerIdRelationship",
                        column: x => x.UserBuyerIdRelationship,
                        principalTable: "UserBuyerModels",
                        principalColumn: "UserBuyerId");
                });

            migrationBuilder.CreateTable(
                name: "MaterialFavoritesModel",
                columns: table => new
                {
                    FavoriteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaterialIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialFavoritesModel", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_MaterialFavoritesModel_MaterialModel_MaterialIdRelationship",
                        column: x => x.MaterialIdRelationship,
                        principalTable: "MaterialModel",
                        principalColumn: "MaterialId");
                    table.ForeignKey(
                        name: "FK_MaterialFavoritesModel_UserBuyerModels_UserIdRelationship",
                        column: x => x.UserIdRelationship,
                        principalTable: "UserBuyerModels",
                        principalColumn: "UserBuyerId");
                });

            migrationBuilder.CreateTable(
                name: "MaterialJoinMaterialAmenityModel",
                columns: table => new
                {
                    MaterialAmenityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialJoinMaterialAmenityModel", x => new { x.MaterialAmenityId, x.MaterialModelId });
                    table.ForeignKey(
                        name: "FK_MaterialJoinMaterialAmenityModel_MaterialAmenityModel_MaterialAmenityId",
                        column: x => x.MaterialAmenityId,
                        principalTable: "MaterialAmenityModel",
                        principalColumn: "MaterialAmenitiesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialJoinMaterialAmenityModel_MaterialModel_MaterialModelId",
                        column: x => x.MaterialModelId,
                        principalTable: "MaterialModel",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialJoinPlacesNearbyModel",
                columns: table => new
                {
                    MaterialModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlacesNearbyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialJoinPlacesNearbyModel", x => new { x.MaterialModelId, x.PlacesNearbyId });
                    table.ForeignKey(
                        name: "FK_MaterialJoinPlacesNearbyModel_MaterialModel_MaterialModelId",
                        column: x => x.MaterialModelId,
                        principalTable: "MaterialModel",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialJoinPlacesNearbyModel_MaterialPlacesNearbyModel_PlacesNearbyId",
                        column: x => x.PlacesNearbyId,
                        principalTable: "MaterialPlacesNearbyModel",
                        principalColumn: "PlacesNearbyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialPictureModel",
                columns: table => new
                {
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaterialIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialPictureModel", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_MaterialPictureModel_MaterialModel_MaterialIdRelationship",
                        column: x => x.MaterialIdRelationship,
                        principalTable: "MaterialModel",
                        principalColumn: "MaterialId");
                });

            migrationBuilder.CreateTable(
                name: "MaterialReviewModel",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRating = table.Column<double>(type: "float", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModelRelationshipId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaterialIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserSellerModelUserSellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialReviewModel", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_MaterialReviewModel_AspNetUsers_UserModelRelationshipId",
                        column: x => x.UserModelRelationshipId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialReviewModel_MaterialModel_MaterialIdRelationship",
                        column: x => x.MaterialIdRelationship,
                        principalTable: "MaterialModel",
                        principalColumn: "MaterialId");
                    table.ForeignKey(
                        name: "FK_MaterialReviewModel_UserSellerModels_UserSellerModelUserSellerId",
                        column: x => x.UserSellerModelUserSellerId,
                        principalTable: "UserSellerModels",
                        principalColumn: "UserSellerId");
                });

            migrationBuilder.CreateTable(
                name: "MaterialTransactionModel",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsNormalBuy = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ScheduleFee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSchedulePeriodExpired = table.Column<bool>(type: "bit", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    ScheduleInitiatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ScheduleInitiatedDateExpired = table.Column<DateTime>(type: "datetime", nullable: true),
                    TourDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SoldDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserBuyerIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaterialIdRelationship = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTransactionModel", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_MaterialTransactionModel_MaterialModel_MaterialIdRelationship",
                        column: x => x.MaterialIdRelationship,
                        principalTable: "MaterialModel",
                        principalColumn: "MaterialId");
                    table.ForeignKey(
                        name: "FK_MaterialTransactionModel_UserBuyerModels_UserBuyerIdRelationship",
                        column: x => x.UserBuyerIdRelationship,
                        principalTable: "UserBuyerModels",
                        principalColumn: "UserBuyerId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79b5fcd7-2c16-4d38-8e80-293b1fdce61d", "3", "Seller", "Seller" },
                    { "95e1913b-c01b-4089-a312-b1b00d7c174e", "4", "Agent", "Agent" },
                    { "aed2a172-0ee4-42e3-98ee-daa6b85e2da0", "5", "Buyer", "Buyer" },
                    { "c413111f-367e-4cbe-a4f4-b48a5da1f96a", "2", "Admin", "Admin" },
                    { "e001d04c-a910-4a9e-9ab3-1be646cc4179", "1", "SuperAdmin", "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "LastLogin", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiry", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserSelectedLocation" },
                values: new object[] { "b149fd9f-398a-45f1-85bd-f07e64397ae5", 0, "c1d7f92e-9499-4134-8ec6-52be13ab30ae", new DateTime(2024, 8, 21, 8, 46, 8, 470, DateTimeKind.Utc).AddTicks(3252), "pipeloluwapapic@yahoo.com", false, null, false, null, null, "PIPELOLUWAPAPIC@YAHOO.COM", "VIRTUALEXADMIN", "AQAAAAIAAYagAAAAEDL/tlCx9AmAgF1Za1hE6SzMRsZHm5eIQ95LqEke7oKLRC1l400R+Yrgi9jq137t9w==", null, false, null, null, "42f3b38b-e736-4a12-95b7-e5d11d782b6b", false, "VirtualEXAdmin", null });

            migrationBuilder.InsertData(
                table: "ScheduleSettingsModels",
                columns: new[] { "SchedulId", "CustomScheduledFee", "MaximumFridayTourSchedule", "MaximumSaturdayTourSchedule", "NormalScheduledFee" },
                values: new object[] { new Guid("c04c9386-fadd-42be-976c-9789380e0da1"), "5000", 50, 60, "0" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e001d04c-a910-4a9e-9ab3-1be646cc4179", "b149fd9f-398a-45f1-85bd-f07e64397ae5" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HouseFavoritesModel_HouseIdRelationship",
                table: "HouseFavoritesModel",
                column: "HouseIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_HouseFavoritesModel_UserIdRelationship",
                table: "HouseFavoritesModel",
                column: "UserIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_HouseJoinHouseAmenityModel_HouseModelId",
                table: "HouseJoinHouseAmenityModel",
                column: "HouseModelId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseJoinPlacesNearbyModel_PlacesNearbyId",
                table: "HouseJoinPlacesNearbyModel",
                column: "PlacesNearbyId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseModel_AgentIdRelationship",
                table: "HouseModel",
                column: "AgentIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_HouseModel_UserSellerIdRelationship",
                table: "HouseModel",
                column: "UserSellerIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_HousePictureModel_HouseIdRelationship",
                table: "HousePictureModel",
                column: "HouseIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_HouseReviewModel_HouseIdRelationship",
                table: "HouseReviewModel",
                column: "HouseIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_HouseReviewModel_UserModelRelationshipId",
                table: "HouseReviewModel",
                column: "UserModelRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseReviewModel_UserSellerModelUserSellerId",
                table: "HouseReviewModel",
                column: "UserSellerModelUserSellerId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseTransactionModel_HouseIdRelationship",
                table: "HouseTransactionModel",
                column: "HouseIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_HouseTransactionModel_UserBuyerIdRelationship",
                table: "HouseTransactionModel",
                column: "UserBuyerIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_LandFavoritesModel_LandIdRelationship",
                table: "LandFavoritesModel",
                column: "LandIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_LandFavoritesModel_UserIdRelationship",
                table: "LandFavoritesModel",
                column: "UserIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_LandJoinLandAmenityModel_LandModelId",
                table: "LandJoinLandAmenityModel",
                column: "LandModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LandJoinPlacesNearbyModel_PlacesNearbyId",
                table: "LandJoinPlacesNearbyModel",
                column: "PlacesNearbyId");

            migrationBuilder.CreateIndex(
                name: "IX_LandModel_AgentIdRelationship",
                table: "LandModel",
                column: "AgentIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_LandModel_UserSellerIdRelationship",
                table: "LandModel",
                column: "UserSellerIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_LandPictureModel_LandIdRelationship",
                table: "LandPictureModel",
                column: "LandIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_LandReviewModel_LandIdRelationship",
                table: "LandReviewModel",
                column: "LandIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_LandReviewModel_UserModelRelationshipId",
                table: "LandReviewModel",
                column: "UserModelRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_LandReviewModel_UserSellerModelUserSellerId",
                table: "LandReviewModel",
                column: "UserSellerModelUserSellerId");

            migrationBuilder.CreateIndex(
                name: "IX_LandTransactionModel_LandIdRelationship",
                table: "LandTransactionModel",
                column: "LandIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_LandTransactionModel_UserBuyerIdRelationship",
                table: "LandTransactionModel",
                column: "UserBuyerIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialFavoritesModel_MaterialIdRelationship",
                table: "MaterialFavoritesModel",
                column: "MaterialIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialFavoritesModel_UserIdRelationship",
                table: "MaterialFavoritesModel",
                column: "UserIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialJoinMaterialAmenityModel_MaterialModelId",
                table: "MaterialJoinMaterialAmenityModel",
                column: "MaterialModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialJoinPlacesNearbyModel_PlacesNearbyId",
                table: "MaterialJoinPlacesNearbyModel",
                column: "PlacesNearbyId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialModel_AgentIdRelationship",
                table: "MaterialModel",
                column: "AgentIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialModel_UserSellerIdRelationship",
                table: "MaterialModel",
                column: "UserSellerIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPictureModel_MaterialIdRelationship",
                table: "MaterialPictureModel",
                column: "MaterialIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialReviewModel_MaterialIdRelationship",
                table: "MaterialReviewModel",
                column: "MaterialIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialReviewModel_UserModelRelationshipId",
                table: "MaterialReviewModel",
                column: "UserModelRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialReviewModel_UserSellerModelUserSellerId",
                table: "MaterialReviewModel",
                column: "UserSellerModelUserSellerId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTransactionModel_MaterialIdRelationship",
                table: "MaterialTransactionModel",
                column: "MaterialIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTransactionModel_UserBuyerIdRelationship",
                table: "MaterialTransactionModel",
                column: "UserBuyerIdRelationship");

            migrationBuilder.CreateIndex(
                name: "IX_UserAgentModels_UserIdRelationship",
                table: "UserAgentModels",
                column: "UserIdRelationship",
                unique: true,
                filter: "[UserIdRelationship] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuyerModels_UserIdRelationship",
                table: "UserBuyerModels",
                column: "UserIdRelationship",
                unique: true,
                filter: "[UserIdRelationship] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserSellerModels_UserIdRelationship",
                table: "UserSellerModels",
                column: "UserIdRelationship",
                unique: true,
                filter: "[UserIdRelationship] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "HouseFavoritesModel");

            migrationBuilder.DropTable(
                name: "HouseJoinHouseAmenityModel");

            migrationBuilder.DropTable(
                name: "HouseJoinPlacesNearbyModel");

            migrationBuilder.DropTable(
                name: "HousePictureModel");

            migrationBuilder.DropTable(
                name: "HouseReviewModel");

            migrationBuilder.DropTable(
                name: "HouseTransactionModel");

            migrationBuilder.DropTable(
                name: "LandFavoritesModel");

            migrationBuilder.DropTable(
                name: "LandJoinLandAmenityModel");

            migrationBuilder.DropTable(
                name: "LandJoinPlacesNearbyModel");

            migrationBuilder.DropTable(
                name: "LandPictureModel");

            migrationBuilder.DropTable(
                name: "LandReviewModel");

            migrationBuilder.DropTable(
                name: "LandTransactionModel");

            migrationBuilder.DropTable(
                name: "MaterialFavoritesModel");

            migrationBuilder.DropTable(
                name: "MaterialJoinMaterialAmenityModel");

            migrationBuilder.DropTable(
                name: "MaterialJoinPlacesNearbyModel");

            migrationBuilder.DropTable(
                name: "MaterialPictureModel");

            migrationBuilder.DropTable(
                name: "MaterialReviewModel");

            migrationBuilder.DropTable(
                name: "MaterialTransactionModel");

            migrationBuilder.DropTable(
                name: "ScheduleSettingsModels");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "HouseAmenityModel");

            migrationBuilder.DropTable(
                name: "HousePlacesNearbyModel");

            migrationBuilder.DropTable(
                name: "HouseModel");

            migrationBuilder.DropTable(
                name: "LandAmenityModel");

            migrationBuilder.DropTable(
                name: "LandPlacesNearbyModel");

            migrationBuilder.DropTable(
                name: "LandModel");

            migrationBuilder.DropTable(
                name: "MaterialAmenityModel");

            migrationBuilder.DropTable(
                name: "MaterialPlacesNearbyModel");

            migrationBuilder.DropTable(
                name: "MaterialModel");

            migrationBuilder.DropTable(
                name: "UserBuyerModels");

            migrationBuilder.DropTable(
                name: "UserAgentModels");

            migrationBuilder.DropTable(
                name: "UserSellerModels");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
