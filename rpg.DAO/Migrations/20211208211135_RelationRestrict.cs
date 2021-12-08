using Microsoft.EntityFrameworkCore.Migrations;

namespace rpg.DAO.Migrations
{
    public partial class RelationRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignPlayers_Campaigns_CampaignId",
                table: "CampaignPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignPlayers_Characters_CharacterId",
                table: "CampaignPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignPlayers_Users_UserId",
                table: "CampaignPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Users_UserId",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Characteristics_Characters_CharacterId",
                table: "Characteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Campaigns_CampaignId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Characters_CharacterId",
                table: "Skills");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignPlayers_Campaigns_CampaignId",
                table: "CampaignPlayers",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignPlayers_Characters_CharacterId",
                table: "CampaignPlayers",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignPlayers_Users_UserId",
                table: "CampaignPlayers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Users_UserId",
                table: "Campaigns",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristics_Characters_CharacterId",
                table: "Characteristics",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Campaigns_CampaignId",
                table: "Characters",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Characters_CharacterId",
                table: "Skills",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignPlayers_Campaigns_CampaignId",
                table: "CampaignPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignPlayers_Characters_CharacterId",
                table: "CampaignPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignPlayers_Users_UserId",
                table: "CampaignPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Users_UserId",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Characteristics_Characters_CharacterId",
                table: "Characteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Campaigns_CampaignId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Characters_CharacterId",
                table: "Skills");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignPlayers_Campaigns_CampaignId",
                table: "CampaignPlayers",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignPlayers_Characters_CharacterId",
                table: "CampaignPlayers",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignPlayers_Users_UserId",
                table: "CampaignPlayers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Users_UserId",
                table: "Campaigns",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristics_Characters_CharacterId",
                table: "Characteristics",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Campaigns_CampaignId",
                table: "Characters",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Characters_CharacterId",
                table: "Skills",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
