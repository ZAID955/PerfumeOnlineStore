using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfumeOnlineStore_Core.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Price = table.Column<float>(type: "real", nullable: false, defaultValue: 1f),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 10, 15, 53, 49, 174, DateTimeKind.Local).AddTicks(6769))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.CheckConstraint("CH_Package__Description", "LEN(Description) > 0 ");
                    table.CheckConstraint("CH_Package__Price", "LEN(Price) > 0 ");
                    table.CheckConstraint("CH_Package_Quantity", "Quantity >= 0");
                });

            migrationBuilder.CreateTable(
                name: "ProductBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 10, 15, 53, 49, 176, DateTimeKind.Local).AddTicks(2593))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.Id);
                    table.CheckConstraint("CH_UserType__Name", "LEN(Name) >0 ");
                });

            migrationBuilder.CreateTable(
                name: "ProductSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 10, 15, 53, 49, 176, DateTimeKind.Local).AddTicks(4666))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSections", x => x.Id);
                    table.CheckConstraint("CH_ProductSection__Name", "LEN(Name) >0 ");
                });

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 10, 15, 53, 49, 176, DateTimeKind.Local).AddTicks(6645))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => x.Id);
                    table.CheckConstraint("CH_ProductSize_Size", "Size >= 0");
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 10, 15, 53, 49, 176, DateTimeKind.Local).AddTicks(8799))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                    table.CheckConstraint("CH_ProductType__Name", "LEN(Name) >0 ");
                });

            migrationBuilder.CreateTable(
                name: "PromoCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountAmount = table.Column<float>(type: "real", nullable: false),
                    DateTimeActive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "True"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "False"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalNo = table.Column<int>(type: "int", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CompanyCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DeliveryLicenseImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryCar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brithday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gendear = table.Column<int>(type: "int", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 10, 15, 53, 49, 175, DateTimeKind.Local).AddTicks(7543))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.CheckConstraint("CH_User_Email", "Email LIKE '%@gmail.com%' OR Email LIKE  '%@outlook.com%' OR Email LIKE '%@yahoo.com%'");
                    table.CheckConstraint("CH_User_NationalNo", "LEN([NationalNo]) = (10) OR NationalNo IS NULL");
                    table.CheckConstraint("CH_User_Password", "LEN(Password) >= 8 AND LEN(Password) <= 16");
                    table.CheckConstraint("CH_User_PhoneNumber", "(LEN([PhoneNumber])=(10) AND ([PhoneNumber] LIKE '079%' OR [PhoneNumber] LIKE '078%' OR [PhoneNumber] LIKE '077%'))");
                    table.CheckConstraint("CK_User_ConfirmPassword", "(Password = ConfirmPassword)");
                });

            migrationBuilder.CreateTable(
                name: "Productes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    SizeUnite = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Price = table.Column<float>(type: "real", nullable: false, defaultValue: 1f),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ProductBrandId = table.Column<int>(type: "int", nullable: false),
                    MinQuantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 10, 15, 53, 49, 175, DateTimeKind.Local).AddTicks(1769))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productes", x => x.Id);
                    table.CheckConstraint("CH_Product__Description", "LEN(Description) > 0 ");
                    table.CheckConstraint("CH_Product__Price", "LEN(Price) > 0 ");
                    table.CheckConstraint("CH_Product_Quantity_CH", "Quantity >= 0");
                    table.ForeignKey(
                        name: "FK_Productes_ProductBrands_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productes_ProductSections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "ProductSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productes_ProductSizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "ProductSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productes_ProductTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 10, 15, 53, 49, 173, DateTimeKind.Local).AddTicks(7921))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageProductes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 10, 15, 53, 49, 174, DateTimeKind.Local).AddTicks(9629))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageProductes", x => x.Id);
                    table.CheckConstraint("CH_Package_Quantity1", "Quantity >= 0");
                    table.ForeignKey(
                        name: "FK_PackageProductes_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageProductes_Productes_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Productes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviewes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Comment = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 10, 15, 53, 49, 175, DateTimeKind.Local).AddTicks(5054))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewes", x => x.Id);
                    table.CheckConstraint("CH_Review__Comment", "LEN(Comment) > 0 ");
                    table.CheckConstraint("CH_Review__Title", "LEN(Title) > 0 ");
                    table.CheckConstraint("CH_Review_Rating", "Rating BETWEEN 1 AND 5");
                    table.ForeignKey(
                        name: "FK_Reviewes_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviewes_Productes_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Productes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviewes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 10, 15, 53, 49, 174, DateTimeKind.Local).AddTicks(2093))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProducts_Productes_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Productes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProducts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Note = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 10, 15, 53, 49, 173, DateTimeKind.Local).AddTicks(9727))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.CheckConstraint("CH_CartItem__Note", "LEN(Note) >0 ");
                    table.CheckConstraint("CH_CartItem_Quantity", "Quantity >= 0");
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItems_Productes_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Productes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    DeliveryCity = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NetPrice = table.Column<float>(type: "real", nullable: false, defaultValue: 1f),
                    TaxAmount = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    DelievryPrice = table.Column<float>(type: "real", nullable: false, defaultValue: 3f),
                    DiscountAmount = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    PromoCodeId = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 10, 15, 53, 49, 174, DateTimeKind.Local).AddTicks(3770))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.CheckConstraint("CH_Order__Address", "LEN(Address) >0 ");
                    table.CheckConstraint("Ch_Order_DelievryPrice", "DelievryPrice>=3");
                    table.CheckConstraint("Ch_Order_DiscountAmount", "DiscountAmount>=0");
                    table.CheckConstraint("Ch_Order_NetPrice", "NetPrice>=0");
                    table.CheckConstraint("Ch_Order_TaxAmount", "TaxAmount>=0");
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PromoCodes_PromoCodeId",
                        column: x => x.PromoCodeId,
                        principalTable: "PromoCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 10, 15, 53, 49, 177, DateTimeKind.Local).AddTicks(1043))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderUsers_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_PackageId",
                table: "CartItems",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PromoCodeId",
                table: "Orders",
                column: "PromoCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderUsers_OrderId",
                table: "OrderUsers",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderUsers_UserId",
                table: "OrderUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageProductes_PackageId",
                table: "PackageProductes",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageProductes_ProductId",
                table: "PackageProductes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Name",
                table: "Packages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductBrands_Name",
                table: "ProductBrands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productes_ProductBrandId",
                table: "Productes",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Productes_SectionId",
                table: "Productes",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Productes_SizeId",
                table: "Productes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Productes_TypeId",
                table: "Productes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSections_Name",
                table: "ProductSections",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_Size",
                table: "ProductSizes",
                column: "Size",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_Name",
                table: "ProductTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviewes_PackageId",
                table: "Reviewes",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviewes_ProductId",
                table: "Reviewes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviewes_UserId",
                table: "Reviewes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_ProductId",
                table: "UserProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_UserId",
                table: "UserProducts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderUsers");

            migrationBuilder.DropTable(
                name: "PackageProductes");

            migrationBuilder.DropTable(
                name: "Reviewes");

            migrationBuilder.DropTable(
                name: "UserProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Productes");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "PromoCodes");

            migrationBuilder.DropTable(
                name: "ProductBrands");

            migrationBuilder.DropTable(
                name: "ProductSections");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
