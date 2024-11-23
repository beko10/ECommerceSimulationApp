using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceSimulationApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ShipAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShipCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShipCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SupplierID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedDate", "Description", "IsActive" },
                values: new object[,]
                {
                    { "cc7708f9-3b6f-454e-9f5f-5c721de8ef51", "Books", new DateTime(2024, 11, 23, 17, 11, 37, 149, DateTimeKind.Local).AddTicks(1841), "Books and Stationery", true },
                    { "ed36652f-b238-4cc9-a646-e758ccf8e19f", "Electronics", new DateTime(2024, 11, 23, 17, 11, 37, 149, DateTimeKind.Local).AddTicks(1828), "Electronic Items", true }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "City", "Country", "CreatedDate", "CustomerName", "IsActive", "Phone" },
                values: new object[,]
                {
                    { "20bf8e13-9c70-4c34-968b-f6209174d83d", "New York", "USA", new DateTime(2024, 11, 23, 17, 11, 37, 149, DateTimeKind.Local).AddTicks(3632), "John Doe", true, "1234567890" },
                    { "5a9cf13b-b9a8-4758-b2a8-cc6b871d1009", "London", "UK", new DateTime(2024, 11, 23, 17, 11, 37, 149, DateTimeKind.Local).AddTicks(3639), "Jane Smith", true, "9876543210" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "City", "Country", "CreatedDate", "IsActive", "Name", "Phone", "SurName" },
                values: new object[,]
                {
                    { "0ad68950-0cfe-4760-9fb0-23dd47a26842", "Seattle", "USA", new DateTime(2024, 11, 23, 17, 11, 37, 149, DateTimeKind.Local).AddTicks(5332), true, "Alice", "1122334455", "Johnson" },
                    { "e918542d-0292-434b-93f9-af4607c4b181", "Toronto", "Canada", new DateTime(2024, 11, 23, 17, 11, 37, 149, DateTimeKind.Local).AddTicks(5349), true, "Bob", "2233445566", "Williams" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "City", "CompanyName", "ContactTitle", "Country", "CreatedDate", "IsActive", "Phone" },
                values: new object[,]
                {
                    { "a5d4e59c-1899-4941-8657-bc1fb30f518b", "San Francisco", "TechSupplier Inc.", "Manager", "USA", new DateTime(2024, 11, 23, 17, 11, 37, 150, DateTimeKind.Local).AddTicks(6788), true, "3344556677" },
                    { "ce604596-7139-4412-b2d2-35bd5b1a161d", "Milan", "Fashion World", "Owner", "Italy", new DateTime(2024, 11, 23, 17, 11, 37, 150, DateTimeKind.Local).AddTicks(6801), true, "4455667788" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "CustomerID", "EmployeeID", "IsActive", "OrderDate", "ShipAddress", "ShipCity", "ShipCountry" },
                values: new object[,]
                {
                    { "3cc0f5a0-2bfb-45f1-a76a-0be1af85f140", new DateTime(2024, 11, 23, 17, 11, 37, 149, DateTimeKind.Local).AddTicks(7663), "5a9cf13b-b9a8-4758-b2a8-cc6b871d1009", "e918542d-0292-434b-93f9-af4607c4b181", true, new DateOnly(2024, 2, 10), "456 Market St", "London", "UK" },
                    { "5ebc3c5b-faa3-4c3f-a440-5cf050a5c294", new DateTime(2024, 11, 23, 17, 11, 37, 149, DateTimeKind.Local).AddTicks(7651), "20bf8e13-9c70-4c34-968b-f6209174d83d", "0ad68950-0cfe-4760-9fb0-23dd47a26842", true, new DateOnly(2024, 1, 15), "123 Main St", "New York", "USA" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "CreatedDate", "Discontinued", "IsActive", "ProductName", "SupplierID", "UnitPrice", "UnitsInStock" },
                values: new object[,]
                {
                    { "731e3c6a-db44-4674-9e24-0c81421b274a", "cc7708f9-3b6f-454e-9f5f-5c721de8ef51", new DateTime(2024, 11, 23, 17, 11, 37, 150, DateTimeKind.Local).AddTicks(5932), false, true, "T-Shirt", "ce604596-7139-4412-b2d2-35bd5b1a161d", 20.0, 200 },
                    { "ec7f37f5-fa71-4c01-a69b-711f266e24fe", "ed36652f-b238-4cc9-a646-e758ccf8e19f", new DateTime(2024, 11, 23, 17, 11, 37, 150, DateTimeKind.Local).AddTicks(5925), false, true, "Laptop", "a5d4e59c-1899-4941-8657-bc1fb30f518b", 1200.0, 50 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderID", "ProductID", "CreatedDate", "IsActive", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { "3cc0f5a0-2bfb-45f1-a76a-0be1af85f140", "731e3c6a-db44-4674-9e24-0c81421b274a", new DateTime(2024, 11, 23, 17, 11, 37, 150, DateTimeKind.Local).AddTicks(3401), true, 3, 20.0 },
                    { "5ebc3c5b-faa3-4c3f-a440-5cf050a5c294", "ec7f37f5-fa71-4c01-a69b-711f266e24fe", new DateTime(2024, 11, 23, 17, 11, 37, 150, DateTimeKind.Local).AddTicks(3394), true, 1, 1200.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeID",
                table: "Orders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierID",
                table: "Products",
                column: "SupplierID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
