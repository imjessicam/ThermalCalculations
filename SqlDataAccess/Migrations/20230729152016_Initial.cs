using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "data");

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalDatas",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: false),
                    Humidity = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalDatas",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: false),
                    Humidity = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Months",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Months_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "data",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthExternalDatas",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthId = table.Column<int>(type: "int", nullable: false),
                    ExternalDataId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthExternalDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthExternalDatas_ExternalDatas_ExternalDataId",
                        column: x => x.ExternalDataId,
                        principalSchema: "data",
                        principalTable: "ExternalDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthExternalDatas_Months_MonthId",
                        column: x => x.MonthId,
                        principalSchema: "data",
                        principalTable: "Months",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthInternalDatas",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthId = table.Column<int>(type: "int", nullable: false),
                    InternalDataId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthInternalDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthInternalDatas_InternalDatas_InternalDataId",
                        column: x => x.InternalDataId,
                        principalSchema: "data",
                        principalTable: "InternalDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthInternalDatas_Months_MonthId",
                        column: x => x.MonthId,
                        principalSchema: "data",
                        principalTable: "Months",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthExternalDatas_ExternalDataId",
                schema: "data",
                table: "MonthExternalDatas",
                column: "ExternalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthExternalDatas_MonthId",
                schema: "data",
                table: "MonthExternalDatas",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthInternalDatas_InternalDataId",
                schema: "data",
                table: "MonthInternalDatas",
                column: "InternalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthInternalDatas_MonthId",
                schema: "data",
                table: "MonthInternalDatas",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Months_CityId",
                schema: "data",
                table: "Months",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthExternalDatas",
                schema: "data");

            migrationBuilder.DropTable(
                name: "MonthInternalDatas",
                schema: "data");

            migrationBuilder.DropTable(
                name: "ExternalDatas",
                schema: "data");

            migrationBuilder.DropTable(
                name: "InternalDatas",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Months",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "data");
        }
    }
}
