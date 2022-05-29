using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsEat.API.Data.Migrations
{
    public partial class AddedLetsEatDatabaseScheme : Migration
    {
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
                    FrichtiEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrichtiPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodTraits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTraits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FrichtiProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossWeight = table.Column<float>(type: "real", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
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
                name: "FoodPrint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Budget = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPrint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodPrint_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FrichtEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrichtiOrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFoodTraitsIngredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodTraitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFoodTraitsIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFoodTraitsIngredients_FoodTraits_FoodTraitId",
                        column: x => x.FoodTraitId,
                        principalTable: "FoodTraits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductFoodTraitsIngredients_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFoodTraitsNutritionalInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodTraitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFoodTraitsNutritionalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFoodTraitsNutritionalInfos_FoodTraits_FoodTraitId",
                        column: x => x.FoodTraitId,
                        principalTable: "FoodTraits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductFoodTraitsNutritionalInfos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFoodTraitsTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodTraitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFoodTraitsTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFoodTraitsTags_FoodTraits_FoodTraitId",
                        column: x => x.FoodTraitId,
                        principalTable: "FoodTraits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductFoodTraitsTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodPrintFoodTraitAllergies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodPrintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodTraitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPrintFoodTraitAllergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodPrintFoodTraitAllergies_FoodPrint_FoodPrintId",
                        column: x => x.FoodPrintId,
                        principalTable: "FoodPrint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodPrintFoodTraitAllergies_FoodTraits_FoodTraitId",
                        column: x => x.FoodTraitId,
                        principalTable: "FoodTraits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodPrintFoodTraitDislikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodPrintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodTraitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPrintFoodTraitDislikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodPrintFoodTraitDislikes_FoodPrint_FoodPrintId",
                        column: x => x.FoodPrintId,
                        principalTable: "FoodPrint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodPrintFoodTraitDislikes_FoodTraits_FoodTraitId",
                        column: x => x.FoodTraitId,
                        principalTable: "FoodTraits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodPrintFoodTraitLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodPrintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodTraitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPrintFoodTraitLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodPrintFoodTraitLikes_FoodPrint_FoodPrintId",
                        column: x => x.FoodPrintId,
                        principalTable: "FoodPrint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodPrintFoodTraitLikes_FoodTraits_FoodTraitId",
                        column: x => x.FoodTraitId,
                        principalTable: "FoodTraits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FeedbackFoodTraitDislikedTraits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodTraitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackFoodTraitDislikedTraits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedbackFoodTraitDislikedTraits_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedbackFoodTraitDislikedTraits_FoodTraits_FoodTraitId",
                        column: x => x.FoodTraitId,
                        principalTable: "FoodTraits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackFoodTraitLikedTraits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodTraitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackFoodTraitLikedTraits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedbackFoodTraitLikedTraits_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedbackFoodTraitLikedTraits_FoodTraits_FoodTraitId",
                        column: x => x.FoodTraitId,
                        principalTable: "FoodTraits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_CartProducts_CartId",
                table: "CartProducts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductId",
                table: "CartProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackFoodTraitDislikedTraits_FeedbackId",
                table: "FeedbackFoodTraitDislikedTraits",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackFoodTraitDislikedTraits_FoodTraitId",
                table: "FeedbackFoodTraitDislikedTraits",
                column: "FoodTraitId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackFoodTraitLikedTraits_FeedbackId",
                table: "FeedbackFoodTraitLikedTraits",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackFoodTraitLikedTraits_FoodTraitId",
                table: "FeedbackFoodTraitLikedTraits",
                column: "FoodTraitId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_OrderId",
                table: "Feedbacks",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPrint_UserId",
                table: "FoodPrint",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPrintFoodTraitAllergies_FoodPrintId",
                table: "FoodPrintFoodTraitAllergies",
                column: "FoodPrintId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPrintFoodTraitAllergies_FoodTraitId",
                table: "FoodPrintFoodTraitAllergies",
                column: "FoodTraitId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPrintFoodTraitDislikes_FoodPrintId",
                table: "FoodPrintFoodTraitDislikes",
                column: "FoodPrintId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPrintFoodTraitDislikes_FoodTraitId",
                table: "FoodPrintFoodTraitDislikes",
                column: "FoodTraitId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPrintFoodTraitLikes_FoodPrintId",
                table: "FoodPrintFoodTraitLikes",
                column: "FoodPrintId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPrintFoodTraitLikes_FoodTraitId",
                table: "FoodPrintFoodTraitLikes",
                column: "FoodTraitId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFoodTraitsIngredients_FoodTraitId",
                table: "ProductFoodTraitsIngredients",
                column: "FoodTraitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFoodTraitsIngredients_ProductId",
                table: "ProductFoodTraitsIngredients",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFoodTraitsNutritionalInfos_FoodTraitId",
                table: "ProductFoodTraitsNutritionalInfos",
                column: "FoodTraitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFoodTraitsNutritionalInfos_ProductId",
                table: "ProductFoodTraitsNutritionalInfos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFoodTraitsTags_FoodTraitId",
                table: "ProductFoodTraitsTags",
                column: "FoodTraitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFoodTraitsTags_ProductId",
                table: "ProductFoodTraitsTags",
                column: "ProductId");
        }

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
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "FeedbackFoodTraitDislikedTraits");

            migrationBuilder.DropTable(
                name: "FeedbackFoodTraitLikedTraits");

            migrationBuilder.DropTable(
                name: "FoodPrintFoodTraitAllergies");

            migrationBuilder.DropTable(
                name: "FoodPrintFoodTraitDislikes");

            migrationBuilder.DropTable(
                name: "FoodPrintFoodTraitLikes");

            migrationBuilder.DropTable(
                name: "ProductFoodTraitsIngredients");

            migrationBuilder.DropTable(
                name: "ProductFoodTraitsNutritionalInfos");

            migrationBuilder.DropTable(
                name: "ProductFoodTraitsTags");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FoodPrint");

            migrationBuilder.DropTable(
                name: "FoodTraits");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
