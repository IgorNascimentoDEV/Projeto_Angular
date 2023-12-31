using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class relacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_solicitacoes_itens");

            migrationBuilder.AddColumn<long>(
                name: "ItemId",
                table: "tb_solicitacoes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_tb_solicitacoes_ItemId",
                table: "tb_solicitacoes",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_solicitacoes_tb_item_ItemId",
                table: "tb_solicitacoes",
                column: "ItemId",
                principalTable: "tb_item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_solicitacoes_tb_item_ItemId",
                table: "tb_solicitacoes");

            migrationBuilder.DropIndex(
                name: "IX_tb_solicitacoes_ItemId",
                table: "tb_solicitacoes");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "tb_solicitacoes");

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
    }
}
