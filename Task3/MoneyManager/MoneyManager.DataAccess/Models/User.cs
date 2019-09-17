using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.DataAccess.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Name { get; set; }
        public  string Email { get; set; }
        public int Balance { get; set; }

        public List<Asset> Assets { get; set; }

        public override string ToString()
        {
            return $"| {UserId.ToString().PadLeft(6 , ' ')} " +
                   $"| {Name.PadLeft(10 , ' ')} " +
                   $"| {Email.PadLeft(14, ' ' )}" +
                   $"| {Balance.ToString().PadLeft(6 , ' ')} |";
        }
    }
}
