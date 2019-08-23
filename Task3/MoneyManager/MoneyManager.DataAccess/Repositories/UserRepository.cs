using System.Collections.Generic;
using MoneyManager.DataAccess.Models;

namespace MoneyManager.DataAccess.Repositories
{
    public class UserRepository<T> : BaseRepository<T> where T: User
    {
        public UserRepository(ApplicationContext context): base(context)
        {
            
        }
    }
}