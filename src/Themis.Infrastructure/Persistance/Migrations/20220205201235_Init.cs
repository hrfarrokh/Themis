using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Themis.Infrastructure.Persistance.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ord");

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "ord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackingCode = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    Type = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    State = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    StateCategory = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    Customer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Customer_FullName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Customer_PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    City_Id = table.Column<int>(type: "int", nullable: true),
                    City_Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    City_District = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Item_InventoryItem_Id = table.Column<long>(type: "bigint", nullable: true),
                    Item_InventoryItem_FullName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Item_InventoryItem_Car_Id = table.Column<int>(type: "int", nullable: true),
                    Item_InventoryItem_Car_Type = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Item_InventoryItem_Car_Generation = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Item_InventoryItem_Car_Brand = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Item_InventoryItem_Car_Model = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Item_InventoryItem_Car_Color = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Item_InventoryItem_Car_Year = table.Column<int>(type: "int", nullable: true),
                    Item_InventoryItem_City_Id = table.Column<int>(type: "int", nullable: true),
                    Item_InventoryItem_City_Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Item_InventoryItem_City_District = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Item_InventoryItem_Mileage = table.Column<int>(type: "int", nullable: true),
                    Item_InventoryItem_Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Item_Package_Id = table.Column<int>(type: "int", nullable: true),
                    Item_Package_Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Item_Package_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Item_Appointment_From = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Item_Appointment_To = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Item_TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Creation_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Creation_Username = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Creation_TimeStamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Modification_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modification_Username = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Modification_TimeStamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderMetadata",
                schema: "ord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Channel = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Campaign = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    PrevUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    OrderPageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    PrevDomainUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Referrer = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    LandingPageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMetadata", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order",
                schema: "ord");

            migrationBuilder.DropTable(
                name: "OrderMetadata",
                schema: "ord");
        }
    }
}
