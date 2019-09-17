namespace MoneyManager.Business.Models
{
    public class CategoryInfo
    {
        public string CategoryName { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"{CategoryName}  {Amount}";
        }
    }
}