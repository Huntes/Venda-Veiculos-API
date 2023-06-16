using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaVeiculosAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemocaoUsuarioArquivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIO_ARQUIVO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIO_ARQUIVO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArquivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDelete = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_ARQUIVO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USUARIO_ARQUIVO_TB_ARQUIVO_ArquivoId",
                        column: x => x.ArquivoId,
                        principalTable: "TB_ARQUIVO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIO_ARQUIVO_TB_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_ARQUIVO_ArquivoId",
                table: "USUARIO_ARQUIVO",
                column: "ArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_ARQUIVO_UsuarioId",
                table: "USUARIO_ARQUIVO",
                column: "UsuarioId");
        }
    }
}
