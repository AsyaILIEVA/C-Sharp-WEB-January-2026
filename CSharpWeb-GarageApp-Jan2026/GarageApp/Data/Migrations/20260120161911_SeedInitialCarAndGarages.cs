using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialCarAndGarages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Garages",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("2c2fca1e-ad73-46a1-b4ee-2809f422733f"), "Varna Industrial Zone", "Mountain View Garage" },
                    { new Guid("7147ac98-3245-4031-9674-2fa1fe564408"), "Plovdiv West", "Westside Performance Garage" },
                    { new Guid("b0fcfba8-dedc-4654-9f8d-636b9e19a8d0"), "Sofia Center", "Downtown Auto Garage" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarChassisType", "GarageId", "IsAvailable", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { 1, 0, new Guid("b0fcfba8-dedc-4654-9f8d-636b9e19a8d0"), true, "BMW", "M3", 2021 },
                    { 2, 9, new Guid("7147ac98-3245-4031-9674-2fa1fe564408"), false, "Audi", "Q7", 2019 },
                    { 3, 8, new Guid("2c2fca1e-ad73-46a1-b4ee-2809f422733f"), true, "Mazda", "M6", 2022 },
                    { 4, 2, new Guid("b0fcfba8-dedc-4654-9f8d-636b9e19a8d0"), true, "Toyota", "Corolla", 2020 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: new Guid("2c2fca1e-ad73-46a1-b4ee-2809f422733f"));

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: new Guid("7147ac98-3245-4031-9674-2fa1fe564408"));

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: new Guid("b0fcfba8-dedc-4654-9f8d-636b9e19a8d0"));
        }
    }
}
