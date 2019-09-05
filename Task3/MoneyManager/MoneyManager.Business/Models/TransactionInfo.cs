using System;

namespace MoneyManager.Business.Models
{
    public class TransactionInfo
    {
        public string AssetName { get; set; }
        public string CategoryName { get; set; }
        public string CategoryParentName { get; set; }
        public int TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionComment { get; set; }
    }
}