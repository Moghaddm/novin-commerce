#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovinCommerce.Migrations.InitialProducts;

/// <inheritdoc />
public partial class AddProductCategoryCompany : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "Category",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                Name = table.Column<string>("nvarchar(max)", nullable: false),
                Description = table.Column<string>("nvarchar(max)", nullable: false),
                ExtraProperties = table.Column<string>("nvarchar(max)", nullable: true),
                ConcurrencyStamp = table.Column<string>("nvarchar(40)", maxLength: 40, nullable: true),
                CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                CreatorId = table.Column<Guid>("uniqueidentifier", nullable: true),
                LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                LastModifierId = table.Column<Guid>("uniqueidentifier", nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_Category", x => x.Id); });

        migrationBuilder.CreateTable(
            "Companies",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                Title = table.Column<string>("nvarchar(max)", nullable: false),
                Description = table.Column<string>("nvarchar(max)", nullable: false),
                ExtraProperties = table.Column<string>("nvarchar(max)", nullable: true),
                ConcurrencyStamp = table.Column<string>("nvarchar(40)", maxLength: 40, nullable: true),
                CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                CreatorId = table.Column<Guid>("uniqueidentifier", nullable: true),
                LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                LastModifierId = table.Column<Guid>("uniqueidentifier", nullable: true),
                IsDeleted = table.Column<bool>("bit", nullable: false, defaultValue: false),
                DeleterId = table.Column<Guid>("uniqueidentifier", nullable: true),
                DeletionTime = table.Column<DateTime>("datetime2", nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_Companies", x => x.Id); });

        migrationBuilder.CreateTable(
            "Products",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                Name = table.Column<string>("nvarchar(max)", nullable: false),
                Description = table.Column<string>("nvarchar(max)", nullable: false),
                Price = table.Column<long>("bigint", nullable: false),
                StockState = table.Column<int>("int", nullable: false),
                Quantity = table.Column<int>("int", nullable: false),
                CategoryId = table.Column<Guid>("uniqueidentifier", nullable: false),
                CompanyId = table.Column<Guid>("uniqueidentifier", nullable: false),
                ExtraProperties = table.Column<string>("nvarchar(max)", nullable: true),
                ConcurrencyStamp = table.Column<string>("nvarchar(40)", maxLength: 40, nullable: true),
                CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                CreatorId = table.Column<Guid>("uniqueidentifier", nullable: true),
                LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                LastModifierId = table.Column<Guid>("uniqueidentifier", nullable: true),
                IsDeleted = table.Column<bool>("bit", nullable: false, defaultValue: false),
                DeleterId = table.Column<Guid>("uniqueidentifier", nullable: true),
                DeletionTime = table.Column<DateTime>("datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
                table.ForeignKey(
                    "FK_Products_Category_CategoryId",
                    x => x.CategoryId,
                    "Category",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_Products_Companies_CompanyId",
                    x => x.CompanyId,
                    "Companies",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_Products_CategoryId",
            "Products",
            "CategoryId");

        migrationBuilder.CreateIndex(
            "IX_Products_CompanyId",
            "Products",
            "CompanyId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "Products");

        migrationBuilder.DropTable(
            "Category");

        migrationBuilder.DropTable(
            "Companies");
    }
}