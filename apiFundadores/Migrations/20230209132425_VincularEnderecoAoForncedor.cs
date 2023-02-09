using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiFundadores.Migrations
{
    public partial class VincularEnderecoAoForncedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FornecedorModelId",
                table: "Enderecos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_FornecedorModelId",
                table: "Enderecos",
                column: "FornecedorModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Fornecedores_FornecedorModelId",
                table: "Enderecos",
                column: "FornecedorModelId",
                principalTable: "Fornecedores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Fornecedores_FornecedorModelId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_FornecedorModelId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "FornecedorModelId",
                table: "Enderecos");
        }
    }
}
