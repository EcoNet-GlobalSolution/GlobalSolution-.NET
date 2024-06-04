using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution_.NET.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coordenadas",
                columns: table => new
                {
                    id_coordenadas = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordenadas", x => x.id_coordenadas);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_risco",
                columns: table => new
                {
                    id_risco = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    categoria = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_risco", x => x.id_risco);
                });

            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    id_especie = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_comum = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    especie = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    id_risco = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Tiposid_risco = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.id_especie);
                    table.ForeignKey(
                        name: "FK_Especie_Tipo_risco_Tiposid_risco",
                        column: x => x.Tiposid_risco,
                        principalTable: "Tipo_risco",
                        principalColumn: "id_risco");
                });

            migrationBuilder.CreateTable(
                name: "Deteccao",
                columns: table => new
                {
                    id_deteccao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    id_coordenadas = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_especie = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deteccao", x => x.id_deteccao);
                    table.ForeignKey(
                        name: "FK_Deteccao_Coordenadas_id_coordenadas",
                        column: x => x.id_coordenadas,
                        principalTable: "Coordenadas",
                        principalColumn: "id_coordenadas",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deteccao_Especie_id_especie",
                        column: x => x.id_especie,
                        principalTable: "Especie",
                        principalColumn: "id_especie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deteccao_id_coordenadas",
                table: "Deteccao",
                column: "id_coordenadas");

            migrationBuilder.CreateIndex(
                name: "IX_Deteccao_id_especie",
                table: "Deteccao",
                column: "id_especie");

            migrationBuilder.CreateIndex(
                name: "IX_Especie_Tiposid_risco",
                table: "Especie",
                column: "Tiposid_risco");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deteccao");

            migrationBuilder.DropTable(
                name: "Coordenadas");

            migrationBuilder.DropTable(
                name: "Especie");

            migrationBuilder.DropTable(
                name: "Tipo_risco");
        }
    }
}
