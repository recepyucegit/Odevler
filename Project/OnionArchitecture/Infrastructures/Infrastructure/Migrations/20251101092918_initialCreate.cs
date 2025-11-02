using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
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
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.ID);
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
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitsInStock = table.Column<short>(type: "smallint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreatedDate", "Description", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 27, 15, 8, 21, 635, DateTimeKind.Local).AddTicks(6599), "Çünkü quis inventore nemo sit gördüm aliquam yapacakmış.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elektronik" },
                    { 2, new DateTime(2025, 8, 17, 17, 8, 9, 589, DateTimeKind.Local).AddTicks(7206), "Dolayı sevindi patlıcan sokaklarda quaerat dışarı eum ea koyun.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giyim" },
                    { 3, new DateTime(2024, 11, 11, 16, 47, 21, 690, DateTimeKind.Local).AddTicks(6784), "Koyun tempora sed sequi magnam voluptatem açılmadan koşuyorlar non bilgiyasayarı veritatis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kitap & Kırtasiye" },
                    { 4, new DateTime(2024, 7, 25, 3, 48, 48, 790, DateTimeKind.Local).AddTicks(2205), "Veniam masaya aperiam alias eaque incidunt consequatur biber duyulmamış.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ev & Yaşam" },
                    { 5, new DateTime(2024, 10, 4, 20, 29, 7, 19, DateTimeKind.Local).AddTicks(4868), "Yaptı ex çorba ex quia voluptatem layıkıyla quae un.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spor & Outdoor" },
                    { 6, new DateTime(2025, 2, 8, 9, 30, 42, 700, DateTimeKind.Local).AddTicks(9388), "Camisi nihil cezbelendi gül ama oldular telefonu voluptas patlıcan consequatur dolore minima.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oyuncak & Hobi" },
                    { 7, new DateTime(2024, 9, 29, 19, 39, 59, 143, DateTimeKind.Local).AddTicks(3912), "İncidunt düşünüyor gazete quia dolor yapacakmış yazın çünkü duyulmamış çarpan vel aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kozmetik & Kişisel Bakım" },
                    { 8, new DateTime(2025, 8, 12, 2, 38, 43, 431, DateTimeKind.Local).AddTicks(4716), "Çünkü veniam patlıcan aut ut salladı molestiae explicabo biber sarmal sıfat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gıda & İçecek" },
                    { 9, new DateTime(2025, 9, 13, 15, 8, 3, 670, DateTimeKind.Local).AddTicks(6700), "Sit ratione bahar ipsum teldeki voluptatem olduğu nihil cezbelendi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anne & Bebek" },
                    { 10, new DateTime(2025, 4, 14, 6, 35, 10, 703, DateTimeKind.Local).AddTicks(3144), "Uzattı dergi dolorem voluptatum quia quam sevindi ut corporis şafak voluptatem çarpan aliquid.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ayakkabı & Çanta" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "ID", "Address", "CompanyName", "ContactName", "CreatedDate", "ModifiedDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Sevgi Sokak 04, İzmir", "Egeli Group A.Ş.", "Altıntamgantarkan Özkara", new DateTime(2023, 12, 15, 3, 26, 56, 450, DateTimeKind.Local).AddTicks(9672), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0350 648 67 74" },
                    { 2, "Atatürk Bulvarı 73a, İzmir", "Erbulak, Babaoğlu and Karaböcek A.Ş.", "Ebin Sezek", new DateTime(2025, 8, 31, 4, 49, 6, 34, DateTimeKind.Local).AddTicks(3262), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0353 053 70 04" },
                    { 3, "Sarıkaya Caddesi 21b, Şırnak", "Tanrıkulu - Yalçın Ltd. Şti.", "Bögde Barbarosoğlu", new DateTime(2024, 1, 24, 12, 44, 51, 302, DateTimeKind.Local).AddTicks(3465), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0688 288 92 18" },
                    { 4, "Okul Sokak 12a, Muğla", "Poyrazoğlu - Bolatlı A.Ş.", "Barboğa Gümüşpala", new DateTime(2024, 8, 11, 20, 50, 5, 842, DateTimeKind.Local).AddTicks(3132), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0107 390 88 81" },
                    { 5, "Ali Çetinkaya Caddesi 20a, Ağrı", "Atan and Sons Ltd. Şti.", "Akdemir Pekkan", new DateTime(2025, 4, 13, 23, 52, 57, 924, DateTimeKind.Local).AddTicks(6177), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0828 990 94 44" },
                    { 6, "Lütfi Karadirek Caddesi 88c, Çanakkale", "Akyüz - Erbulak Ltd. Şti.", "Bozbörü Erkekli", new DateTime(2023, 11, 24, 4, 7, 23, 36, DateTimeKind.Local).AddTicks(5408), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0630 602 96 90" },
                    { 7, "Bayır Sokak 32, Kocaeli", "Özkök  and Sons Ltd. Şti.", "Arslanyabgu Akay", new DateTime(2024, 10, 30, 7, 36, 49, 363, DateTimeKind.Local).AddTicks(3011), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0300 119 32 54" },
                    { 8, "Okul Sokak 97a, Gaziantep", "Özberk, Aclan and Körmükçü San. Tic.", "Alpurungu Evliyaoğlu", new DateTime(2025, 7, 31, 12, 31, 15, 825, DateTimeKind.Local).AddTicks(5527), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0483 469 31 02" },
                    { 9, "Afyon Kaya Sokak 59c, Kırklareli", "Nebioğlu, Duygulu and Özkara San. Tic.", "Belgüc Örge", new DateTime(2024, 2, 1, 4, 43, 48, 590, DateTimeKind.Local).AddTicks(4240), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0485 207 29 76" },
                    { 10, "Oğuzhan Sokak 05c, Yozgat", "Ertepınar Inc San. Tic.", "Kırlangıç Uca", new DateTime(2025, 4, 29, 23, 46, 14, 824, DateTimeKind.Local).AddTicks(4790), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0164 050 59 75" },
                    { 11, "Fatih Sokak  461, Balıkesir", "Yıldızoğlu Group San. Tic.", "Bıdın Biçer", new DateTime(2025, 7, 24, 13, 52, 59, 745, DateTimeKind.Local).AddTicks(5803), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0268 181 97 97" },
                    { 12, "Ülkü Sokak 664, Bolu", "Sandalcı and Sons A.Ş.", "Boğa Yetkiner", new DateTime(2025, 10, 23, 9, 29, 45, 655, DateTimeKind.Local).AddTicks(6470), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0457 719 30 28" },
                    { 13, "Okul Sokak 82b, Aydın", "Pekkan, Başoğlu and Polat San. Tic.", "Ayızdağ Taşlı", new DateTime(2025, 3, 29, 15, 34, 50, 345, DateTimeKind.Local).AddTicks(6077), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0774 574 12 36" },
                    { 14, "Menekşe Sokak 04b, Artvin", "Gürmen - Solmaz San. Tic.", "Beğbars Kurutluoğlu", new DateTime(2025, 7, 10, 6, 26, 18, 992, DateTimeKind.Local).AddTicks(3263), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0222 922 99 33" },
                    { 15, "Sarıkaya Caddesi 072, Rize", "Özgörkey, Karaduman and Erçetin Ltd. Şti.", "Atalan Çağıran", new DateTime(2024, 12, 19, 21, 5, 49, 724, DateTimeKind.Local).AddTicks(8558), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0313 390 71 82" },
                    { 16, "Sıran Söğüt Sokak 3, Kastamonu", "Baykam - Nalbantoğlu Ltd. Şti.", "Asrı Akgül", new DateTime(2024, 12, 30, 15, 36, 6, 939, DateTimeKind.Local).AddTicks(9182), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0351 508 99 08" },
                    { 17, "Sıran Söğüt Sokak 74a, Muş", "Erçetin, Kurutluoğlu and Dağdaş San. Tic.", "Alpaya Sinanoğlu", new DateTime(2025, 5, 2, 12, 57, 26, 296, DateTimeKind.Local).AddTicks(7555), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0227 977 76 12" },
                    { 18, "İsmet Paşa Caddesi 23c, Afyon", "Beşerler Group A.Ş.", "Bozan Ayverdi", new DateTime(2024, 10, 29, 12, 45, 19, 404, DateTimeKind.Local).AddTicks(5653), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0107 806 84 44" },
                    { 19, "Bayır Sokak 64c, Kastamonu", "Ekşioğlu - Çatalbaş San. Tic.", "Ergene Tunaboylu", new DateTime(2025, 8, 10, 8, 43, 28, 471, DateTimeKind.Local).AddTicks(3005), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0099 968 80 55" },
                    { 20, "Afyon Kaya Sokak 85b, Ordu", "Arıcan and Sons San. Tic.", "Atsız Okumuş", new DateTime(2025, 5, 13, 23, 50, 21, 702, DateTimeKind.Local).AddTicks(2609), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0091 373 22 29" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryId", "CreatedDate", "Description", "ModifiedDate", "Name", "SupplierId", "UnitPrice", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2024, 12, 22, 1, 57, 44, 865, DateTimeKind.Local).AddTicks(8000), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rustic Rubber Shirt", 11, 8788.40m, (short)480 },
                    { 2, 8, new DateTime(2025, 3, 4, 12, 13, 36, 666, DateTimeKind.Local).AddTicks(8403), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handmade Granite Keyboard", 17, 3347.06m, (short)494 },
                    { 3, 8, new DateTime(2025, 9, 10, 18, 0, 36, 594, DateTimeKind.Local).AddTicks(3581), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gorgeous Concrete Pants", 9, 3996.57m, (short)464 },
                    { 4, 6, new DateTime(2025, 2, 5, 10, 55, 41, 280, DateTimeKind.Local).AddTicks(9766), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generic Concrete Shoes", 15, 791.02m, (short)265 },
                    { 5, 6, new DateTime(2025, 6, 8, 0, 36, 37, 75, DateTimeKind.Local).AddTicks(6338), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awesome Wooden Hat", 9, 4949.97m, (short)225 },
                    { 6, 5, new DateTime(2025, 8, 22, 2, 28, 11, 480, DateTimeKind.Local).AddTicks(2864), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handcrafted Cotton Shirt", 10, 2100.44m, (short)424 },
                    { 7, 10, new DateTime(2025, 8, 9, 5, 37, 31, 765, DateTimeKind.Local).AddTicks(5265), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intelligent Granite Bike", 4, 9349.69m, (short)164 },
                    { 8, 3, new DateTime(2025, 4, 2, 3, 10, 12, 197, DateTimeKind.Local).AddTicks(8196), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantastic Plastic Shirt", 12, 9525.30m, (short)416 },
                    { 9, 2, new DateTime(2025, 5, 29, 7, 27, 0, 724, DateTimeKind.Local).AddTicks(8336), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unbranded Granite Chicken", 12, 1873.25m, (short)464 },
                    { 10, 5, new DateTime(2025, 6, 20, 23, 17, 46, 53, DateTimeKind.Local).AddTicks(1841), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incredible Soft Chair", 4, 2732.37m, (short)67 },
                    { 11, 6, new DateTime(2024, 12, 9, 2, 41, 16, 535, DateTimeKind.Local).AddTicks(4627), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intelligent Steel Mouse", 20, 5900.31m, (short)134 },
                    { 12, 1, new DateTime(2025, 7, 28, 17, 5, 40, 730, DateTimeKind.Local).AddTicks(6583), "The Football Is Good For Training And Recreational Purposes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ergonomic Steel Table", 4, 2467.84m, (short)47 },
                    { 13, 3, new DateTime(2025, 9, 2, 7, 41, 23, 536, DateTimeKind.Local).AddTicks(6170), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sleek Plastic Pants", 10, 343.51m, (short)233 },
                    { 14, 9, new DateTime(2024, 12, 18, 16, 44, 44, 710, DateTimeKind.Local).AddTicks(4774), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sleek Soft Chair", 9, 2441.07m, (short)211 },
                    { 15, 4, new DateTime(2025, 2, 2, 12, 36, 44, 617, DateTimeKind.Local).AddTicks(2943), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantastic Soft Salad", 1, 9923.12m, (short)83 },
                    { 16, 4, new DateTime(2025, 3, 3, 14, 29, 3, 292, DateTimeKind.Local).AddTicks(9598), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handmade Soft Towels", 9, 3545.17m, (short)6 },
                    { 17, 9, new DateTime(2024, 12, 26, 14, 38, 21, 742, DateTimeKind.Local).AddTicks(9201), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generic Fresh Car", 5, 160.11m, (short)350 },
                    { 18, 4, new DateTime(2025, 10, 6, 4, 5, 12, 154, DateTimeKind.Local).AddTicks(6349), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rustic Soft Bacon", 6, 6847.03m, (short)425 },
                    { 19, 9, new DateTime(2025, 10, 9, 14, 29, 7, 506, DateTimeKind.Local).AddTicks(9840), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awesome Steel Gloves", 11, 5411.75m, (short)346 },
                    { 20, 5, new DateTime(2025, 8, 16, 21, 25, 1, 967, DateTimeKind.Local).AddTicks(4186), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refined Rubber Shirt", 3, 6117.06m, (short)174 },
                    { 21, 3, new DateTime(2024, 12, 2, 12, 17, 32, 103, DateTimeKind.Local).AddTicks(9027), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasty Metal Fish", 10, 5746.69m, (short)307 },
                    { 22, 6, new DateTime(2025, 4, 28, 16, 4, 52, 828, DateTimeKind.Local).AddTicks(9974), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awesome Metal Computer", 11, 8663.77m, (short)247 },
                    { 23, 1, new DateTime(2025, 3, 28, 22, 35, 55, 381, DateTimeKind.Local).AddTicks(5710), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unbranded Cotton Pants", 17, 6540.92m, (short)290 },
                    { 24, 10, new DateTime(2025, 6, 23, 22, 32, 22, 224, DateTimeKind.Local).AddTicks(8531), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refined Wooden Mouse", 16, 8012.86m, (short)209 },
                    { 25, 2, new DateTime(2025, 9, 2, 12, 15, 34, 968, DateTimeKind.Local).AddTicks(8379), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handmade Cotton Shoes", 4, 2749.09m, (short)480 },
                    { 26, 5, new DateTime(2025, 5, 1, 6, 10, 57, 193, DateTimeKind.Local).AddTicks(281), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Small Wooden Fish", 15, 4939.26m, (short)266 },
                    { 27, 4, new DateTime(2025, 1, 7, 3, 46, 48, 316, DateTimeKind.Local).AddTicks(9042), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rustic Rubber Chair", 17, 5884.66m, (short)292 },
                    { 28, 1, new DateTime(2025, 7, 7, 7, 11, 58, 35, DateTimeKind.Local).AddTicks(155), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incredible Wooden Sausages", 9, 3546.28m, (short)380 },
                    { 29, 8, new DateTime(2024, 12, 20, 10, 0, 26, 275, DateTimeKind.Local).AddTicks(6280), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantastic Wooden Keyboard", 14, 2018.76m, (short)86 },
                    { 30, 6, new DateTime(2025, 4, 7, 13, 56, 59, 759, DateTimeKind.Local).AddTicks(4628), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ergonomic Frozen Tuna", 17, 9685.19m, (short)239 },
                    { 31, 3, new DateTime(2025, 4, 19, 9, 22, 12, 464, DateTimeKind.Local).AddTicks(8976), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rustic Rubber Bacon", 11, 8937.81m, (short)98 },
                    { 32, 9, new DateTime(2024, 12, 24, 7, 8, 8, 110, DateTimeKind.Local).AddTicks(7014), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Licensed Plastic Bacon", 8, 5995.52m, (short)369 },
                    { 33, 2, new DateTime(2025, 2, 4, 6, 15, 10, 868, DateTimeKind.Local).AddTicks(2691), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handcrafted Metal Shirt", 3, 2991.63m, (short)497 },
                    { 34, 8, new DateTime(2025, 7, 31, 9, 29, 22, 802, DateTimeKind.Local).AddTicks(2996), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handmade Metal Keyboard", 4, 1158.22m, (short)62 },
                    { 35, 2, new DateTime(2025, 1, 14, 2, 18, 0, 948, DateTimeKind.Local).AddTicks(1460), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refined Granite Ball", 4, 8671.14m, (short)182 },
                    { 36, 1, new DateTime(2025, 7, 3, 18, 32, 49, 270, DateTimeKind.Local).AddTicks(8427), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Small Wooden Gloves", 6, 8138.86m, (short)416 },
                    { 37, 9, new DateTime(2025, 10, 18, 16, 10, 19, 329, DateTimeKind.Local).AddTicks(9295), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ergonomic Plastic Gloves", 11, 1534.87m, (short)79 },
                    { 38, 8, new DateTime(2025, 4, 4, 22, 45, 54, 197, DateTimeKind.Local).AddTicks(3408), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intelligent Plastic Mouse", 4, 7002.50m, (short)208 },
                    { 39, 10, new DateTime(2025, 2, 13, 13, 55, 4, 196, DateTimeKind.Local).AddTicks(2758), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refined Soft Pizza", 14, 649.86m, (short)113 },
                    { 40, 7, new DateTime(2025, 3, 20, 10, 20, 6, 491, DateTimeKind.Local).AddTicks(7373), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refined Fresh Pizza", 13, 1122.56m, (short)125 },
                    { 41, 2, new DateTime(2025, 8, 26, 1, 43, 19, 462, DateTimeKind.Local).AddTicks(2419), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refined Steel Gloves", 19, 9089.08m, (short)42 },
                    { 42, 6, new DateTime(2025, 8, 30, 15, 4, 42, 582, DateTimeKind.Local).AddTicks(3498), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ergonomic Cotton Table", 15, 3525.39m, (short)410 },
                    { 43, 5, new DateTime(2025, 4, 14, 12, 8, 21, 796, DateTimeKind.Local).AddTicks(6877), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handcrafted Steel Bike", 3, 1093.02m, (short)230 },
                    { 44, 2, new DateTime(2025, 4, 28, 11, 40, 9, 577, DateTimeKind.Local).AddTicks(8247), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incredible Frozen Bike", 20, 524.87m, (short)274 },
                    { 45, 8, new DateTime(2025, 4, 29, 19, 43, 15, 783, DateTimeKind.Local).AddTicks(399), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incredible Soft Pizza", 20, 8532.84m, (short)249 },
                    { 46, 7, new DateTime(2025, 9, 9, 15, 10, 4, 414, DateTimeKind.Local).AddTicks(8505), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intelligent Frozen Shoes", 7, 1367.65m, (short)322 },
                    { 47, 10, new DateTime(2025, 9, 14, 22, 4, 25, 454, DateTimeKind.Local).AddTicks(2268), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handcrafted Soft Sausages", 2, 5740.86m, (short)355 },
                    { 48, 9, new DateTime(2024, 12, 20, 23, 57, 9, 135, DateTimeKind.Local).AddTicks(7508), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sleek Wooden Gloves", 13, 3915.61m, (short)320 },
                    { 49, 9, new DateTime(2025, 9, 8, 19, 43, 54, 169, DateTimeKind.Local).AddTicks(5215), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gorgeous Fresh Bike", 15, 5612.56m, (short)233 },
                    { 50, 4, new DateTime(2025, 5, 16, 14, 1, 35, 475, DateTimeKind.Local).AddTicks(427), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sleek Plastic Cheese", 6, 8087.68m, (short)39 },
                    { 51, 9, new DateTime(2024, 12, 22, 8, 31, 13, 959, DateTimeKind.Local).AddTicks(9369), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Small Granite Mouse", 19, 6428.87m, (short)0 },
                    { 52, 1, new DateTime(2024, 12, 1, 1, 59, 44, 867, DateTimeKind.Local).AddTicks(5390), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasty Plastic Towels", 11, 1627.19m, (short)149 },
                    { 53, 9, new DateTime(2025, 5, 22, 5, 46, 1, 154, DateTimeKind.Local).AddTicks(508), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refined Frozen Bike", 2, 7179.11m, (short)101 },
                    { 54, 7, new DateTime(2025, 2, 9, 19, 41, 11, 729, DateTimeKind.Local).AddTicks(9501), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refined Fresh Gloves", 11, 4178.97m, (short)284 },
                    { 55, 9, new DateTime(2024, 11, 20, 14, 32, 2, 945, DateTimeKind.Local).AddTicks(977), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awesome Wooden Bike", 8, 8554.59m, (short)263 },
                    { 56, 2, new DateTime(2024, 11, 8, 13, 13, 20, 499, DateTimeKind.Local).AddTicks(1369), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handmade Metal Keyboard", 2, 6802.85m, (short)460 },
                    { 57, 6, new DateTime(2025, 5, 18, 4, 24, 33, 255, DateTimeKind.Local).AddTicks(1209), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handcrafted Rubber Cheese", 17, 6936.40m, (short)496 },
                    { 58, 1, new DateTime(2024, 11, 26, 8, 18, 12, 769, DateTimeKind.Local).AddTicks(7525), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intelligent Soft Salad", 4, 1126.69m, (short)160 },
                    { 59, 4, new DateTime(2025, 9, 14, 10, 14, 3, 935, DateTimeKind.Local).AddTicks(6750), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refined Metal Computer", 16, 5176.57m, (short)278 },
                    { 60, 8, new DateTime(2025, 2, 12, 1, 21, 22, 708, DateTimeKind.Local).AddTicks(8201), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantastic Plastic Mouse", 1, 2705.00m, (short)413 },
                    { 61, 1, new DateTime(2025, 6, 20, 1, 24, 1, 870, DateTimeKind.Local).AddTicks(8635), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generic Rubber Table", 6, 7533.01m, (short)421 },
                    { 62, 8, new DateTime(2025, 9, 10, 9, 58, 48, 398, DateTimeKind.Local).AddTicks(8233), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intelligent Soft Hat", 9, 5623.76m, (short)159 },
                    { 63, 2, new DateTime(2024, 11, 8, 13, 25, 51, 186, DateTimeKind.Local).AddTicks(4884), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handmade Frozen Car", 19, 8337.23m, (short)482 },
                    { 64, 1, new DateTime(2025, 10, 18, 10, 38, 33, 111, DateTimeKind.Local).AddTicks(8639), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasty Soft Shoes", 14, 2606.32m, (short)32 },
                    { 65, 4, new DateTime(2025, 9, 15, 20, 32, 35, 315, DateTimeKind.Local).AddTicks(4999), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantastic Rubber Salad", 16, 3427.04m, (short)388 },
                    { 66, 10, new DateTime(2024, 12, 9, 1, 35, 33, 852, DateTimeKind.Local).AddTicks(728), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sleek Rubber Cheese", 20, 2531.70m, (short)76 },
                    { 67, 10, new DateTime(2025, 8, 28, 2, 12, 34, 835, DateTimeKind.Local).AddTicks(401), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gorgeous Cotton Cheese", 2, 2629.49m, (short)346 },
                    { 68, 5, new DateTime(2025, 4, 14, 18, 17, 54, 791, DateTimeKind.Local).AddTicks(3566), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasty Wooden Shoes", 19, 7886.35m, (short)121 },
                    { 69, 8, new DateTime(2024, 11, 12, 13, 12, 58, 892, DateTimeKind.Local).AddTicks(363), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Small Cotton Tuna", 10, 724.75m, (short)445 },
                    { 70, 6, new DateTime(2024, 11, 6, 9, 28, 34, 379, DateTimeKind.Local).AddTicks(3469), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refined Steel Towels", 10, 1617.51m, (short)135 },
                    { 71, 8, new DateTime(2024, 12, 27, 12, 35, 57, 186, DateTimeKind.Local).AddTicks(3265), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Small Fresh Pants", 19, 1005.20m, (short)468 },
                    { 72, 2, new DateTime(2025, 3, 5, 6, 44, 29, 696, DateTimeKind.Local).AddTicks(3530), "The Football Is Good For Training And Recreational Purposes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sleek Steel Cheese", 17, 3292.67m, (short)231 },
                    { 73, 9, new DateTime(2025, 8, 21, 6, 36, 57, 408, DateTimeKind.Local).AddTicks(12), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Practical Frozen Pants", 11, 4904.48m, (short)380 },
                    { 74, 4, new DateTime(2025, 7, 1, 14, 42, 14, 967, DateTimeKind.Local).AddTicks(5229), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantastic Metal Chips", 7, 4815.58m, (short)495 },
                    { 75, 6, new DateTime(2025, 10, 5, 14, 2, 20, 786, DateTimeKind.Local).AddTicks(9068), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rustic Soft Pants", 18, 4215.53m, (short)452 },
                    { 76, 5, new DateTime(2025, 2, 7, 1, 38, 57, 703, DateTimeKind.Local).AddTicks(7319), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handmade Plastic Cheese", 10, 6523.03m, (short)142 },
                    { 77, 6, new DateTime(2025, 3, 23, 10, 5, 17, 140, DateTimeKind.Local).AddTicks(1348), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awesome Wooden Shirt", 17, 217.81m, (short)395 },
                    { 78, 5, new DateTime(2025, 4, 7, 16, 55, 20, 934, DateTimeKind.Local).AddTicks(6781), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refined Plastic Hat", 11, 2141.26m, (short)394 },
                    { 79, 6, new DateTime(2025, 7, 27, 1, 41, 29, 77, DateTimeKind.Local).AddTicks(8911), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intelligent Soft Towels", 2, 7972.37m, (short)16 },
                    { 80, 5, new DateTime(2025, 9, 3, 13, 46, 31, 717, DateTimeKind.Local).AddTicks(3901), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awesome Concrete Chips", 20, 4774.96m, (short)472 },
                    { 81, 8, new DateTime(2025, 6, 13, 15, 22, 3, 89, DateTimeKind.Local).AddTicks(30), "The Football Is Good For Training And Recreational Purposes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sleek Granite Cheese", 9, 835.63m, (short)472 },
                    { 82, 3, new DateTime(2025, 8, 16, 16, 6, 8, 508, DateTimeKind.Local).AddTicks(4530), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasty Frozen Computer", 4, 5290.06m, (short)60 },
                    { 83, 6, new DateTime(2025, 1, 12, 23, 53, 10, 909, DateTimeKind.Local).AddTicks(1586), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gorgeous Wooden Pants", 16, 3370.71m, (short)267 },
                    { 84, 1, new DateTime(2025, 6, 14, 2, 6, 34, 82, DateTimeKind.Local).AddTicks(2506), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sleek Wooden Bacon", 5, 6317.48m, (short)219 },
                    { 85, 1, new DateTime(2024, 12, 15, 3, 2, 3, 226, DateTimeKind.Local).AddTicks(151), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gorgeous Rubber Chicken", 1, 554.28m, (short)284 },
                    { 86, 4, new DateTime(2025, 9, 2, 8, 3, 56, 826, DateTimeKind.Local).AddTicks(9515), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refined Rubber Fish", 12, 4764.99m, (short)464 },
                    { 87, 9, new DateTime(2025, 2, 6, 2, 21, 46, 197, DateTimeKind.Local).AddTicks(8482), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ergonomic Wooden Mouse", 14, 7626.16m, (short)19 },
                    { 88, 9, new DateTime(2025, 9, 18, 16, 18, 0, 959, DateTimeKind.Local).AddTicks(3981), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incredible Cotton Ball", 2, 5846.72m, (short)223 },
                    { 89, 10, new DateTime(2024, 11, 14, 1, 1, 37, 470, DateTimeKind.Local).AddTicks(4824), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ergonomic Metal Car", 19, 4930.47m, (short)15 },
                    { 90, 10, new DateTime(2025, 1, 18, 22, 25, 14, 671, DateTimeKind.Local).AddTicks(5637), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Practical Metal Chicken", 9, 4225.38m, (short)373 },
                    { 91, 4, new DateTime(2025, 5, 3, 12, 57, 56, 321, DateTimeKind.Local).AddTicks(6754), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Licensed Steel Pizza", 20, 8742.71m, (short)94 },
                    { 92, 6, new DateTime(2024, 11, 1, 17, 20, 59, 962, DateTimeKind.Local).AddTicks(7278), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gorgeous Concrete Chair", 19, 7557.19m, (short)277 },
                    { 93, 1, new DateTime(2025, 3, 29, 20, 44, 18, 320, DateTimeKind.Local).AddTicks(1878), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awesome Plastic Soap", 5, 2856.91m, (short)421 },
                    { 94, 3, new DateTime(2025, 5, 9, 19, 32, 23, 949, DateTimeKind.Local).AddTicks(8256), "The Football Is Good For Training And Recreational Purposes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantastic Cotton Sausages", 5, 8857.12m, (short)130 },
                    { 95, 4, new DateTime(2025, 9, 26, 1, 34, 52, 840, DateTimeKind.Local).AddTicks(1987), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ergonomic Granite Bacon", 18, 2764.31m, (short)469 },
                    { 96, 7, new DateTime(2025, 4, 23, 20, 37, 18, 208, DateTimeKind.Local).AddTicks(6119), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Practical Wooden Salad", 15, 9006.68m, (short)180 },
                    { 97, 3, new DateTime(2024, 11, 12, 19, 26, 1, 501, DateTimeKind.Local).AddTicks(7343), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incredible Metal Cheese", 1, 457.23m, (short)301 },
                    { 98, 2, new DateTime(2025, 2, 28, 9, 35, 1, 303, DateTimeKind.Local).AddTicks(9550), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasty Soft Gloves", 3, 8151.11m, (short)222 },
                    { 99, 10, new DateTime(2025, 9, 15, 17, 27, 32, 635, DateTimeKind.Local).AddTicks(2844), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Practical Metal Chair", 12, 643.42m, (short)299 },
                    { 100, 2, new DateTime(2025, 8, 12, 6, 12, 20, 932, DateTimeKind.Local).AddTicks(9772), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incredible Concrete Hat", 3, 197.42m, (short)342 }
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
                name: "IX_OrderDetails_OrderId_ProductId",
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");
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
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
