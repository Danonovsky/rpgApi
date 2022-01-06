﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rpg.DAO.Migrations
{
    public partial class ItemsInLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_LocationId",
                table: "Items",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Locations_LocationId",
                table: "Items",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Locations_LocationId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_LocationId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Items");
        }
    }
}
