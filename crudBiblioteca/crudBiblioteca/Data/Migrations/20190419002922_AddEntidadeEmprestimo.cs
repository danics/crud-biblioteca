using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace crudBiblioteca.Data.Migrations
{
    public partial class AddEntidadeEmprestimo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmprestimoId",
                table: "Livros",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmprestimoId",
                table: "Leitores",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataInicial = table.Column<DateTime>(nullable: false),
                    DataFinal = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    LivroId = table.Column<int>(nullable: false),
                    LeitorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Leitores_LeitorId",
                        column: x => x.LeitorId,
                        principalTable: "Leitores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_EmprestimoId",
                table: "Livros",
                column: "EmprestimoId");

            migrationBuilder.CreateIndex(
                name: "IX_Leitores_EmprestimoId",
                table: "Leitores",
                column: "EmprestimoId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_LeitorId",
                table: "Emprestimos",
                column: "LeitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_LivroId",
                table: "Emprestimos",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leitores_Emprestimos_EmprestimoId",
                table: "Leitores",
                column: "EmprestimoId",
                principalTable: "Emprestimos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Emprestimos_EmprestimoId",
                table: "Livros",
                column: "EmprestimoId",
                principalTable: "Emprestimos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leitores_Emprestimos_EmprestimoId",
                table: "Leitores");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Emprestimos_EmprestimoId",
                table: "Livros");

            migrationBuilder.DropTable(
                name: "Emprestimos");

            migrationBuilder.DropIndex(
                name: "IX_Livros_EmprestimoId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Leitores_EmprestimoId",
                table: "Leitores");

            migrationBuilder.DropColumn(
                name: "EmprestimoId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "EmprestimoId",
                table: "Leitores");
        }
    }
}
