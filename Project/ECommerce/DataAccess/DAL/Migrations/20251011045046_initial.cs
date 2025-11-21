using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComputerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipperName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    MasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComputerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComputerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
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
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipperId = table.Column<int>(type: "int", nullable: true),
                    MasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComputerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Shippers_ShipperId",
                        column: x => x.ShipperId,
                        principalTable: "Shippers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    MasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComputerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
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
                name: "SupplierPermissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Permission = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComputerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierPermissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SupplierPermissions_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComputerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "ID", "CategoryName", "ComputerName", "CreatedDate", "Description", "IpAddress", "MasterId", "ModifiedComputerName", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, "Health", "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 437, DateTimeKind.Local).AddTicks(3553), "quia", "192.168.1.34", new Guid("06c9c667-1c17-4d57-b5ac-6cced9fcb03a"), null, null, 1 },
                    { 2, "Sports", "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 437, DateTimeKind.Local).AddTicks(6942), "eum", "192.168.1.34", new Guid("5bf35dbc-1f86-4959-97f7-0ded8d0ee156"), null, null, 1 },
                    { 3, "Health", "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 437, DateTimeKind.Local).AddTicks(8830), "debitis", "192.168.1.34", new Guid("efd3c91f-7dcf-4e53-9e83-4c5b0dc4e31e"), null, null, 1 },
                    { 4, "Jewelery", "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 438, DateTimeKind.Local).AddTicks(1471), "similique", "192.168.1.34", new Guid("a2d8e888-2281-4659-a583-6187c40cfb59"), null, null, 1 },
                    { 5, "Clothing", "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 438, DateTimeKind.Local).AddTicks(3623), "vel", "192.168.1.34", new Guid("727674c2-ea2b-4c9c-a2e0-21d16e27cd0f"), null, null, 1 },
                    { 6, "Tools", "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 438, DateTimeKind.Local).AddTicks(5516), "alias", "192.168.1.34", new Guid("b7f5e3c7-ab49-4655-a00e-7e88429dfa0c"), null, null, 1 },
                    { 7, "Health", "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 438, DateTimeKind.Local).AddTicks(7370), "voluptate", "192.168.1.34", new Guid("828708f1-ed77-4b31-90c5-60a3d6e57a72"), null, null, 1 },
                    { 8, "Movies", "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 438, DateTimeKind.Local).AddTicks(9190), "vero", "192.168.1.34", new Guid("dc7ce2bc-8fa3-45f7-9d58-79052b304512"), null, null, 1 },
                    { 9, "Sports", "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 439, DateTimeKind.Local).AddTicks(1035), "consequatur", "192.168.1.34", new Guid("c1258df4-a8f7-4cc4-950e-7b9650467562"), null, null, 1 },
                    { 10, "Grocery", "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 439, DateTimeKind.Local).AddTicks(2859), "id", "192.168.1.34", new Guid("4bb3d4f9-7916-4221-b069-7f4e83112151"), null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Shippers",
                columns: new[] { "ID", "ComputerName", "ContactInfo", "CreatedDate", "IpAddress", "IsActive", "MasterId", "ModifiedComputerName", "ModifiedDate", "ShipperName", "Status" },
                values: new object[,]
                {
                    { 1, "DESKTOP-E0P9L99", "0850 222 0 606", new DateTime(2025, 10, 11, 7, 50, 46, 465, DateTimeKind.Local).AddTicks(4083), "192.168.1.34", true, new Guid("b784f1ca-d468-494d-8f1c-4d2637e87795"), null, null, "MNG Kargo", 1 },
                    { 2, "DESKTOP-E0P9L99", "444 99 99", new DateTime(2025, 10, 11, 7, 50, 46, 465, DateTimeKind.Local).AddTicks(5977), "192.168.1.34", true, new Guid("05d44a96-e6d3-4cf6-a035-61ab0fb69e6e"), null, null, "Yurtiçi Kargo", 1 },
                    { 3, "DESKTOP-E0P9L99", "444 25 52", new DateTime(2025, 10, 11, 7, 50, 46, 465, DateTimeKind.Local).AddTicks(7704), "192.168.1.34", true, new Guid("54e31a60-7c4b-44b7-a5ae-cbfb40970a86"), null, null, "Aras Kargo", 1 },
                    { 4, "DESKTOP-E0P9L99", "444 1 788", new DateTime(2025, 10, 11, 7, 50, 46, 465, DateTimeKind.Local).AddTicks(9379), "192.168.1.34", true, new Guid("477bece3-226e-44db-a8d2-b20030bf5bf0"), null, null, "PTT Kargo", 1 },
                    { 5, "DESKTOP-E0P9L99", "444 0 078", new DateTime(2025, 10, 11, 7, 50, 46, 466, DateTimeKind.Local).AddTicks(1043), "192.168.1.34", true, new Guid("0f5ca9e7-55f2-4d16-b14c-7d221124b80b"), null, null, "Sürat Kargo", 1 }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "ID", "Address", "City", "CompanyName", "ComputerName", "ContactName", "ContactTitle", "Country", "CreatedDate", "Email", "IpAddress", "IsActive", "MasterId", "ModifiedComputerName", "ModifiedDate", "PasswordHash", "Phone", "Status", "Username" },
                values: new object[,]
                {
                    { 1, "Atatürk Cad. No:123", "İstanbul", "ABC Tedarik Ltd.", "SEED", "Ali Veli", "Satış Müdürü", "Türkiye", new DateTime(2025, 10, 11, 7, 50, 46, 466, DateTimeKind.Local).AddTicks(9218), "supplier1@test.com", "127.0.0.1", true, new Guid("7ce7d333-df4a-45fa-8a8b-577334303c41"), null, null, "Pass123!", "0212-555-0001", 1, "supplier1" },
                    { 2, "İnönü Bulvarı No:456", "Ankara", "XYZ Dağıtım A.Ş.", "SEED", "Ayşe Yılmaz", "Genel Müdür", "Türkiye", new DateTime(2025, 10, 11, 7, 50, 46, 467, DateTimeKind.Local).AddTicks(957), "supplier2@test.com", "127.0.0.1", true, new Guid("56f2e96d-7e03-462f-b926-d4a6793a0ab4"), null, null, "Pass123!", "0312-555-0002", 1, "supplier2" },
                    { 3, "Cumhuriyet Mah. No:789", "İzmir", "Global Tedarik Ltd.", "SEED", "Mehmet Kaya", "Satış Direktörü", "Türkiye", new DateTime(2025, 10, 11, 7, 50, 46, 467, DateTimeKind.Local).AddTicks(2652), "supplier3@test.com", "127.0.0.1", true, new Guid("50a593e3-c6fa-4c7c-b81c-00dea76eaa7f"), null, null, "Pass123!", "0232-555-0003", 1, "supplier3" },
                    { 4, "41870 Schmidt Stravenue", "Bahringerhaven", "Nolan Group", "SEED", "Guadalupe Roob", "Customer Intranet Engineer", "Türkiye", new DateTime(2025, 10, 11, 7, 50, 46, 469, DateTimeKind.Local).AddTicks(1249), "Wyatt.Mertz82@gmail.com", "127.0.0.1", true, new Guid("43824fbb-b90f-48dc-8bff-deae716d58f1"), null, null, "Pass123!", "1-958-831-6431", 1, "supplier4" },
                    { 5, "59811 Bednar Ramp", "Schinnertown", "Douglas and Sons", "SEED", "Ashton Murazik", "Future Group Architect", "Türkiye", new DateTime(2025, 10, 11, 7, 50, 46, 469, DateTimeKind.Local).AddTicks(3735), "Shanon75@hotmail.com", "127.0.0.1", true, new Guid("4bde20ee-2761-48c6-93e6-f2094670155c"), null, null, "Pass123!", "1-280-527-1832 x4153", 1, "supplier5" },
                    { 6, "8987 Conroy Coves", "Madilynville", "Balistreri Inc", "SEED", "Gregg Mertz", "Dynamic Solutions Producer", "Türkiye", new DateTime(2025, 10, 11, 7, 50, 46, 469, DateTimeKind.Local).AddTicks(6077), "Eula_Ratke@yahoo.com", "127.0.0.1", true, new Guid("f887d843-0c08-4edf-895b-65b55885fba7"), null, null, "Pass123!", "1-778-373-0202", 1, "supplier6" },
                    { 7, "61025 Murray Ridge", "South Rudy", "Krajcik, Stokes and Feest", "SEED", "Verlie Hessel", "Investor Division Specialist", "Türkiye", new DateTime(2025, 10, 11, 7, 50, 46, 469, DateTimeKind.Local).AddTicks(8415), "Blaise_Hickle@yahoo.com", "127.0.0.1", true, new Guid("8b90b271-bd89-46c3-aac4-508efec29f72"), null, null, "Pass123!", "717-574-2851", 1, "supplier7" },
                    { 8, "34616 Kaylie Vista", "West Santiagoland", "Kemmer and Sons", "SEED", "Violet Jacobson", "Future Implementation Consultant", "Türkiye", new DateTime(2025, 10, 11, 7, 50, 46, 470, DateTimeKind.Local).AddTicks(1409), "Erling.Gottlieb58@hotmail.com", "127.0.0.1", true, new Guid("9d5c29b7-fc7f-4bd2-83a4-78e67b8440fb"), null, null, "Pass123!", "932.854.8611 x370", 1, "supplier8" },
                    { 9, "951 Lucile Brook", "Gregoryhaven", "Koch and Sons", "SEED", "Gloria Bahringer", "Investor Marketing Director", "Türkiye", new DateTime(2025, 10, 11, 7, 50, 46, 470, DateTimeKind.Local).AddTicks(3690), "Alexane.Abshire5@gmail.com", "127.0.0.1", true, new Guid("00509379-9f42-4e6c-b5c0-c9dfd6d22488"), null, null, "Pass123!", "1-205-516-0000 x9389", 1, "supplier9" },
                    { 10, "7724 Boehm Plaza", "Mustafatown", "O'Connell Group", "SEED", "Cierra Cruickshank", "Chief Usability Representative", "Türkiye", new DateTime(2025, 10, 11, 7, 50, 46, 470, DateTimeKind.Local).AddTicks(5943), "Kaden.Brown18@gmail.com", "127.0.0.1", true, new Guid("f91d28d6-a899-4a9c-9057-c9bc984e5ea7"), null, null, "Pass123!", "1-878-811-9145 x58286", 1, "supplier10" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryId", "ComputerName", "CreatedDate", "Description", "IpAddress", "MasterId", "ModifiedComputerName", "ModifiedDate", "Price", "ProductName", "Status", "Stock", "SupplierId" },
                values: new object[,]
                {
                    { 1, 1, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 442, DateTimeKind.Local).AddTicks(733), "Expedita fugiat aliquam expedita dolore.", "192.168.1.34", new Guid("0e62de46-702e-4950-ae46-1ecc2b7366f0"), null, null, 541.66m, "Handcrafted Granite Shirt", 1, 34, 1 },
                    { 2, 1, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 442, DateTimeKind.Local).AddTicks(2946), "Error eius quas qui quia.", "192.168.1.34", new Guid("479b84b7-57e5-4466-8c72-b4c0c7efa1a1"), null, null, 120.92m, "Awesome Metal Chips", 1, 37, 1 },
                    { 3, 1, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 442, DateTimeKind.Local).AddTicks(5549), "Sequi ut ipsa quos repudiandae.", "192.168.1.34", new Guid("3479e996-e13d-427c-9d07-631d2be11891"), null, null, 964.40m, "Incredible Granite Pizza", 1, 26, 1 },
                    { 4, 1, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 442, DateTimeKind.Local).AddTicks(7592), "A sint quibusdam qui voluptatem.", "192.168.1.34", new Guid("bf5d5e46-6504-4996-9a3a-994141f3c15c"), null, null, 875.23m, "Unbranded Soft Table", 1, 40, 1 },
                    { 5, 1, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 442, DateTimeKind.Local).AddTicks(9536), "Dolore repellat aut veritatis temporibus.", "192.168.1.34", new Guid("f9476245-55cb-4f2a-94b9-8b43a617da67"), null, null, 36.72m, "Awesome Cotton Sausages", 1, 8, 1 },
                    { 6, 1, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 443, DateTimeKind.Local).AddTicks(1482), "Beatae eum ab et sapiente.", "192.168.1.34", new Guid("b0b9cba4-1ed6-4bef-8389-6ef4ed35c1bb"), null, null, 854.48m, "Unbranded Fresh Chair", 1, 15, 1 },
                    { 7, 1, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 443, DateTimeKind.Local).AddTicks(3381), "Culpa et omnis quia et.", "192.168.1.34", new Guid("1827c9f2-7907-421a-abff-ea50b2c5a2e0"), null, null, 245.80m, "Ergonomic Frozen Fish", 1, 40, 1 },
                    { 8, 1, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 443, DateTimeKind.Local).AddTicks(5247), "Ducimus eum ex alias repellat.", "192.168.1.34", new Guid("388acd5f-8df9-4f4e-a184-71d83443d52c"), null, null, 620.95m, "Ergonomic Soft Ball", 1, 91, 1 },
                    { 9, 1, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 443, DateTimeKind.Local).AddTicks(7103), "Dolorem enim iure sed eos.", "192.168.1.34", new Guid("bdb5a51d-d64e-47e7-af37-b4b94171f1e5"), null, null, 953.00m, "Unbranded Fresh Car", 1, 74, 1 },
                    { 10, 1, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 443, DateTimeKind.Local).AddTicks(8980), "Unde pariatur non animi reiciendis.", "192.168.1.34", new Guid("630a6b26-aa41-4f70-8368-20a4e3966f3f"), null, null, 879.37m, "Fantastic Granite Soap", 1, 34, 1 },
                    { 11, 2, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 444, DateTimeKind.Local).AddTicks(903), "Consequatur similique at voluptatum quasi.", "192.168.1.34", new Guid("5d41002f-d8c2-4122-8a03-b124bdaae8bb"), null, null, 965.76m, "Intelligent Soft Towels", 1, 62, 2 },
                    { 12, 2, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 444, DateTimeKind.Local).AddTicks(2749), "İnventore molestiae totam ut aut.", "192.168.1.34", new Guid("d9ce8df7-2df9-4f22-9084-66f9e3f695fb"), null, null, 704.75m, "Fantastic Steel Shoes", 1, 10, 2 },
                    { 13, 2, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 444, DateTimeKind.Local).AddTicks(4594), "Est laboriosam quia dignissimos aut.", "192.168.1.34", new Guid("059ac950-9874-4043-8d58-34c036b063f1"), null, null, 264.83m, "Practical Metal Towels", 1, 87, 2 },
                    { 14, 2, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 444, DateTimeKind.Local).AddTicks(6654), "Aperiam dolor veritatis nostrum odit.", "192.168.1.34", new Guid("578e4cd4-bf05-4828-bc9f-78032bbafb30"), null, null, 444.10m, "Fantastic Rubber Bike", 1, 56, 2 },
                    { 15, 2, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 444, DateTimeKind.Local).AddTicks(8527), "Voluptatum qui tempore corrupti eveniet.", "192.168.1.34", new Guid("e49f4a57-c5b7-42c5-b664-c36822fa2649"), null, null, 36.64m, "Handcrafted Cotton Computer", 1, 21, 2 },
                    { 16, 2, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 445, DateTimeKind.Local).AddTicks(377), "İpsa maiores libero omnis excepturi.", "192.168.1.34", new Guid("7dd30b2d-36d2-4a5d-bb94-3109df250f74"), null, null, 741.45m, "Rustic Soft Salad", 1, 40, 2 },
                    { 17, 2, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 445, DateTimeKind.Local).AddTicks(2214), "Hic molestiae pariatur molestias soluta.", "192.168.1.34", new Guid("dc5ef344-b9ae-40e9-a9e1-f3a20611db56"), null, null, 817.60m, "Fantastic Wooden Hat", 1, 75, 2 },
                    { 18, 2, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 445, DateTimeKind.Local).AddTicks(4045), "Dolor culpa nihil fuga quam.", "192.168.1.34", new Guid("f587fee1-00ee-4fe1-9079-d31d25868fd9"), null, null, 741.23m, "Refined Wooden Chair", 1, 40, 2 },
                    { 19, 2, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 445, DateTimeKind.Local).AddTicks(5877), "Dolorem id non at fugiat.", "192.168.1.34", new Guid("f8957a45-cda6-45e8-af69-52ef7b576fb4"), null, null, 914.76m, "Sleek Rubber Salad", 1, 76, 2 },
                    { 20, 2, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 445, DateTimeKind.Local).AddTicks(7698), "Cumque cum inventore similique qui.", "192.168.1.34", new Guid("2742fdef-5364-4463-8b4b-9672f346cf3e"), null, null, 289.89m, "Ergonomic Granite Ball", 1, 78, 2 },
                    { 21, 3, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 445, DateTimeKind.Local).AddTicks(9522), "Molestiae dolores voluptatum aliquid minus.", "192.168.1.34", new Guid("b01ab24c-efd3-498a-94ed-3811aa398899"), null, null, 411.03m, "Rustic Wooden Chair", 1, 19, 3 },
                    { 22, 3, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 446, DateTimeKind.Local).AddTicks(1390), "Et veritatis in ab et.", "192.168.1.34", new Guid("7db5c065-6810-42fa-92fb-bf45dfe1c080"), null, null, 560.96m, "Refined Cotton Towels", 1, 61, 3 },
                    { 23, 3, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 446, DateTimeKind.Local).AddTicks(3221), "Delectus et ea natus ratione.", "192.168.1.34", new Guid("aeca7efd-9c4c-48d0-9fc7-62005ba557e7"), null, null, 725.58m, "Refined Steel Chicken", 1, 28, 3 },
                    { 24, 3, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 446, DateTimeKind.Local).AddTicks(5063), "Numquam esse est non nulla.", "192.168.1.34", new Guid("e14279b9-a30f-4ec8-954d-2db08bd6c234"), null, null, 932.58m, "Refined Metal Mouse", 1, 16, 3 },
                    { 25, 3, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 446, DateTimeKind.Local).AddTicks(6895), "Ut in aut beatae sequi.", "192.168.1.34", new Guid("cc8428f2-c1f9-4ade-8dc8-84c5f336c2c6"), null, null, 39.75m, "Gorgeous Rubber Soap", 1, 26, 3 },
                    { 26, 3, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 446, DateTimeKind.Local).AddTicks(8705), "Nostrum totam occaecati recusandae sunt.", "192.168.1.34", new Guid("d76de026-fe57-4bf5-9d9a-82e7b74b9b7d"), null, null, 806.11m, "Ergonomic Wooden Ball", 1, 25, 3 },
                    { 27, 3, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 447, DateTimeKind.Local).AddTicks(553), "Ratione amet exercitationem molestiae iusto.", "192.168.1.34", new Guid("5249ff11-87e4-47f0-a1cd-b5197f46d036"), null, null, 194.05m, "Small Cotton Gloves", 1, 96, 3 },
                    { 28, 3, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 447, DateTimeKind.Local).AddTicks(2355), "Et eius quis non libero.", "192.168.1.34", new Guid("3abe6a45-e0aa-4567-8cc8-5481e3a27686"), null, null, 942.23m, "Ergonomic Cotton Pizza", 1, 9, 3 },
                    { 29, 3, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 447, DateTimeKind.Local).AddTicks(4181), "Fugiat in rem magnam consequatur.", "192.168.1.34", new Guid("9a4f0903-1f65-47e4-adb4-b09b51a580cc"), null, null, 947.62m, "Generic Metal Hat", 1, 97, 3 },
                    { 30, 3, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 447, DateTimeKind.Local).AddTicks(6001), "Voluptas et necessitatibus autem at.", "192.168.1.34", new Guid("cfa753ad-6426-4548-8291-519cd3d5cb3f"), null, null, 754.03m, "Rustic Frozen Mouse", 1, 81, 3 },
                    { 31, 4, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 447, DateTimeKind.Local).AddTicks(7823), "Error quis sed ullam perspiciatis.", "192.168.1.34", new Guid("443d0677-d001-40f5-a17e-0c635fc9a216"), null, null, 712.25m, "Practical Frozen Shirt", 1, 65, 4 },
                    { 32, 4, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 447, DateTimeKind.Local).AddTicks(9629), "Voluptas voluptatum incidunt doloremque dolores.", "192.168.1.34", new Guid("da76fd52-1ee9-4ac0-8d08-8d6050a2c1b3"), null, null, 452.93m, "Fantastic Cotton Shirt", 1, 79, 4 },
                    { 33, 4, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 448, DateTimeKind.Local).AddTicks(1505), "Quibusdam ut et consequatur aliquam.", "192.168.1.34", new Guid("177b0330-49c0-4b00-a3aa-a0d614b78a43"), null, null, 171.77m, "Handcrafted Steel Hat", 1, 44, 4 },
                    { 34, 4, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 448, DateTimeKind.Local).AddTicks(3338), "Tempore tenetur repellendus explicabo aut.", "192.168.1.34", new Guid("4e6019de-6caf-4bfe-94e5-39faa5de1655"), null, null, 352.75m, "Handmade Cotton Keyboard", 1, 28, 4 },
                    { 35, 4, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 448, DateTimeKind.Local).AddTicks(5176), "Dolor qui illo rerum mollitia.", "192.168.1.34", new Guid("047df544-487c-4520-84dc-059b4bb08d4e"), null, null, 921.77m, "Practical Fresh Keyboard", 1, 76, 4 },
                    { 36, 4, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 448, DateTimeKind.Local).AddTicks(6993), "Ea quia reprehenderit iusto et.", "192.168.1.34", new Guid("9dfdeb45-9a6f-4305-a30b-5df4061f46ea"), null, null, 811.09m, "Sleek Plastic Towels", 1, 75, 4 },
                    { 37, 4, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 452, DateTimeKind.Local).AddTicks(6511), "İmpedit culpa provident ea vel.", "192.168.1.34", new Guid("fc3379ce-caa9-48a3-900b-d8ae4f255f65"), null, null, 296.88m, "Rustic Fresh Car", 1, 31, 4 },
                    { 38, 4, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 452, DateTimeKind.Local).AddTicks(8748), "Aut praesentium cum deleniti aperiam.", "192.168.1.34", new Guid("cb5e5302-02c9-4ff9-a8f1-d49db0878625"), null, null, 289.66m, "Handmade Plastic Shirt", 1, 39, 4 },
                    { 39, 4, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 453, DateTimeKind.Local).AddTicks(943), "Quia deleniti cupiditate placeat enim.", "192.168.1.34", new Guid("f768f03a-9feb-4b98-af7e-12875fba2916"), null, null, 722.82m, "Refined Frozen Shoes", 1, 69, 4 },
                    { 40, 4, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 453, DateTimeKind.Local).AddTicks(3021), "İllum voluptas sunt ut accusantium.", "192.168.1.34", new Guid("102c45c0-b8e7-4b72-8a83-143ec9b9ca11"), null, null, 762.73m, "Gorgeous Frozen Hat", 1, 70, 4 },
                    { 41, 5, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 453, DateTimeKind.Local).AddTicks(5078), "Et voluptatem perspiciatis qui sed.", "192.168.1.34", new Guid("0e323df5-f993-41a7-943d-1e5ac628741d"), null, null, 980.44m, "Ergonomic Cotton Pizza", 1, 33, 5 },
                    { 42, 5, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 453, DateTimeKind.Local).AddTicks(7114), "Optio inventore vel vel et.", "192.168.1.34", new Guid("a2f53d90-f11c-4023-a688-cb9a71451bae"), null, null, 746.35m, "Intelligent Soft Fish", 1, 66, 5 },
                    { 43, 5, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 453, DateTimeKind.Local).AddTicks(9134), "Rem odio ut fugit provident.", "192.168.1.34", new Guid("473f89aa-2352-412b-8a48-7ac1b17161f8"), null, null, 349.08m, "Fantastic Wooden Chips", 1, 32, 5 },
                    { 44, 5, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 454, DateTimeKind.Local).AddTicks(1466), "Nihil veritatis aut sint consequatur.", "192.168.1.34", new Guid("d88b5ae5-366b-41ee-9018-c8adc84b2b13"), null, null, 711.70m, "Intelligent Concrete Computer", 1, 54, 5 },
                    { 45, 5, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 454, DateTimeKind.Local).AddTicks(3480), "Quisquam architecto pariatur quam autem.", "192.168.1.34", new Guid("9a3b676b-b472-48b2-ae81-f5f8c92681a3"), null, null, 875.20m, "Rustic Fresh Salad", 1, 29, 5 },
                    { 46, 5, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 454, DateTimeKind.Local).AddTicks(5484), "Assumenda tempora qui modi iure.", "192.168.1.34", new Guid("27610f22-e153-49fd-90b0-03e0375317ff"), null, null, 904.57m, "Handmade Soft Table", 1, 8, 5 },
                    { 47, 5, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 454, DateTimeKind.Local).AddTicks(7776), "Molestiae aut magni beatae aut.", "192.168.1.34", new Guid("b54ed27b-9887-4c8e-b565-f84e9851a105"), null, null, 88.33m, "Ergonomic Frozen Shirt", 1, 47, 5 },
                    { 48, 5, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 454, DateTimeKind.Local).AddTicks(9777), "Porro blanditiis maxime aut aut.", "192.168.1.34", new Guid("b5f0d9c0-e98e-4fa4-91ba-ba75b116aef2"), null, null, 361.41m, "Ergonomic Plastic Pizza", 1, 78, 5 },
                    { 49, 5, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 455, DateTimeKind.Local).AddTicks(1637), "Occaecati est maiores numquam ea.", "192.168.1.34", new Guid("10b8d35f-89cd-49be-b134-da35926b9a61"), null, null, 415.28m, "Awesome Plastic Table", 1, 19, 5 },
                    { 50, 5, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 455, DateTimeKind.Local).AddTicks(3487), "Cum nesciunt totam doloremque rerum.", "192.168.1.34", new Guid("73b7b5ee-0d37-43e7-a1b2-96d69eeb4626"), null, null, 326.61m, "Tasty Steel Fish", 1, 17, 5 },
                    { 51, 6, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 455, DateTimeKind.Local).AddTicks(5313), "Voluptatibus porro vel ut perspiciatis.", "192.168.1.34", new Guid("5d146743-b37e-4ee1-acbe-0ccb77b70077"), null, null, 137.06m, "Handmade Steel Tuna", 1, 64, 6 },
                    { 52, 6, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 455, DateTimeKind.Local).AddTicks(7126), "Est quae illo consequatur doloremque.", "192.168.1.34", new Guid("0301e138-9181-4ccb-b659-bbf49618166c"), null, null, 757.15m, "Ergonomic Metal Salad", 1, 35, 6 },
                    { 53, 6, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 455, DateTimeKind.Local).AddTicks(8937), "Tenetur nam doloribus recusandae accusamus.", "192.168.1.34", new Guid("88e491b5-009f-4d1a-8003-09dbf31250c2"), null, null, 150.88m, "Incredible Granite Gloves", 1, 42, 6 },
                    { 54, 6, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 456, DateTimeKind.Local).AddTicks(811), "Dicta similique unde repudiandae deserunt.", "192.168.1.34", new Guid("bbc179f3-c372-4149-987d-e07c009bc59e"), null, null, 288.69m, "Awesome Fresh Hat", 1, 84, 6 },
                    { 55, 6, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 456, DateTimeKind.Local).AddTicks(2653), "Cupiditate vel adipisci nam illo.", "192.168.1.34", new Guid("4d62df14-2494-4f78-8339-7032b6c75005"), null, null, 912.21m, "Generic Frozen Sausages", 1, 18, 6 },
                    { 56, 6, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 456, DateTimeKind.Local).AddTicks(4480), "Sequi qui occaecati est sed.", "192.168.1.34", new Guid("0aad1e4e-7ece-4ad4-b3f9-eae1c28803f0"), null, null, 442.59m, "Intelligent Frozen Cheese", 1, 96, 6 },
                    { 57, 6, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 456, DateTimeKind.Local).AddTicks(6298), "İnventore dolorum expedita deserunt et.", "192.168.1.34", new Guid("a58f9c9d-5dee-4aaf-8252-fd04ffa7f9dc"), null, null, 889.77m, "Gorgeous Rubber Table", 1, 20, 6 },
                    { 58, 6, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 456, DateTimeKind.Local).AddTicks(8140), "İmpedit id enim eius quod.", "192.168.1.34", new Guid("86edc922-0405-4881-925f-2def0f968f6b"), null, null, 581.74m, "Practical Wooden Salad", 1, 92, 6 },
                    { 59, 6, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 457, DateTimeKind.Local).AddTicks(7), "Doloremque asperiores perferendis quod voluptatum.", "192.168.1.34", new Guid("a38b5232-a9ae-48fb-a4d5-c9051964bfcb"), null, null, 867.52m, "Awesome Granite Table", 1, 68, 6 },
                    { 60, 6, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 457, DateTimeKind.Local).AddTicks(1833), "Enim quod optio qui sint.", "192.168.1.34", new Guid("bc785eda-3297-47be-9a7e-da29ec636ddb"), null, null, 570.38m, "Unbranded Concrete Chicken", 1, 87, 6 },
                    { 61, 7, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 457, DateTimeKind.Local).AddTicks(3654), "Sit et ut debitis impedit.", "192.168.1.34", new Guid("f1b4ea84-5779-4d65-88cb-d6ec984db412"), null, null, 473.92m, "Sleek Cotton Shoes", 1, 75, 7 },
                    { 62, 7, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 457, DateTimeKind.Local).AddTicks(5465), "Soluta qui a facilis quae.", "192.168.1.34", new Guid("8b072fef-bb76-44cf-aaee-6d2a5b218d90"), null, null, 705.54m, "Unbranded Fresh Salad", 1, 92, 7 },
                    { 63, 7, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 457, DateTimeKind.Local).AddTicks(7292), "Fugit quia dolor quo rerum.", "192.168.1.34", new Guid("e9f0a5ac-0c3d-4030-81c1-98507409e62e"), null, null, 228.92m, "Ergonomic Soft Ball", 1, 61, 7 },
                    { 64, 7, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 457, DateTimeKind.Local).AddTicks(9095), "Autem iste alias est et.", "192.168.1.34", new Guid("9801b592-f363-47c4-b79a-242934ccc5ff"), null, null, 316.77m, "Practical Rubber Pizza", 1, 26, 7 },
                    { 65, 7, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 458, DateTimeKind.Local).AddTicks(1053), "Facere dicta ut velit omnis.", "192.168.1.34", new Guid("5f3ee2af-7ebc-4304-b24d-c6e66770e47a"), null, null, 952.90m, "Awesome Wooden Chair", 1, 55, 7 },
                    { 66, 7, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 458, DateTimeKind.Local).AddTicks(2896), "Exercitationem optio et sed sunt.", "192.168.1.34", new Guid("934e5efd-1fba-4705-9975-c968b1cec403"), null, null, 494.73m, "Fantastic Metal Shoes", 1, 76, 7 },
                    { 67, 7, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 458, DateTimeKind.Local).AddTicks(4733), "Natus mollitia ex occaecati dolores.", "192.168.1.34", new Guid("00dcd38e-7baf-4834-ab48-f61b98a882a5"), null, null, 44.46m, "Awesome Metal Car", 1, 33, 7 },
                    { 68, 7, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 458, DateTimeKind.Local).AddTicks(6553), "Excepturi doloribus error temporibus qui.", "192.168.1.34", new Guid("bf9a6cdc-54c7-4fcf-9ae1-7669e741fd86"), null, null, 545.07m, "Sleek Soft Bacon", 1, 76, 7 },
                    { 69, 7, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 458, DateTimeKind.Local).AddTicks(8360), "Sed similique ut illo in.", "192.168.1.34", new Guid("df7b8a53-348e-4cdf-9f3e-c1a64677126c"), null, null, 530.83m, "Licensed Fresh Towels", 1, 8, 7 },
                    { 70, 7, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 459, DateTimeKind.Local).AddTicks(244), "Quisquam qui nihil molestiae dolorem.", "192.168.1.34", new Guid("9e2eaf6a-c501-40ed-86cf-440992b237b2"), null, null, 741.17m, "Refined Wooden Gloves", 1, 66, 7 },
                    { 71, 8, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 459, DateTimeKind.Local).AddTicks(2276), "Consequuntur id maiores explicabo autem.", "192.168.1.34", new Guid("5016e7ac-bfd1-4802-83d1-391bbd6d4a53"), null, null, 581.07m, "Sleek Steel Salad", 1, 59, 8 },
                    { 72, 8, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 459, DateTimeKind.Local).AddTicks(4563), "Perferendis et voluptas sed tempora.", "192.168.1.34", new Guid("94b2630c-e02d-45b4-85d7-dd02faeea870"), null, null, 596.60m, "Intelligent Frozen Salad", 1, 93, 8 },
                    { 73, 8, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 459, DateTimeKind.Local).AddTicks(6543), "Maxime non qui vel blanditiis.", "192.168.1.34", new Guid("1db73b51-0bdf-4186-b042-7fcbd3c9bf51"), null, null, 447.01m, "Incredible Wooden Tuna", 1, 68, 8 },
                    { 74, 8, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 459, DateTimeKind.Local).AddTicks(8420), "Voluptate veniam repellat veniam eaque.", "192.168.1.34", new Guid("16544730-15bf-4594-a795-871e5db5b839"), null, null, 578.23m, "Tasty Fresh Chips", 1, 7, 8 },
                    { 75, 8, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 460, DateTimeKind.Local).AddTicks(291), "Pariatur unde nostrum saepe dolores.", "192.168.1.34", new Guid("31c8fe70-f706-458b-9375-185ddbb8eafa"), null, null, 710.41m, "Handmade Frozen Bike", 1, 4, 8 },
                    { 76, 8, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 460, DateTimeKind.Local).AddTicks(2114), "A non neque omnis voluptate.", "192.168.1.34", new Guid("3f1ca935-73f9-4b66-8d78-5f5951df26fe"), null, null, 720.36m, "Gorgeous Cotton Shirt", 1, 24, 8 },
                    { 77, 8, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 460, DateTimeKind.Local).AddTicks(3927), "Nemo facere minima odit ipsum.", "192.168.1.34", new Guid("c5739ce4-e699-479e-8758-4b836c11a991"), null, null, 125.53m, "Generic Steel Chicken", 1, 38, 8 },
                    { 78, 8, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 460, DateTimeKind.Local).AddTicks(5722), "Aut aut laboriosam commodi nam.", "192.168.1.34", new Guid("6a33ddff-953e-4e89-9f03-0fc3c4acc22f"), null, null, 593.76m, "Generic Granite Bacon", 1, 29, 8 },
                    { 79, 8, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 460, DateTimeKind.Local).AddTicks(7508), "Corporis non tempora ipsam adipisci.", "192.168.1.34", new Guid("beb89d1d-0a62-48dc-9443-0466c47946a4"), null, null, 279.85m, "Refined Wooden Cheese", 1, 7, 8 },
                    { 80, 8, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 460, DateTimeKind.Local).AddTicks(9505), "Exercitationem et mollitia odit delectus.", "192.168.1.34", new Guid("5512f773-ce7e-4bfe-91d0-074507e4c929"), null, null, 863.49m, "Handcrafted Frozen Tuna", 1, 23, 8 },
                    { 81, 9, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 461, DateTimeKind.Local).AddTicks(1310), "Vel aut quia aut at.", "192.168.1.34", new Guid("f436b4bd-0995-42cb-9549-12136f5c6e79"), null, null, 52.80m, "Awesome Concrete Cheese", 1, 22, 9 },
                    { 82, 9, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 461, DateTimeKind.Local).AddTicks(3099), "Aut deserunt eos provident molestias.", "192.168.1.34", new Guid("ddef1ca0-9213-493c-b29e-df1561ae708a"), null, null, 781.06m, "Intelligent Wooden Shirt", 1, 62, 9 },
                    { 83, 9, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 461, DateTimeKind.Local).AddTicks(4896), "Numquam quasi voluptas asperiores dolore.", "192.168.1.34", new Guid("c56b5fc6-ae38-471e-b801-c3b551d73720"), null, null, 909.70m, "Unbranded Plastic Computer", 1, 49, 9 },
                    { 84, 9, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 461, DateTimeKind.Local).AddTicks(6676), "Occaecati eaque est mollitia occaecati.", "192.168.1.34", new Guid("18244bb0-72a2-4855-b70f-74d91e053300"), null, null, 414.95m, "Fantastic Fresh Hat", 1, 87, 9 },
                    { 85, 9, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 461, DateTimeKind.Local).AddTicks(8483), "Qui dolorem impedit ea cupiditate.", "192.168.1.34", new Guid("99499362-1ed7-465b-8ac7-c90cb28357a4"), null, null, 268.07m, "Intelligent Fresh Tuna", 1, 16, 9 },
                    { 86, 9, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 462, DateTimeKind.Local).AddTicks(262), "Vel quasi veritatis illo blanditiis.", "192.168.1.34", new Guid("368be6d5-13cf-473c-9a3f-afebf5003952"), null, null, 426.40m, "Licensed Plastic Chips", 1, 35, 9 },
                    { 87, 9, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 462, DateTimeKind.Local).AddTicks(2031), "Ad nostrum qui ut distinctio.", "192.168.1.34", new Guid("471f8a82-b659-4888-b1af-af91b8e621c6"), null, null, 472.86m, "Handmade Metal Chicken", 1, 80, 9 },
                    { 88, 9, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 462, DateTimeKind.Local).AddTicks(3800), "Et ut expedita reiciendis aut.", "192.168.1.34", new Guid("28b422f6-365f-4fd2-af4e-5667b6f85133"), null, null, 178.75m, "Handmade Cotton Keyboard", 1, 95, 9 },
                    { 89, 9, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 462, DateTimeKind.Local).AddTicks(5583), "At perferendis animi ut et.", "192.168.1.34", new Guid("3c279d40-8010-4443-80c9-83556334b2fe"), null, null, 730.79m, "Sleek Granite Salad", 1, 18, 9 },
                    { 90, 9, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 462, DateTimeKind.Local).AddTicks(7365), "Nesciunt consequatur natus nulla odio.", "192.168.1.34", new Guid("dbdadc40-59c0-4ab0-b83d-134b657a6718"), null, null, 541.99m, "Ergonomic Frozen Chicken", 1, 100, 9 },
                    { 91, 10, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 462, DateTimeKind.Local).AddTicks(9137), "Blanditiis sed autem beatae ducimus.", "192.168.1.34", new Guid("72d268f9-3dcd-40d1-b7bb-b590132a2682"), null, null, 989.65m, "Handmade Soft Pants", 1, 17, 10 },
                    { 92, 10, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 463, DateTimeKind.Local).AddTicks(1135), "Possimus qui commodi quas quos.", "192.168.1.34", new Guid("ebb1c485-c790-4ead-bd39-c74309afdaf6"), null, null, 73.59m, "Practical Steel Ball", 1, 54, 10 },
                    { 93, 10, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 463, DateTimeKind.Local).AddTicks(2990), "Nihil maiores dolores delectus exercitationem.", "192.168.1.34", new Guid("b46dd216-00a3-4561-8c78-03662a17f254"), null, null, 257.55m, "Practical Rubber Towels", 1, 93, 10 },
                    { 94, 10, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 463, DateTimeKind.Local).AddTicks(4722), "Eius quo voluptates fuga cumque.", "192.168.1.34", new Guid("037fe258-5a8a-4be5-9520-81bc0d14043b"), null, null, 791.13m, "Small Frozen Soap", 1, 59, 10 },
                    { 95, 10, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 463, DateTimeKind.Local).AddTicks(6434), "Veniam illo officia earum veniam.", "192.168.1.34", new Guid("f85dd8ad-ff69-4bb3-b5df-400bab80030f"), null, null, 968.66m, "Gorgeous Granite Mouse", 1, 29, 10 },
                    { 96, 10, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 463, DateTimeKind.Local).AddTicks(8165), "Et et laboriosam culpa ad.", "192.168.1.34", new Guid("f1a4ecab-4555-484f-b39c-7f5f9e19e685"), null, null, 4.38m, "Sleek Metal Computer", 1, 70, 10 },
                    { 97, 10, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 463, DateTimeKind.Local).AddTicks(9905), "Sed reiciendis est eos in.", "192.168.1.34", new Guid("c7034f0b-d245-4988-af80-f7770d421315"), null, null, 606.41m, "Sleek Fresh Shoes", 1, 2, 10 },
                    { 98, 10, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 464, DateTimeKind.Local).AddTicks(1657), "Rem rem omnis numquam dolores.", "192.168.1.34", new Guid("6865676b-20e3-4096-aa95-d8436755ca16"), null, null, 983.47m, "Sleek Soft Soap", 1, 2, 10 },
                    { 99, 10, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 464, DateTimeKind.Local).AddTicks(3379), "Animi earum deserunt eligendi voluptatem.", "192.168.1.34", new Guid("49fa63c6-217d-4086-a831-1ff280843c3f"), null, null, 92.07m, "Incredible Steel Sausages", 1, 35, 10 },
                    { 100, 10, "DESKTOP-E0P9L99", new DateTime(2025, 10, 11, 7, 50, 46, 464, DateTimeKind.Local).AddTicks(5094), "Sit dicta voluptate qui labore.", "192.168.1.34", new Guid("906169f2-3d50-46b8-9d93-14118ad5132b"), null, null, 777.27m, "Small Soft Tuna", 1, 33, 10 }
                });

            migrationBuilder.InsertData(
                table: "SupplierPermissions",
                columns: new[] { "ID", "ComputerName", "CreatedDate", "IpAddress", "MasterId", "ModifiedComputerName", "ModifiedDate", "Permission", "Status", "SupplierId" },
                values: new object[,]
                {
                    { 1, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 471, DateTimeKind.Local).AddTicks(78), "127.0.0.1", new Guid("a80488e0-3e13-401e-a1cb-db4f882b5c90"), null, null, "ReadProduct", 1, 1 },
                    { 2, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 471, DateTimeKind.Local).AddTicks(1769), "127.0.0.1", new Guid("64373841-637b-4fe5-92fb-0e6c0b8f5145"), null, null, "ReadProduct", 1, 2 },
                    { 3, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 471, DateTimeKind.Local).AddTicks(3423), "127.0.0.1", new Guid("bf50fdc0-a72a-4ea0-885d-ec15994556af"), null, null, "AddProduct", 1, 2 },
                    { 4, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 471, DateTimeKind.Local).AddTicks(5051), "127.0.0.1", new Guid("4ddad24c-48d2-42ce-85bf-fc22670a3764"), null, null, "ReadProduct", 1, 3 },
                    { 5, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 471, DateTimeKind.Local).AddTicks(6686), "127.0.0.1", new Guid("a610e6f0-5524-45e5-8b5b-dc946e365106"), null, null, "AddProduct", 1, 3 },
                    { 6, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 471, DateTimeKind.Local).AddTicks(8327), "127.0.0.1", new Guid("255144f0-48b7-485a-9c19-27504af4ea2a"), null, null, "EditProduct", 1, 3 },
                    { 7, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 471, DateTimeKind.Local).AddTicks(9962), "127.0.0.1", new Guid("fe460fe0-6476-4d61-a560-e636f30d94b7"), null, null, "DeleteProduct", 1, 3 },
                    { 8, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 472, DateTimeKind.Local).AddTicks(1650), "127.0.0.1", new Guid("370bab2d-eed0-4324-8f62-d271ee8e3ae0"), null, null, "EditProduct", 1, 4 },
                    { 9, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 472, DateTimeKind.Local).AddTicks(3246), "127.0.0.1", new Guid("8240e496-a6c5-48fa-ac12-a02582492873"), null, null, "ReadProduct", 1, 4 },
                    { 10, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 472, DateTimeKind.Local).AddTicks(4852), "127.0.0.1", new Guid("60aa8367-7c18-4789-a8ba-788297d0e902"), null, null, "AddProduct", 1, 4 },
                    { 11, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 472, DateTimeKind.Local).AddTicks(6471), "127.0.0.1", new Guid("5f4d2c59-b31e-4151-892e-bd491339291f"), null, null, "DeleteProduct", 1, 4 },
                    { 12, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 472, DateTimeKind.Local).AddTicks(8092), "127.0.0.1", new Guid("8e8aafaf-000d-499a-add0-fe04d645c2e6"), null, null, "EditProduct", 1, 5 },
                    { 13, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 472, DateTimeKind.Local).AddTicks(9707), "127.0.0.1", new Guid("1768cbf2-fee9-4981-8557-4c8eba26262e"), null, null, "AddProduct", 1, 6 },
                    { 14, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 473, DateTimeKind.Local).AddTicks(1324), "127.0.0.1", new Guid("bc7913c8-8a78-479d-98cd-e094c21a3b0c"), null, null, "DeleteProduct", 1, 6 },
                    { 15, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 473, DateTimeKind.Local).AddTicks(2913), "127.0.0.1", new Guid("e2230a5c-cec5-4cdb-a84c-1c01657e3714"), null, null, "ReadProduct", 1, 6 },
                    { 16, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 473, DateTimeKind.Local).AddTicks(4545), "127.0.0.1", new Guid("14b2ca43-c000-4954-ad30-7d7d3d81ceb4"), null, null, "ReadProduct", 1, 7 },
                    { 17, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 473, DateTimeKind.Local).AddTicks(6135), "127.0.0.1", new Guid("4120cf63-e248-45d9-8c6a-415a34387e88"), null, null, "DeleteProduct", 1, 7 },
                    { 18, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 473, DateTimeKind.Local).AddTicks(7736), "127.0.0.1", new Guid("bea06faf-912e-47f0-abad-d882af9fd3e7"), null, null, "EditProduct", 1, 7 },
                    { 19, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 473, DateTimeKind.Local).AddTicks(9316), "127.0.0.1", new Guid("583f4a9d-d53d-4982-ad4e-63b35acbfdc3"), null, null, "AddProduct", 1, 7 },
                    { 20, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 474, DateTimeKind.Local).AddTicks(938), "127.0.0.1", new Guid("32a72247-8a4c-4938-b4be-8b671e3299d3"), null, null, "AddProduct", 1, 8 },
                    { 21, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 474, DateTimeKind.Local).AddTicks(2541), "127.0.0.1", new Guid("c48ae2c1-bb9d-4f8f-826b-c08b6e9c0539"), null, null, "DeleteProduct", 1, 9 },
                    { 22, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 474, DateTimeKind.Local).AddTicks(4115), "127.0.0.1", new Guid("95d6eab3-c937-477c-8bee-c989c18616cd"), null, null, "AddProduct", 1, 9 },
                    { 23, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 474, DateTimeKind.Local).AddTicks(5705), "127.0.0.1", new Guid("8cae1cee-e33a-4509-92dd-86abc324a355"), null, null, "ReadProduct", 1, 9 },
                    { 24, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 474, DateTimeKind.Local).AddTicks(7293), "127.0.0.1", new Guid("4302276a-d978-4a62-b21f-b11b463c658d"), null, null, "EditProduct", 1, 9 },
                    { 25, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 474, DateTimeKind.Local).AddTicks(8894), "127.0.0.1", new Guid("8ea51780-5e5b-4090-b301-5b47b263f250"), null, null, "AddProduct", 1, 10 },
                    { 26, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 475, DateTimeKind.Local).AddTicks(711), "127.0.0.1", new Guid("83f80398-f3eb-414f-b48e-ecdaff760000"), null, null, "ReadProduct", 1, 10 },
                    { 27, "SEED", new DateTime(2025, 10, 11, 7, 50, 46, 475, DateTimeKind.Local).AddTicks(2793), "127.0.0.1", new Guid("decdf193-5275-4b9c-828b-5aed6da72c21"), null, null, "DeleteProduct", 1, 10 }
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
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipperId",
                table: "Orders",
                column: "ShipperId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPermissions_SupplierId_Permission",
                table: "SupplierPermissions",
                columns: new[] { "SupplierId", "Permission" });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Username",
                table: "Suppliers",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
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
                name: "SupplierPermissions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
