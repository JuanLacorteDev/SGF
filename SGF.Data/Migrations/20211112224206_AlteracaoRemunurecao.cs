using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGF.Data.Migrations
{
    public partial class AlteracaoRemunurecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MesInicioId",
                table: "Remuneracoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "SalarioMensal",
                table: "Remuneracoes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MesInicioId",
                table: "Remuneracoes");

            migrationBuilder.DropColumn(
                name: "SalarioMensal",
                table: "Remuneracoes");
        }
    }
}
