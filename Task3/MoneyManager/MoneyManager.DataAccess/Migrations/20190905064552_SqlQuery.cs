using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.DataAccess.Migrations
{
    public partial class SqlQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE [Transaction]  SET [CategoryId] = 
            (
	            SELECT TOP(1) [ParentCategoryId] 
	            FROM [Category] 
	            WHERE [CategoryId] = [Transaction].[CategoryId]
            )
            WHERE [CategoryId] in 
            (
	            SELECT [Category].[CategoryId] FROM [Category] WHERE [Category].[ParentCategoryId] is not null
            );

            DELETE S FROM [Category] S WHERE S.[ParentCategoryId] is not null and 
            ((SELECT COUNT(*) FROM [Category] WHERE [Category].[ParentCategoryId] = S.CategoryId) = 0);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
