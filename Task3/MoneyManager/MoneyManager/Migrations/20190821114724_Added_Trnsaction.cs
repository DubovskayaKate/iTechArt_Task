using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.Migrations
{
    public partial class Added_Trnsaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryForeignKey",
                table: "Transactions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsExpenses = table.Column<bool>(nullable: false),
                    ParentCategoryCategoryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentCategoryCategoryId",
                        column: x => x.ParentCategoryCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryForeignKey",
                table: "Transactions",
                column: "CategoryForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryCategoryId",
                table: "Category",
                column: "ParentCategoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Category_CategoryForeignKey",
                table: "Transactions",
                column: "CategoryForeignKey",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Category_CategoryForeignKey",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CategoryForeignKey",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CategoryForeignKey",
                table: "Transactions");
        }
    }
}
