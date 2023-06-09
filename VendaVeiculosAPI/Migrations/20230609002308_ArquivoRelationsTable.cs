using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaVeiculosAPI.Migrations
{
    /// <inheritdoc />
    public partial class ArquivoRelationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CARRO_ARQUIVO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArquivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CARRO_ARQUIVO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_CARRO_ARQUIVO_TB_ARQUIVO_ArquivoId",
                        column: x => x.ArquivoId,
                        principalTable: "TB_ARQUIVO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CARRO_ARQUIVO_TB_CARRO_CarroId",
                        column: x => x.CarroId,
                        principalTable: "TB_CARRO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO_ARQUIVO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArquivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
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
                name: "IX_TB_CARRO_ARQUIVO_ArquivoId",
                table: "TB_CARRO_ARQUIVO",
                column: "ArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CARRO_ARQUIVO_CarroId",
                table: "TB_CARRO_ARQUIVO",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_ARQUIVO_ArquivoId",
                table: "USUARIO_ARQUIVO",
                column: "ArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_ARQUIVO_UsuarioId",
                table: "USUARIO_ARQUIVO",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CARRO_ARQUIVO");

            migrationBuilder.DropTable(
                name: "USUARIO_ARQUIVO");
        }
    }
}
