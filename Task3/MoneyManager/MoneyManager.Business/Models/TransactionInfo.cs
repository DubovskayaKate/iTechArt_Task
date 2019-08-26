using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MoneyManager.Business.Models
{
    //Each record of the output model should include
    //Asset.Name,
    //Category.Name (transaction subcategory),
    //Category.ParentName (transaction parent category),
    //Transaction.Amount,
    //Transaction.Date and
    //Transaction.Comment.
    public class TransactionInfo
    {
        public string AssetName { get; set; }
        public string CategotyName { get; set; }
        public string CategoryParentName { get; set; }
        public int TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionComment { get; set; }
    }
}