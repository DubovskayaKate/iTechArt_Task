using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManagerClassLibrary
{
    public class Asset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }

        [ForeignKey("UserForeignKey")]
        public  User User { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
