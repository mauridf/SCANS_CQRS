using Microsoft.EntityFrameworkCore.Migrations;

namespace SCANS_CQRS.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    IdEditora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEditora = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoras", x => x.IdEditora);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas",
                columns: table => new
                {
                    IdIdioma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeIdioma = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas", x => x.IdIdioma);
                });

            migrationBuilder.CreateTable(
                name: "PersEquipes",
                columns: table => new
                {
                    IdPersEquipe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePersEquipe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DscPersEquipe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersEquipes", x => x.IdPersEquipe);
                });

            migrationBuilder.CreateTable(
                name: "TipoPublicacoes",
                columns: table => new
                {
                    IdTipoPublicacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoPublicacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPublicacoes", x => x.IdTipoPublicacao);
                });

            migrationBuilder.CreateTable(
                name: "HQs",
                columns: table => new
                {
                    IdHQ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeHQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroHQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeHQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DscResumoHQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEditora = table.Column<int>(type: "int", nullable: false),
                    EditoraIdEditora = table.Column<int>(type: "int", nullable: true),
                    IdIdioma = table.Column<int>(type: "int", nullable: false),
                    IdiomaIdIdioma = table.Column<int>(type: "int", nullable: true),
                    IdTipoPublicacao = table.Column<int>(type: "int", nullable: false),
                    TipoPublicacaoIdTipoPublicacao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HQs", x => x.IdHQ);
                    table.ForeignKey(
                        name: "FK_HQs_Editoras_EditoraIdEditora",
                        column: x => x.EditoraIdEditora,
                        principalTable: "Editoras",
                        principalColumn: "IdEditora",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HQs_Idiomas_IdiomaIdIdioma",
                        column: x => x.IdiomaIdIdioma,
                        principalTable: "Idiomas",
                        principalColumn: "IdIdioma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HQs_TipoPublicacoes_TipoPublicacaoIdTipoPublicacao",
                        column: x => x.TipoPublicacaoIdTipoPublicacao,
                        principalTable: "TipoPublicacoes",
                        principalColumn: "IdTipoPublicacao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HQ_PersEquipes",
                columns: table => new
                {
                    IdHQPersEquipe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPersEquipe = table.Column<int>(type: "int", nullable: false),
                    PersEquipeIdPersEquipe = table.Column<int>(type: "int", nullable: true),
                    IdHQ = table.Column<int>(type: "int", nullable: false),
                    HQIdHQ = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HQ_PersEquipes", x => x.IdHQPersEquipe);
                    table.ForeignKey(
                        name: "FK_HQ_PersEquipes_HQs_HQIdHQ",
                        column: x => x.HQIdHQ,
                        principalTable: "HQs",
                        principalColumn: "IdHQ",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HQ_PersEquipes_PersEquipes_PersEquipeIdPersEquipe",
                        column: x => x.PersEquipeIdPersEquipe,
                        principalTable: "PersEquipes",
                        principalColumn: "IdPersEquipe",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HQ_PersEquipes_HQIdHQ",
                table: "HQ_PersEquipes",
                column: "HQIdHQ");

            migrationBuilder.CreateIndex(
                name: "IX_HQ_PersEquipes_PersEquipeIdPersEquipe",
                table: "HQ_PersEquipes",
                column: "PersEquipeIdPersEquipe");

            migrationBuilder.CreateIndex(
                name: "IX_HQs_EditoraIdEditora",
                table: "HQs",
                column: "EditoraIdEditora");

            migrationBuilder.CreateIndex(
                name: "IX_HQs_IdiomaIdIdioma",
                table: "HQs",
                column: "IdiomaIdIdioma");

            migrationBuilder.CreateIndex(
                name: "IX_HQs_TipoPublicacaoIdTipoPublicacao",
                table: "HQs",
                column: "TipoPublicacaoIdTipoPublicacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HQ_PersEquipes");

            migrationBuilder.DropTable(
                name: "HQs");

            migrationBuilder.DropTable(
                name: "PersEquipes");

            migrationBuilder.DropTable(
                name: "Editoras");

            migrationBuilder.DropTable(
                name: "Idiomas");

            migrationBuilder.DropTable(
                name: "TipoPublicacoes");
        }
    }
}
