using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accesorios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Precio = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accesorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Cedula = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consolas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Modelo = table.Column<string>(nullable: true),
                    Precio = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consolas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Genero = table.Column<string>(nullable: true),
                    Precio = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "compra_Accesorios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteIDId = table.Column<int>(nullable: true),
                    AccesoriosIDId = table.Column<int>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compra_Accesorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_compra_Accesorios_accesorios_AccesoriosIDId",
                        column: x => x.AccesoriosIDId,
                        principalTable: "accesorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_compra_Accesorios_clientes_ClienteIDId",
                        column: x => x.ClienteIDId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "compra_Consolas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteIDId = table.Column<int>(nullable: true),
                    ConsolaIDId = table.Column<int>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compra_Consolas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_compra_Consolas_clientes_ClienteIDId",
                        column: x => x.ClienteIDId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_compra_Consolas_Consolas_ConsolaIDId",
                        column: x => x.ConsolaIDId,
                        principalTable: "Consolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "compra_Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteIDId = table.Column<int>(nullable: true),
                    GamesIDId = table.Column<int>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compra_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_compra_Games_clientes_ClienteIDId",
                        column: x => x.ClienteIDId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_compra_Games_games_GamesIDId",
                        column: x => x.GamesIDId,
                        principalTable: "games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compra_Accesorios_AccesoriosIDId",
                table: "compra_Accesorios",
                column: "AccesoriosIDId");

            migrationBuilder.CreateIndex(
                name: "IX_compra_Accesorios_ClienteIDId",
                table: "compra_Accesorios",
                column: "ClienteIDId");

            migrationBuilder.CreateIndex(
                name: "IX_compra_Consolas_ClienteIDId",
                table: "compra_Consolas",
                column: "ClienteIDId");

            migrationBuilder.CreateIndex(
                name: "IX_compra_Consolas_ConsolaIDId",
                table: "compra_Consolas",
                column: "ConsolaIDId");

            migrationBuilder.CreateIndex(
                name: "IX_compra_Games_ClienteIDId",
                table: "compra_Games",
                column: "ClienteIDId");

            migrationBuilder.CreateIndex(
                name: "IX_compra_Games_GamesIDId",
                table: "compra_Games",
                column: "GamesIDId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compra_Accesorios");

            migrationBuilder.DropTable(
                name: "compra_Consolas");

            migrationBuilder.DropTable(
                name: "compra_Games");

            migrationBuilder.DropTable(
                name: "accesorios");

            migrationBuilder.DropTable(
                name: "Consolas");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "games");
        }
    }
}
