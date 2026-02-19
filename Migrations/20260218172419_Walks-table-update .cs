using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalkApp.Migrations
{
    /// <inheritdoc />
    public partial class Walkstableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // WalkImageUrl nullable yapılıyor
            migrationBuilder.AlterColumn<string>(
                name: "WalkImageUrl",
                table: "walks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Yeni geçici GUID sütunu ekle
            migrationBuilder.AddColumn<Guid>(
                name: "RegionId_New",
                table: "walks",
                type: "uniqueidentifier",
                nullable: true);

            // Mevcut RegionNavigationId'den (varsa) yeni sütuna kopyala
            // (Eğer DB'de RegionNavigationId yoksa bu SQL hiçbir şeyi değiştirmez)
            migrationBuilder.Sql(@"
                    IF COL_LENGTH('walks','RegionNavigationId') IS NOT NULL
                    BEGIN
                        UPDATE walks SET RegionId_New = RegionNavigationId WHERE RegionNavigationId IS NOT NULL;
                    END
                ");

            // FK ve index'i kaldır (eski RegionNavigationId'ye bağlı olan)
            migrationBuilder.DropForeignKey(
                name: "FK_walks_regions_RegionNavigationId",
                table: "walks");

            migrationBuilder.DropIndex(
                name: "IX_walks_RegionNavigationId",
                table: "walks");

            // Eski gereksiz sütunları sil (Region, RegionNavigationId ve eski RegionId (int))
            // Önce eski int RegionId varsa onu düşür
            if (migrationBuilder.ActiveProvider != null)
            {
                // migrationBuilder API içinde koşullu kontrol yok; bu yorumlama amaçlıdır.
            }

            migrationBuilder.DropColumn(
                name: "Region",
                table: "walks");

            migrationBuilder.DropColumn(
                name: "RegionNavigationId",
                table: "walks");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "walks");

            // Yeni sütunu gerçek adıyla yeniden adlandır
            migrationBuilder.RenameColumn(
                name: "RegionId_New",
                table: "walks",
                newName: "RegionId");

            // Yeni RegionId'yi not-null yap (varsayılan değer ataması yoksa DB'de NULL kalmamalı)
            migrationBuilder.AlterColumn<Guid>(
                name: "RegionId",
                table: "walks",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            // Index ve FK oluştur
            migrationBuilder.CreateIndex(
                name: "IX_walks_RegionId",
                table: "walks",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_walks_regions_RegionId",
                table: "walks",
                column: "RegionId",
                principalTable: "regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_walks_regions_RegionId",
                table: "walks");

            migrationBuilder.DropIndex(
                name: "IX_walks_RegionId",
                table: "walks");

            migrationBuilder.AlterColumn<string>(
                name: "WalkImageUrl",
                table: "walks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "walks",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Region",
                table: "walks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RegionNavigationId",
                table: "walks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_walks_RegionNavigationId",
                table: "walks",
                column: "RegionNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_walks_regions_RegionNavigationId",
                table: "walks",
                column: "RegionNavigationId",
                principalTable: "regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
