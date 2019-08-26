namespace MoneyManager.Business.Models
{
    public class UserWithBalance
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public int Balance { get; set; }

        public override string ToString()
        {
            return $"{Name}  {Email}  {UserId} {Balance}";
        }
    }
}