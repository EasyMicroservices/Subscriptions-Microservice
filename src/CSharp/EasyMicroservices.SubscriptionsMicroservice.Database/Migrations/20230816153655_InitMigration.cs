using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMicroservices.SubscriptionsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<long>(type: "bigint", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionUser_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionParameter",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<long>(type: "bigint", nullable: true),
                    SubscriptionUserId = table.Column<long>(type: "bigint", nullable: true),
                    SubscriptionUserEntityId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionParameter_SubscriptionUser_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "SubscriptionUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubscriptionParameter_SubscriptionUser_SubscriptionUserEntityId",
                        column: x => x.SubscriptionUserEntityId,
                        principalTable: "SubscriptionUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubscriptionParameter_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionParameterValue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionParameterId = table.Column<long>(type: "bigint", nullable: true),
                    SubscriptionParameterValueEntityId = table.Column<long>(type: "bigint", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionParameterValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionParameterValue_SubscriptionParameterValue_SubscriptionParameterValueEntityId",
                        column: x => x.SubscriptionParameterValueEntityId,
                        principalTable: "SubscriptionParameterValue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubscriptionParameterValue_SubscriptionParameter_SubscriptionParameterId",
                        column: x => x.SubscriptionParameterId,
                        principalTable: "SubscriptionParameter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionParameter_CreationDateTime",
                table: "SubscriptionParameter",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionParameter_DeletedDateTime",
                table: "SubscriptionParameter",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionParameter_IsDeleted",
                table: "SubscriptionParameter",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionParameter_ModificationDateTime",
                table: "SubscriptionParameter",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionParameter_SubscriptionId",
                table: "SubscriptionParameter",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionParameter_SubscriptionUserEntityId",
                table: "SubscriptionParameter",
                column: "SubscriptionUserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionParameter_UniqueIdentity",
                table: "SubscriptionParameter",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionParameterValue_CreationDateTime",
                table: "SubscriptionParameterValue",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionParameterValue_DeletedDateTime",
                table: "SubscriptionParameterValue",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionParameterValue_IsDeleted",
                table: "SubscriptionParameterValue",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionParameterValue_ModificationDateTime",
                table: "SubscriptionParameterValue",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionParameterValue_SubscriptionParameterId",
                table: "SubscriptionParameterValue",
                column: "SubscriptionParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionParameterValue_SubscriptionParameterValueEntityId",
                table: "SubscriptionParameterValue",
                column: "SubscriptionParameterValueEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionParameterValue_UniqueIdentity",
                table: "SubscriptionParameterValue",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CreationDateTime",
                table: "Subscriptions",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_DeletedDateTime",
                table: "Subscriptions",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_IsDeleted",
                table: "Subscriptions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ModificationDateTime",
                table: "Subscriptions",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UniqueIdentity",
                table: "Subscriptions",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionUser_CreationDateTime",
                table: "SubscriptionUser",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionUser_DeletedDateTime",
                table: "SubscriptionUser",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionUser_IsDeleted",
                table: "SubscriptionUser",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionUser_ModificationDateTime",
                table: "SubscriptionUser",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionUser_SubscriptionId",
                table: "SubscriptionUser",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionUser_UniqueIdentity",
                table: "SubscriptionUser",
                column: "UniqueIdentity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionParameterValue");

            migrationBuilder.DropTable(
                name: "SubscriptionParameter");

            migrationBuilder.DropTable(
                name: "SubscriptionUser");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
