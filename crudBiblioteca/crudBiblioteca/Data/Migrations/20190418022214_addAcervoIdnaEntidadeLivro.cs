using Microsoft.EntityFrameworkCore.Migrations;

namespace crudBiblioteca.Data.Migrations
{
    public partial class addAcervoIdnaEntidadeLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Acervos_AcervoId",
                table: "Livros");

            migrationBuilder.AlterColumn<int>(
                name: "AcervoId",
                table: "Livros",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Acervos_AcervoId",
                table: "Livros",
                column: "AcervoId",
                principalTable: "Acervos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Acervos_AcervoId",
                table: "Livros");

            migrationBuilder.AlterColumn<int>(
                name: "AcervoId",
                table: "Livros",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Acervos_AcervoId",
                table: "Livros",
                column: "AcervoId",
                principalTable: "Acervos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
