using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using TaxiFares.API.Infrastructure.Extensions;

namespace TaxiFares.API.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        private readonly Assembly executingAssembly;

        public InitialCreate() => executingAssembly = 
            Assembly.GetExecutingAssembly();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChangeDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE()"),
                    CityId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    I = table.Column<double>(type: "REAL", nullable: false),
                    II = table.Column<double>(type: "REAL", nullable: false),
                    III = table.Column<double>(type: "REAL", nullable: false),
                    IV = table.Column<double>(type: "REAL", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fares_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Id",
                table: "Cities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CityId",
                table: "Companies",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Fares_CompanyId",
                table: "Fares",
                column: "CompanyId",
                unique: true);

            migrationBuilder.Sql(GetCreateTriggerOnFaresUpdateScript());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fares");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Cities");
        }

        private string GetCreateTriggerOnFaresUpdateScript() => 
            executingAssembly.GetManifestResourceStream(
                SqlFileNames.CreateTriggerOnFaresUpdate)
            .ReadToEndAsync().Result;
    }
}
