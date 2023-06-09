using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaVeiculosAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ARQUIVO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeArquivo = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    TipoArquivo = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Arquivo = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ARQUIVO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_CARRO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Marca = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Modelo = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Foto = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: true),
                    Quilometragem = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CARRO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_CARRO_TB_USUARIO_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CARRO_UsuarioCriacaoId",
                table: "TB_CARRO",
                column: "UsuarioCriacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ARQUIVO");

            migrationBuilder.DropTable(
                name: "TB_CARRO");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
