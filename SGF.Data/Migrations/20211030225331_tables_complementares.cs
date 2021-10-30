using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGF.Data.Migrations
{
    public partial class tables_complementares : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Remuneracoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<string>(type: "varchar(64)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remuneracoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaldoMeses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaldoMeses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaldoMeses_Meses_MesId",
                        column: x => x.MesId,
                        principalTable: "Meses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RemuneracoesMeses",
                columns: table => new
                {
                    RemuneracaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemuneracoesMeses", x => new { x.MesId, x.RemuneracaoId });
                    table.ForeignKey(
                        name: "FK_RemuneracoesMeses_Meses_MesId",
                        column: x => x.MesId,
                        principalTable: "Meses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RemuneracoesMeses_Remuneracoes_RemuneracaoId",
                        column: x => x.RemuneracaoId,
                        principalTable: "Remuneracoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RemuneracoesMeses_RemuneracaoId",
                table: "RemuneracoesMeses",
                column: "RemuneracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SaldoMeses_MesId",
                table: "SaldoMeses",
                column: "MesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RemuneracoesMeses");

            migrationBuilder.DropTable(
                name: "SaldoMeses");

            migrationBuilder.DropTable(
                name: "Remuneracoes");
        }
    }
}
