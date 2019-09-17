using MoneyManager.DataAccess.Models;

namespace MoneyManager.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User> 
    {
        public UserRepository(IApplicationContext context): base(context)
        {
            
        }

    }
}