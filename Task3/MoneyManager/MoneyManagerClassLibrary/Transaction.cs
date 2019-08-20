using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MoneyManagerClassLibrary
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public  DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; }

        [ForeignKey("AssetForeignKey")]
        public Asset Asset { get; set; }

        //Category
    }
}
