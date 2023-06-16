using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaVeiculosAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemocaoIDUsuarioCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CARRO_TB_USUARIO_UsuarioCriacaoId",
                table: "TB_CARRO");

            migrationBuilder.DropIndex(
                name: "IX_TB_CARRO_UsuarioCriacaoId",
                table: "TB_CARRO");

            migrationBuilder.DropColumn(
                name: "UsuarioCriacaoId",
                table: "TB_CARRO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioCriacaoId",
                table: "TB_CARRO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CARRO_UsuarioCriacaoId",
                table: "TB_CARRO",
                column: "UsuarioCriacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CARRO_TB_USUARIO_UsuarioCriacaoId",
                table: "TB_CARRO",
                column: "UsuarioCriacaoId",
                principalTable: "TB_USUARIO",
                principalColumn: "ID");
        }
    }
}
