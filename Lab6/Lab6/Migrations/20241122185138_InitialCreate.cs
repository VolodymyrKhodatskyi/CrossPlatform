using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab6.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipPostcode = table.Column<int>(type: "int", nullable: false),
                    StateProvinceCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommercialOrDomestic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherCustomerDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "RefAddressTypes",
                columns: table => new
                {
                    AddressTypeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefAddressTypes", x => x.AddressTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "RefCustomerNumberTypes",
                columns: table => new
                {
                    CustomerNumberTypeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefCustomerNumberTypes", x => x.CustomerNumberTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "RefNumberCalledTypes",
                columns: table => new
                {
                    NumberCalledTypeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberCalledTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefNumberCalledTypes", x => x.NumberCalledTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "RefTariffTypes",
                columns: table => new
                {
                    TariffTypeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefTariffTypes", x => x.TariffTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    CustomerAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    AddressTypeCode = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DateAddressFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAddressTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.CustomerAddressId);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_RefAddressTypes_AddressTypeCode",
                        column: x => x.AddressTypeCode,
                        principalTable: "RefAddressTypes",
                        principalColumn: "AddressTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPhoneNumbers",
                columns: table => new
                {
                    CustomerPhoneNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerNumberTypeCode = table.Column<int>(type: "int", nullable: false),
                    HeldFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeldToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPhoneNumbers", x => x.CustomerPhoneNumber);
                    table.ForeignKey(
                        name: "FK_CustomerPhoneNumbers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerPhoneNumbers_RefCustomerNumberTypes_CustomerNumberTypeCode",
                        column: x => x.CustomerNumberTypeCode,
                        principalTable: "RefCustomerNumberTypes",
                        principalColumn: "CustomerNumberTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    TariffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffTypeCode = table.Column<int>(type: "int", nullable: false),
                    TariffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TariffRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Otherdetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.TariffId);
                    table.ForeignKey(
                        name: "FK_Tariffs_RefTariffTypes_TariffTypeCode",
                        column: x => x.TariffTypeCode,
                        principalTable: "RefTariffTypes",
                        principalColumn: "TariffTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillHeaders",
                columns: table => new
                {
                    BillHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerPhoneNumber = table.Column<int>(type: "int", nullable: false),
                    BillIssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OriginalAmountDue = table.Column<int>(type: "int", nullable: false),
                    AmountOutstanding = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillHeaders", x => x.BillHeaderId);
                    table.ForeignKey(
                        name: "FK_BillHeaders_CustomerPhoneNumbers_CustomerPhoneNumber",
                        column: x => x.CustomerPhoneNumber,
                        principalTable: "CustomerPhoneNumbers",
                        principalColumn: "CustomerPhoneNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPhoneCalls",
                columns: table => new
                {
                    PhoneCallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerPhoneNumber = table.Column<int>(type: "int", nullable: false),
                    NumberCalledTypeCode = table.Column<int>(type: "int", nullable: false),
                    NumberCalled = table.Column<int>(type: "int", nullable: false),
                    CallStartDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CallEndDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPhoneCalls", x => x.PhoneCallId);
                    table.ForeignKey(
                        name: "FK_CustomerPhoneCalls_CustomerPhoneNumbers_CustomerPhoneNumber",
                        column: x => x.CustomerPhoneNumber,
                        principalTable: "CustomerPhoneNumbers",
                        principalColumn: "CustomerPhoneNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerPhoneCalls_RefNumberCalledTypes_NumberCalledTypeCode",
                        column: x => x.NumberCalledTypeCode,
                        principalTable: "RefNumberCalledTypes",
                        principalColumn: "NumberCalledTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillDetailLines",
                columns: table => new
                {
                    BillDetailLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillHeaderId = table.Column<int>(type: "int", nullable: false),
                    PhoneCallId = table.Column<int>(type: "int", nullable: false),
                    TariffId = table.Column<int>(type: "int", nullable: false),
                    CallDuration = table.Column<int>(type: "int", nullable: false),
                    CallCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetailLines", x => x.BillDetailLineId);
                    table.ForeignKey(
                        name: "FK_BillDetailLines_BillHeaders_BillHeaderId",
                        column: x => x.BillHeaderId,
                        principalTable: "BillHeaders",
                        principalColumn: "BillHeaderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillDetailLines_CustomerPhoneCalls_PhoneCallId",
                        column: x => x.PhoneCallId,
                        principalTable: "CustomerPhoneCalls",
                        principalColumn: "PhoneCallId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillDetailLines_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "TariffId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillDetailLines_BillHeaderId",
                table: "BillDetailLines",
                column: "BillHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetailLines_PhoneCallId",
                table: "BillDetailLines",
                column: "PhoneCallId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetailLines_TariffId",
                table: "BillDetailLines",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_BillHeaders_CustomerPhoneNumber",
                table: "BillHeaders",
                column: "CustomerPhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_AddressId",
                table: "CustomerAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_AddressTypeCode",
                table: "CustomerAddresses",
                column: "AddressTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_CustomerId",
                table: "CustomerAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhoneCalls_CustomerPhoneNumber",
                table: "CustomerPhoneCalls",
                column: "CustomerPhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhoneCalls_NumberCalledTypeCode",
                table: "CustomerPhoneCalls",
                column: "NumberCalledTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhoneNumbers_CustomerId",
                table: "CustomerPhoneNumbers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhoneNumbers_CustomerNumberTypeCode",
                table: "CustomerPhoneNumbers",
                column: "CustomerNumberTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_TariffTypeCode",
                table: "Tariffs",
                column: "TariffTypeCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDetailLines");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "BillHeaders");

            migrationBuilder.DropTable(
                name: "CustomerPhoneCalls");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "RefAddressTypes");

            migrationBuilder.DropTable(
                name: "CustomerPhoneNumbers");

            migrationBuilder.DropTable(
                name: "RefNumberCalledTypes");

            migrationBuilder.DropTable(
                name: "RefTariffTypes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "RefCustomerNumberTypes");
        }
    }
}
