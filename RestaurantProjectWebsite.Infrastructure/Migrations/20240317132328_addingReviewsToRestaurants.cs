using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantProjectWebsite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingReviewsToRestaurants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RestaurantId",
                table: "Reviews",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Restaurants_RestaurantId",
                table: "Reviews",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Restaurants_RestaurantId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_RestaurantId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Reviews");
        }
    }
}
