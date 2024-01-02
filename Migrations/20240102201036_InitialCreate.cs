using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HillarysHairCare.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stylists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stylists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsCancelled = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    StylistId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Stylists_StylistId",
                        column: x => x.StylistId,
                        principalTable: "Stylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentDetails_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentDetails_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "John", "Doe" },
                    { 2, "Jane", "Smith" },
                    { 3, "Alice", "Johnson" },
                    { 4, "Bob", "Williams" },
                    { 5, "Emma", "Brown" },
                    { 6, "Michael", "Jones" },
                    { 7, "Olivia", "Garcia" },
                    { 8, "William", "Martinez" },
                    { 9, "Sophia", "Miller" },
                    { 10, "Liam", "Davis" },
                    { 11, "Ava", "Rodriguez" },
                    { 12, "Ethan", "Gomez" },
                    { 13, "Mia", "Hernandez" },
                    { 14, "James", "Perez" },
                    { 15, "Charlotte", "Flores" },
                    { 16, "Alexander", "Adams" },
                    { 17, "Grace", "Cook" },
                    { 18, "Daniel", "Bailey" },
                    { 19, "Luna", "Kelly" },
                    { 20, "Henry", "Wright" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Price", "ServiceName" },
                values: new object[,]
                {
                    { 1, 50.00m, "Women's Haircut" },
                    { 2, 40.00m, "Men's Haircut" },
                    { 3, 45.00m, "Barber Service" },
                    { 4, 80.00m, "Hair Coloring" },
                    { 5, 70.00m, "Highlights" },
                    { 6, 60.00m, "Blowout Styling" },
                    { 7, 120.00m, "Hair Extensions" },
                    { 8, 90.00m, "Perms" },
                    { 9, 100.00m, "Bridal Hair Styling" },
                    { 10, 55.00m, "Deep Conditioning Treatment" },
                    { 11, 25.00m, "Beard Trim" },
                    { 12, 30.00m, "Shave" },
                    { 13, 35.00m, "Facial" },
                    { 14, 20.00m, "Scalp Massage" },
                    { 15, 40.00m, "Waxing" }
                });

            migrationBuilder.InsertData(
                table: "Stylists",
                columns: new[] { "Id", "FirstName", "IsActive", "LastName" },
                values: new object[,]
                {
                    { 1, "Emily", true, "Anderson" },
                    { 2, "David", true, "Brown" },
                    { 3, "Sophia", true, "Clark" },
                    { 4, "James", true, "Davis" },
                    { 5, "Olivia", true, "Garcia" },
                    { 6, "Michael", true, "Harris" },
                    { 7, "Isabella", true, "Jackson" },
                    { 8, "Daniel", true, "Johnson" },
                    { 9, "Ava", true, "Lee" },
                    { 10, "Ethan", true, "Martinez" },
                    { 11, "Emma", true, "Moore" },
                    { 12, "William", true, "Perez" },
                    { 13, "Charlotte", false, "Rivera" },
                    { 14, "Liam", false, "Roberts" },
                    { 15, "Grace", false, "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "CustomerId", "IsCancelled", "StylistId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 22, 8, 0, 0, 0, DateTimeKind.Local), 1, false, 1 },
                    { 2, new DateTime(2024, 1, 23, 9, 0, 0, 0, DateTimeKind.Local), 2, false, 2 },
                    { 3, new DateTime(2024, 1, 24, 10, 0, 0, 0, DateTimeKind.Local), 3, false, 3 },
                    { 4, new DateTime(2024, 1, 25, 11, 0, 0, 0, DateTimeKind.Local), 4, false, 4 },
                    { 5, new DateTime(2024, 1, 26, 12, 0, 0, 0, DateTimeKind.Local), 5, false, 5 },
                    { 6, new DateTime(2024, 1, 27, 13, 0, 0, 0, DateTimeKind.Local), 6, false, 6 },
                    { 7, new DateTime(2024, 1, 28, 14, 0, 0, 0, DateTimeKind.Local), 7, false, 7 },
                    { 8, new DateTime(2024, 1, 29, 15, 0, 0, 0, DateTimeKind.Local), 8, false, 8 },
                    { 9, new DateTime(2024, 1, 30, 16, 0, 0, 0, DateTimeKind.Local), 9, false, 9 },
                    { 10, new DateTime(2024, 1, 31, 17, 0, 0, 0, DateTimeKind.Local), 10, false, 10 },
                    { 11, new DateTime(2024, 2, 1, 18, 0, 0, 0, DateTimeKind.Local), 11, false, 11 },
                    { 12, new DateTime(2024, 2, 2, 19, 0, 0, 0, DateTimeKind.Local), 12, false, 12 },
                    { 13, new DateTime(2024, 2, 3, 20, 0, 0, 0, DateTimeKind.Local), 13, false, 12 },
                    { 14, new DateTime(2024, 2, 4, 21, 0, 0, 0, DateTimeKind.Local), 14, false, 11 },
                    { 15, new DateTime(2024, 2, 5, 22, 0, 0, 0, DateTimeKind.Local), 15, false, 10 },
                    { 16, new DateTime(2024, 2, 6, 23, 0, 0, 0, DateTimeKind.Local), 16, false, 1 },
                    { 17, new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), 17, false, 2 },
                    { 18, new DateTime(2024, 2, 9, 1, 0, 0, 0, DateTimeKind.Local), 18, false, 3 },
                    { 19, new DateTime(2024, 2, 10, 2, 0, 0, 0, DateTimeKind.Local), 19, false, 4 },
                    { 20, new DateTime(2024, 2, 11, 3, 0, 0, 0, DateTimeKind.Local), 20, false, 5 }
                });

            migrationBuilder.InsertData(
                table: "AppointmentDetails",
                columns: new[] { "Id", "AppointmentId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 2, 4 },
                    { 5, 3, 5 },
                    { 6, 3, 6 },
                    { 7, 4, 7 },
                    { 8, 4, 8 },
                    { 9, 5, 9 },
                    { 10, 5, 10 },
                    { 11, 6, 11 },
                    { 12, 6, 12 },
                    { 13, 7, 13 },
                    { 14, 7, 14 },
                    { 15, 8, 15 },
                    { 16, 8, 1 },
                    { 17, 9, 2 },
                    { 18, 9, 3 },
                    { 19, 10, 4 },
                    { 20, 10, 5 },
                    { 21, 11, 6 },
                    { 22, 11, 7 },
                    { 23, 12, 8 },
                    { 24, 12, 9 },
                    { 25, 13, 10 },
                    { 26, 13, 11 },
                    { 27, 14, 12 },
                    { 28, 14, 13 },
                    { 29, 15, 14 },
                    { 30, 15, 15 },
                    { 31, 16, 1 },
                    { 32, 16, 2 },
                    { 33, 17, 3 },
                    { 34, 17, 4 },
                    { 35, 18, 5 },
                    { 36, 18, 6 },
                    { 37, 19, 7 },
                    { 38, 19, 8 },
                    { 39, 20, 9 },
                    { 40, 20, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_AppointmentId",
                table: "AppointmentDetails",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_ServiceId",
                table: "AppointmentDetails",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StylistId",
                table: "Appointments",
                column: "StylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentDetails");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stylists");
        }
    }
}
