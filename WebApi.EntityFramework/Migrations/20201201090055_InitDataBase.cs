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
                name: "DbAccountUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 10, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    AccountSatus = table.Column<int>(nullable: false),
                    LastAccountTime = table.Column<DateTime>(nullable: true),
                    AccountFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbAccountUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    First_Name = table.Column<string>(maxLength: 10, nullable: true),
                    Last_Name = table.Column<string>(maxLength: 10, nullable: true),
                    FullName = table.Column<string>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_DbUsers_DbAccountUsers_User_AccountUser_Id",
                        column: x => x.User_AccountUser_Id,
                        principalTable: "DbAccountUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbHotImageResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PayCoin = table.Column<bool>(nullable: false),
                    ClickLike = table.Column<bool>(nullable: false),
                    Collect = table.Column<bool>(nullable: false),
                    TrigeminyUserId = table.Column<int>(nullable: true),
                    CreatorUserId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<int>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbHotImageResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbHotImageResources_DbUsers_TrigeminyUserId",
                        column: x => x.TrigeminyUserId,
                        principalTable: "DbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbImageResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResourceSize = table.Column<long>(nullable: false),
                    ResourceLocation = table.Column<string>(nullable: true),
                    CanDownloaded = table.Column<bool>(nullable: false),
                    IsShared = table.Column<bool>(nullable: false),
                    DownloadCount = table.Column<long>(nullable: false),
                    VisitCount = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ImageGroup = table.Column<int>(nullable: false),
                    CreatorName = table.Column<string>(nullable: true),
                    LastModifierUserName = table.Column<string>(nullable: true),
                    CreatorUserId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<int>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DbUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbImageResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbImageResources_DbUsers_DbUserId",
                        column: x => x.DbUserId,
                        principalTable: "DbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbMusicResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResourceSize = table.Column<long>(nullable: false),
                    ResourceLocation = table.Column<string>(nullable: true),
                    CanDownloaded = table.Column<bool>(nullable: false),
                    IsShared = table.Column<bool>(nullable: false),
                    DownloadCount = table.Column<long>(nullable: false),
                    VisitCount = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    DbUserId = table.Column<int>(nullable: false),
                    MusicGroup = table.Column<int>(nullable: false),
                    CreatorName = table.Column<string>(nullable: true),
                    LastModifierUserName = table.Column<string>(nullable: true),
                    CreatorUserId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<int>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbMusicResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbMusicResources_DbUsers_DbUserId",
                        column: x => x.DbUserId,
                        principalTable: "DbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbVedioResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResourceSize = table.Column<long>(nullable: false),
                    ResourceLocation = table.Column<string>(nullable: true),
                    CanDownloaded = table.Column<bool>(nullable: false),
                    IsShared = table.Column<bool>(nullable: false),
                    DownloadCount = table.Column<long>(nullable: false),
                    VisitCount = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    DbUserId = table.Column<int>(nullable: false),
                    VedioGroup = table.Column<int>(nullable: false),
                    CreatorName = table.Column<string>(nullable: true),
                    LastModifierUserName = table.Column<string>(nullable: true),
                    CreatorUserId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<int>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbVedioResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbVedioResources_DbUsers_DbUserId",
                        column: x => x.DbUserId,
                        principalTable: "DbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbHotImageReSourceUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DbHotImageReSourceId = table.Column<int>(nullable: false),
                    DbImageResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbHotImageReSourceUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbHotImageReSourceUsers_DbHotImageResources_DbHotImageReSour~",
                        column: x => x.DbHotImageReSourceId,
                        principalTable: "DbHotImageResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbHotImageReSourceUsers_DbImageResources_DbImageResourceId",
                        column: x => x.DbImageResourceId,
                        principalTable: "DbImageResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbHotMusicResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImageResourceId = table.Column<int>(nullable: false),
                    DbImageResourceId = table.Column<int>(nullable: true),
                    DbUserId = table.Column<int>(nullable: false),
                    PayCoin = table.Column<bool>(nullable: false),
                    ClickLike = table.Column<bool>(nullable: false),
                    Collect = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<int>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbHotMusicResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbHotMusicResources_DbImageResources_DbImageResourceId",
                        column: x => x.DbImageResourceId,
                        principalTable: "DbImageResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbHotMusicResources_DbUsers_DbUserId",
                        column: x => x.DbUserId,
                        principalTable: "DbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbHotVedioResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImageResourceId = table.Column<int>(nullable: false),
                    DbImageResourceId = table.Column<int>(nullable: true),
                    DbUserIdUserId = table.Column<int>(nullable: false),
                    PayCoin = table.Column<bool>(nullable: false),
                    ClickLike = table.Column<bool>(nullable: false),
                    Collect = table.Column<bool>(nullable: false),
                    TrigeminyUserId = table.Column<int>(nullable: true),
                    CreatorUserId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<int>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbHotVedioResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbHotVedioResources_DbImageResources_DbImageResourceId",
                        column: x => x.DbImageResourceId,
                        principalTable: "DbImageResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbHotVedioResources_DbUsers_TrigeminyUserId",
                        column: x => x.TrigeminyUserId,
                        principalTable: "DbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbHotMusicResourceUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DbHotMusicReSourceId = table.Column<int>(nullable: false),
                    DbMusicResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbHotMusicResourceUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbHotMusicResourceUsers_DbHotMusicResources_DbHotMusicReSour~",
                        column: x => x.DbHotMusicReSourceId,
                        principalTable: "DbHotMusicResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbHotMusicResourceUsers_DbMusicResources_DbMusicResourceId",
                        column: x => x.DbMusicResourceId,
                        principalTable: "DbMusicResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotVedioResourceUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DbHotVedioReSourceId = table.Column<int>(nullable: false),
                    DbVedioResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotVedioResourceUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotVedioResourceUsers_DbHotVedioResources_DbHotVedioReSource~",
                        column: x => x.DbHotVedioReSourceId,
                        principalTable: "DbHotVedioResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotVedioResourceUsers_DbVedioResources_DbVedioResourceId",
                        column: x => x.DbVedioResourceId,
                        principalTable: "DbVedioResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbHotImageResources_TrigeminyUserId",
                table: "DbHotImageResources",
                column: "TrigeminyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbHotImageReSourceUsers_DbHotImageReSourceId",
                table: "DbHotImageReSourceUsers",
                column: "DbHotImageReSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbHotImageReSourceUsers_DbImageResourceId",
                table: "DbHotImageReSourceUsers",
                column: "DbImageResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbHotMusicResources_DbImageResourceId",
                table: "DbHotMusicResources",
                column: "DbImageResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbHotMusicResources_DbUserId",
                table: "DbHotMusicResources",
                column: "DbUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbHotMusicResourceUsers_DbHotMusicReSourceId",
                table: "DbHotMusicResourceUsers",
                column: "DbHotMusicReSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbHotMusicResourceUsers_DbMusicResourceId",
                table: "DbHotMusicResourceUsers",
                column: "DbMusicResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbHotVedioResources_DbImageResourceId",
                table: "DbHotVedioResources",
                column: "DbImageResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbHotVedioResources_TrigeminyUserId",
                table: "DbHotVedioResources",
                column: "TrigeminyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbImageResources_DbUserId",
                table: "DbImageResources",
                column: "DbUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbImageResources_Title",
                table: "DbImageResources",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_DbMusicResources_DbUserId",
                table: "DbMusicResources",
                column: "DbUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbMusicResources_Title",
                table: "DbMusicResources",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_DbUsers_FullName",
                table: "DbUsers",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_DbUsers_User_AccountUser_Id",
                table: "DbUsers",
                column: "User_AccountUser_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DbVedioResources_DbUserId",
                table: "DbVedioResources",
                column: "DbUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbVedioResources_Title",
                table: "DbVedioResources",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_HotVedioResourceUsers_DbHotVedioReSourceId",
                table: "HotVedioResourceUsers",
                column: "DbHotVedioReSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_HotVedioResourceUsers_DbVedioResourceId",
                table: "HotVedioResourceUsers",
                column: "DbVedioResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbHotImageReSourceUsers");

            migrationBuilder.DropTable(
                name: "DbHotMusicResourceUsers");

            migrationBuilder.DropTable(
                name: "HotVedioResourceUsers");

            migrationBuilder.DropTable(
                name: "DbHotImageResources");

            migrationBuilder.DropTable(
                name: "DbHotMusicResources");

            migrationBuilder.DropTable(
                name: "DbMusicResources");

            migrationBuilder.DropTable(
                name: "DbHotVedioResources");

            migrationBuilder.DropTable(
                name: "DbVedioResources");

            migrationBuilder.DropTable(
                name: "DbImageResources");

            migrationBuilder.DropTable(
                name: "DbUsers");

            migrationBuilder.DropTable(
                name: "DbAccountUsers");
        }
    }
}
