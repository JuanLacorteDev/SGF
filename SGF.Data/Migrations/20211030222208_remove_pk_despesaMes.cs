using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGF.Data.Migrations
{
    public partial class remove_pk_despesaMes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DespesasMeses",
                table: "DespesasMeses");

            migrationBuilder.DropIndex(
                name: "IX_DespesasMeses_DespesaId",
                table: "DespesasMeses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DespesasMeses");

            migrationBuilder.AlterColumn<string>(
                name: "Valor",
                table: "Despesas",
                type: "varchar(64)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Despesas",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Despesas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DespesasMeses",
                table: "DespesasMeses",
                columns: new[] { "DespesaId", "MesId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DespesasMeses",
                table: "DespesasMeses");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "DespesasMeses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "Despesas",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(64)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Despesas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Despesas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DespesasMeses",
                table: "DespesasMeses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DespesasMeses_DespesaId",
                table: "DespesasMeses",
                column: "DespesaId");
        }
    }
}
