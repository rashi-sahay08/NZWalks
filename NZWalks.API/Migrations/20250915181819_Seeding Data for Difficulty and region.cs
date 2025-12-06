using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultyandregion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3f1ce202-63a0-4b54-9a68-902de8f5c114"), "Easy" },
                    { new Guid("7bc44a10-9aee-477c-82cf-b4143d77167c"), "Hard" },
                    { new Guid("8ba38484-45e2-42fc-af12-d1ff4c6c2c0a"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImgUrl" },
                values: new object[,]
                {
                    { new Guid("2e89a795-5ac1-4336-bba7-ca31ad330065"), "NTL", "Northland", null },
                    { new Guid("4f3d9c70-f896-4ce4-945a-79a9d8078579"), "NTL", "Northland", null },
                    { new Guid("fc7daa23-8422-4ff1-8e76-19b9f5a2f8cf"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3f1ce202-63a0-4b54-9a68-902de8f5c114"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7bc44a10-9aee-477c-82cf-b4143d77167c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8ba38484-45e2-42fc-af12-d1ff4c6c2c0a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2e89a795-5ac1-4336-bba7-ca31ad330065"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4f3d9c70-f896-4ce4-945a-79a9d8078579"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fc7daa23-8422-4ff1-8e76-19b9f5a2f8cf"));
        }
    }
}
