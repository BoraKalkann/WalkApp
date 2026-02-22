using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WalkApp.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdatafordiffandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("54945523-37de-46c2-94b7-6a016bc7a6b5"), "Easy" },
                    { new Guid("da73f78b-eea2-434d-a0db-b38543e7c371"), "Hard" },
                    { new Guid("e0c4b1de-1c76-4885-9397-33d5711f8dd8"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("a0c4b1de-1c76-4885-9397-33d5711f8dd8"), "KARADENIZ", "Karadeniz", null },
                    { new Guid("b0c4b1de-1c76-4885-9397-33d5711f8dd8"), "AKDENIZ", "Akdeniz", null },
                    { new Guid("c0c4b1de-1c76-4885-9397-33d5711f8dd8"), "MARMARA", "Marmara", null },
                    { new Guid("d1c4b1de-1c76-4885-9397-33d5711f8dd8"), "IC_ANADOLU", "Ic Anadolu", null },
                    { new Guid("e0c4b1de-1c76-4885-9397-33d5711f8dd8"), "EGE", "Ege", null },
                    { new Guid("f0c4b1de-1c76-4885-9397-33d5711f8dd8"), "DOGU_ANADOLU", "Dogu Anadolu", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("54945523-37de-46c2-94b7-6a016bc7a6b5"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("da73f78b-eea2-434d-a0db-b38543e7c371"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e0c4b1de-1c76-4885-9397-33d5711f8dd8"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("a0c4b1de-1c76-4885-9397-33d5711f8dd8"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("b0c4b1de-1c76-4885-9397-33d5711f8dd8"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("c0c4b1de-1c76-4885-9397-33d5711f8dd8"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("d1c4b1de-1c76-4885-9397-33d5711f8dd8"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("e0c4b1de-1c76-4885-9397-33d5711f8dd8"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("f0c4b1de-1c76-4885-9397-33d5711f8dd8"));
        }
    }
}
