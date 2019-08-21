using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MoneyManagerClassLibrary
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        public  DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; }

        [ForeignKey("CategoryForeignKey")]
        public Category Category { get; set; }

        [ForeignKey("AssetForeignKey")]
        public Asset Asset { get; set; }

        //Category
    }
}
