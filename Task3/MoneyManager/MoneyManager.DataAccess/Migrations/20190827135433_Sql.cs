using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.DataAccess.Migrations
{
    public partial class Sql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE [Transactions]  SET [CategoryForeignKey] = 
            (
	            SELECT TOP(1) [ParentCategoryCategoryId] 
	            FROM [Categories] 
	            WHERE [CategoryId] = [Transactions].[CategoryForeignKey]
            )
            WHERE [CategoryForeignKey] in 
            (
	            SELECT [Categories].[CategoryId] FROM [Categories] WHERE [Categories].[ParentCategoryCategoryId] is not null
            );

            DELETE S FROM [Categories] S WHERE S.[ParentCategoryCategoryId] is not null and 
            ((SELECT COUNT(*) FROM [Categories] WHERE [Categories].[ParentCategoryCategoryId] = S.CategoryId) = 0);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
