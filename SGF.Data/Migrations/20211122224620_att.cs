using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGF.Data.Migrations
{
    public partial class att : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MesId",
                table: "Remuneracoes");

            migrationBuilder.DropColumn(
                name: "MesInicioId",
                table: "Remuneracoes");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Lancamento",
                table: "Remuneracoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_Lancamento",
                table: "Remuneracoes");

            migrationBuilder.AddColumn<Guid>(
                name: "MesId",
                table: "Remuneracoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MesInicioId",
                table: "Remuneracoes",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
