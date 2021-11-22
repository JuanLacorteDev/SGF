using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGF.Data.Migrations
{
    public partial class alteracaonomeclaturas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DespesasMeses");

            migrationBuilder.DropTable(
                name: "RemuneracoesMeses");

            migrationBuilder.DropTable(
                name: "SaldoMeses");

            migrationBuilder.DropTable(
                name: "Meses");

            migrationBuilder.DropColumn(
                name: "DiaVencimento",
                table: "Despesas");

            migrationBuilder.AddColumn<DateTime>(
                name: "Vencimento",
                table: "Despesas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vencimento",
                table: "Despesas");

            migrationBuilder.AddColumn<int>(
                name: "DiaVencimento",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Meses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Identificador_Numerico = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DespesasMeses",
                columns: table => new
                {
                    DespesaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesasMeses", x => new { x.DespesaId, x.MesId });
                    table.ForeignKey(
                        name: "FK_DespesasMeses_Despesas_DespesaId",
                        column: x => x.DespesaId,
                        principalTable: "Despesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DespesasMeses_Meses_MesId",
                        column: x => x.MesId,
                        principalTable: "Meses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RemuneracoesMeses",
                columns: table => new
                {
                    MesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemuneracaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_DespesasMeses_MesId",
                table: "DespesasMeses",
                column: "MesId");

            migrationBuilder.CreateIndex(
                name: "IX_RemuneracoesMeses_RemuneracaoId",
                table: "RemuneracoesMeses",
                column: "RemuneracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SaldoMeses_MesId",
                table: "SaldoMeses",
                column: "MesId");
        }
    }
}
