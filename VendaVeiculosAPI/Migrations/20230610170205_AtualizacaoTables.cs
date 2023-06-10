using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaVeiculosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "TB_CARRO");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "TB_USUARIO",
                type: "VARCHAR(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "TB_USUARIO",
                type: "VARCHAR(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "TB_CARRO",
                type: "VARCHAR(500)",
                nullable: true);
        }
    }
}
