using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.EntityFramework.Migrations
{
    public partial class AddTableDbAuditlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbAuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Userid = table.Column<string>(nullable: true),
                    ServiceName = table.Column<string>(nullable: true),
                    RequestMethod = table.Column<string>(nullable: true),
                    Parameters = table.Column<string>(nullable: true),
                    ReturnValue = table.Column<string>(nullable: true),
                    RequestTime = table.Column<DateTime>(nullable: false),
                    ClientAdress = table.Column<string>(nullable: true),
                    Expection = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbAuditLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbAuditLogs");
        }
    }
}
