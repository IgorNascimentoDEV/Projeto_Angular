using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class primeira01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    preco = table.Column<double>(type: "float", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_solicitacoes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    solicitante = table.Column<string>(type: "varchar(50)", nullable: false),
                    setor = table.Column<string>(type: "varchar(50)", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    centro_custo = table.Column<int>(type: "int", nullable: false),
                    data_solicitacao = table.Column<string>(type: "varchar(50)", nullable: false),
                    status = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_solicitacoes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_solicitacoes_itens",
                columns: table => new
                {
                    ItensId = table.Column<long>(type: "bigint", nullable: false),
                    SolicitacoesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_solicitacoes_itens", x => new { x.ItensId, x.SolicitacoesId });
                    table.ForeignKey(
                        name: "FK_tb_solicitacoes_itens_tb_item_ItensId",
                        column: x => x.ItensId,
                        principalTable: "tb_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_solicitacoes_itens_tb_solicitacoes_SolicitacoesId",
                        column: x => x.SolicitacoesId,
                        principalTable: "tb_solicitacoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_solicitacoes_itens_SolicitacoesId",
                table: "tb_solicitacoes_itens",
                column: "SolicitacoesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_solicitacoes_itens");

            migrationBuilder.DropTable(
                name: "tb_item");

            migrationBuilder.DropTable(
                name: "tb_solicitacoes");
        }
    }
}
