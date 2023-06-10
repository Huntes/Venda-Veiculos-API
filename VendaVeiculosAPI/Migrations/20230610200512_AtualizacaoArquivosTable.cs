using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaVeiculosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoArquivosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CARRO_ARQUIVO_TB_ARQUIVO_ArquivoId",
                table: "TB_CARRO_ARQUIVO");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_CARRO_ARQUIVO_TB_CARRO_CarroId",
                table: "TB_CARRO_ARQUIVO");

            migrationBuilder.DropIndex(
                name: "IX_TB_CARRO_ARQUIVO_ArquivoId",
                table: "TB_CARRO_ARQUIVO");

            migrationBuilder.DropIndex(
                name: "IX_TB_CARRO_ARQUIVO_CarroId",
                table: "TB_CARRO_ARQUIVO");

            migrationBuilder.AddColumn<Guid>(
                name: "ARQUIVO_ID",
                table: "TB_CARRO_ARQUIVO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CARRO_ID",
                table: "TB_CARRO_ARQUIVO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TB_CARRO_ARQUIVO_ARQUIVO_ID",
                table: "TB_CARRO_ARQUIVO",
                column: "ARQUIVO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CARRO_ARQUIVO_CARRO_ID",
                table: "TB_CARRO_ARQUIVO",
                column: "CARRO_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CARRO_ARQUIVO_TB_ARQUIVO_ARQUIVO_ID",
                table: "TB_CARRO_ARQUIVO",
                column: "ARQUIVO_ID",
                principalTable: "TB_ARQUIVO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CARRO_ARQUIVO_TB_CARRO_CARRO_ID",
                table: "TB_CARRO_ARQUIVO",
                column: "CARRO_ID",
                principalTable: "TB_CARRO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CARRO_ARQUIVO_TB_ARQUIVO_ARQUIVO_ID",
                table: "TB_CARRO_ARQUIVO");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_CARRO_ARQUIVO_TB_CARRO_CARRO_ID",
                table: "TB_CARRO_ARQUIVO");

            migrationBuilder.DropIndex(
                name: "IX_TB_CARRO_ARQUIVO_ARQUIVO_ID",
                table: "TB_CARRO_ARQUIVO");

            migrationBuilder.DropIndex(
                name: "IX_TB_CARRO_ARQUIVO_CARRO_ID",
                table: "TB_CARRO_ARQUIVO");

            migrationBuilder.DropColumn(
                name: "ARQUIVO_ID",
                table: "TB_CARRO_ARQUIVO");

            migrationBuilder.DropColumn(
                name: "CARRO_ID",
                table: "TB_CARRO_ARQUIVO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CARRO_ARQUIVO_ArquivoId",
                table: "TB_CARRO_ARQUIVO",
                column: "ArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CARRO_ARQUIVO_CarroId",
                table: "TB_CARRO_ARQUIVO",
                column: "CarroId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CARRO_ARQUIVO_TB_ARQUIVO_ArquivoId",
                table: "TB_CARRO_ARQUIVO",
                column: "ArquivoId",
                principalTable: "TB_ARQUIVO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CARRO_ARQUIVO_TB_CARRO_CarroId",
                table: "TB_CARRO_ARQUIVO",
                column: "CarroId",
                principalTable: "TB_CARRO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
