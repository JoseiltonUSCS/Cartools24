using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class TabelasEcampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecoServico");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.AddColumn<int>(
                name: "LocalizacaoId",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaDaSemana = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Disponibilidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localizacaos",
                columns: table => new
                {
                    LocalizacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    OficinaAnuncianteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacaos", x => x.LocalizacaoId);
                });

            migrationBuilder.CreateTable(
                name: "OficinaAnunciantes",
                columns: table => new
                {
                    OficinaAnuncianteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalizacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OficinaAnunciantes", x => x.OficinaAnuncianteId);
                });

            migrationBuilder.CreateTable(
                name: "LocalizacaoServico",
                columns: table => new
                {
                    LocalizacaosLocalizacaoId = table.Column<int>(type: "int", nullable: false),
                    ServicosServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizacaoServico", x => new { x.LocalizacaosLocalizacaoId, x.ServicosServicoId });
                    table.ForeignKey(
                        name: "FK_LocalizacaoServico_Localizacaos_LocalizacaosLocalizacaoId",
                        column: x => x.LocalizacaosLocalizacaoId,
                        principalTable: "Localizacaos",
                        principalColumn: "LocalizacaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalizacaoServico_Servicos_ServicosServicoId",
                        column: x => x.ServicosServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalizacaoOficinaAnunciante",
                columns: table => new
                {
                    LocalizacaosLocalizacaoId = table.Column<int>(type: "int", nullable: false),
                    OficinaAnunciantesOficinaAnuncianteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizacaoOficinaAnunciante", x => new { x.LocalizacaosLocalizacaoId, x.OficinaAnunciantesOficinaAnuncianteId });
                    table.ForeignKey(
                        name: "FK_LocalizacaoOficinaAnunciante_Localizacaos_LocalizacaosLocalizacaoId",
                        column: x => x.LocalizacaosLocalizacaoId,
                        principalTable: "Localizacaos",
                        principalColumn: "LocalizacaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalizacaoOficinaAnunciante_OficinaAnunciantes_OficinaAnunciantesOficinaAnuncianteId",
                        column: x => x.OficinaAnunciantesOficinaAnuncianteId,
                        principalTable: "OficinaAnunciantes",
                        principalColumn: "OficinaAnuncianteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ServicoId",
                table: "Agendamentos",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizacaoOficinaAnunciante_OficinaAnunciantesOficinaAnuncianteId",
                table: "LocalizacaoOficinaAnunciante",
                column: "OficinaAnunciantesOficinaAnuncianteId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizacaoServico_ServicosServicoId",
                table: "LocalizacaoServico",
                column: "ServicosServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "LocalizacaoOficinaAnunciante");

            migrationBuilder.DropTable(
                name: "LocalizacaoServico");

            migrationBuilder.DropTable(
                name: "OficinaAnunciantes");

            migrationBuilder.DropTable(
                name: "Localizacaos");

            migrationBuilder.DropColumn(
                name: "LocalizacaoId",
                table: "Servicos");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoServico",
                columns: table => new
                {
                    EnderecosEnderecoId = table.Column<int>(type: "int", nullable: false),
                    ServicosServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoServico", x => new { x.EnderecosEnderecoId, x.ServicosServicoId });
                    table.ForeignKey(
                        name: "FK_EnderecoServico_Enderecos_EnderecosEnderecoId",
                        column: x => x.EnderecosEnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnderecoServico_Servicos_ServicosServicoId",
                        column: x => x.ServicosServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoServico_ServicosServicoId",
                table: "EnderecoServico",
                column: "ServicosServicoId");
        }
    }
}
