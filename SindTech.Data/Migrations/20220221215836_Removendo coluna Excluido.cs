using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SindTech.Data.Migrations
{
    public partial class RemovendocolunaExcluido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Excluido",
                table: "Moradores",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "Excluido",
                table: "Contatos",
                newName: "Ativo");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Reclamacoes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Reclamacoes");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Moradores",
                newName: "Excluido");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Contatos",
                newName: "Excluido");
        }
    }
}
