using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.Migrations
{
    public partial class Sql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Update [Transactions]  Set [CategoryForeignKey] = 
            (
	            select TOP(1) [ParentCategoryCategoryId] 
	            from [Categories] 
	            where [CategoryId] = [Transactions].[CategoryForeignKey]
            )
            where [CategoryForeignKey] in 
            (
	            select [Categories].[CategoryId] from [Categories] where [Categories].[ParentCategoryCategoryId] is not null
            );

            Delete S from [Categories] S where S.[ParentCategoryCategoryId] is not null and 
            ((select COUNT(*) from [Categories] where [Categories].[ParentCategoryCategoryId] = S.CategoryId) = 0);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
