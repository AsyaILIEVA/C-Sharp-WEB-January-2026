using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxParticipants = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registrations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Conference" },
                    { 2, "Workshop" },
                    { 3, "Webinar" }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "Id", "Email", "EventId", "ParticipantName" },
                values: new object[] { 3, "carol@yahoo.com", 3, "Carla Merini" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "Description", "EndDate", "MaxParticipants", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "A conference on emerging technologies.", new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Innovations 2024" },
                    { 2, 2, "Deep dive in C# features.", new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Advanced Workshop" }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "Id", "Email", "EventId", "ParticipantName" },
                values: new object[,]
                {
                    { 1, "siyul@abv.bg", 1, "Peter Kalan" },
                    { 2, "maxin@gmail.com", 2, "Max Inman" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EventId",
                table: "Registrations",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
