using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace crudBiblioteca.Data.Migrations
{
    public partial class addEntidadeAcervo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcervoId",
                table: "Livros",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Acervos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acervos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_AcervoId",
                table: "Livros",
                column: "AcervoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Acervos_AcervoId",
                table: "Livros",
                column: "AcervoId",
                principalTable: "Acervos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Acervos_AcervoId",
                table: "Livros");

            migrationBuilder.DropTable(
                name: "Acervos");

            migrationBuilder.DropIndex(
                name: "IX_Livros_AcervoId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "AcervoId",
                table: "Livros");
        }
    }
}
