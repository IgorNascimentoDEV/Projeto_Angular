using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class corrigindo02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "tb_solicitacoes",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "string");

            migrationBuilder.AlterColumn<string>(
                name: "data_solicitacao",
                table: "tb_solicitacoes",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "string");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "tb_solicitacoes",
                type: "string",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "data_solicitacao",
                table: "tb_solicitacoes",
                type: "string",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");
        }
    }
}
