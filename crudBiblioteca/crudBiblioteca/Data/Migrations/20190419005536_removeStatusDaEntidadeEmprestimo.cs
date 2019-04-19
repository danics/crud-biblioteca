using Microsoft.EntityFrameworkCore.Migrations;

namespace crudBiblioteca.Data.Migrations
{
    public partial class removeStatusDaEntidadeEmprestimo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Emprestimos");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Livros",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Livros");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Emprestimos",
                nullable: false,
                defaultValue: 0);
        }
    }
}
