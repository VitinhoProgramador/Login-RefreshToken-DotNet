using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APIrest.Migrations
{
    /// <inheritdoc />
    public partial class BancoInicialReal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Usuario = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    SenhaHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    SenhaSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    Cargo = table.Column<int>(type: "integer", nullable: false),
                    TokenDataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Papel = table.Column<string>(type: "text", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Anonimizado = table.Column<bool>(type: "boolean", nullable: false),
                    TrusScore = table.Column<int>(type: "integer", nullable: false),
                    XpTotal = table.Column<int>(type: "integer", nullable: false),
                    NivelAtual = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
