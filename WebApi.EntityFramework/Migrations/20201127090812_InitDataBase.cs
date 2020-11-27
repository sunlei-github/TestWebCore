using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.EntityFramework.Migrations
{
    public partial class InitDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: true),
                    EmailAdress = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    User_AccountUser_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbAccountUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 10, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    AccountSatus = table.Column<int>(nullable: false),
                    LastAccountTime = table.Column<DateTime>(nullable: true),
                    AccountFailedCount = table.Column<int>(nullable: false),
                    AccountUser_User_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbAccountUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbAccountUsers_DbUsers_AccountUser_User_Id",
                        column: x => x.AccountUser_User_Id,
                        principalTable: "DbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbAccountUsers_AccountUser_User_Id",
                table: "DbAccountUsers",
                column: "AccountUser_User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DbUsers_Name",
                table: "DbUsers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_DbUsers_User_AccountUser_Id",
                table: "DbUsers",
                column: "User_AccountUser_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DbUsers_DbAccountUsers_User_AccountUser_Id",
                table: "DbUsers",
                column: "User_AccountUser_Id",
                principalTable: "DbAccountUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbAccountUsers_DbUsers_AccountUser_User_Id",
                table: "DbAccountUsers");

            migrationBuilder.DropTable(
                name: "DbUsers");

            migrationBuilder.DropTable(
                name: "DbAccountUsers");
        }
    }
}
