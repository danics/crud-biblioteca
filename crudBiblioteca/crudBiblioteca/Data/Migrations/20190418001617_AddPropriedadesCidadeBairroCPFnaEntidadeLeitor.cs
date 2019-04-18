using Microsoft.EntityFrameworkCore.Migrations;

namespace crudBiblioteca.Data.Migrations
{
    public partial class AddPropriedadesCidadeBairroCPFnaEntidadeLeitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Leitores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Leitores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Leitores",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Acervos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Acervo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Acervos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Leitores");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Leitores");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Leitores");
        }
    }
}
