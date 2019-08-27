using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MoneyManager.DataAccess.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public bool IsExpenses { get; set; }
        public Category ParentCategory { get; set; }
        public string Name { get; set; }

        public  List<Category> ChildCategories { get; set; }

        public List<Transaction> TransactionList { get; set; }

    }
}
