namespace Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDataContext dataContext)
            : base(dataContext)
        {
        }
    }
}
