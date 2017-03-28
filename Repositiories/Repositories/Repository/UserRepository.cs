namespace Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDataContext dataContext)
            : base(dataContext)
        {
        }
    }
}
