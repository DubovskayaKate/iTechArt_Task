namespace MoneyManager.Business.Models
{
    public class UserWithoutBalance
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }

        public override string ToString()
        {
            return $"{Name}  {Email}  {UserId}";
        }
    }
}