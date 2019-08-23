namespace MoneyManager.DataAccess.Repositories
{
    public class UserRepository
    {
        private IApplicationContext applicationContext { get; }
        public UserRepository(IApplicationContext context)
        {
            applicationContext = context;
        }
    }
}