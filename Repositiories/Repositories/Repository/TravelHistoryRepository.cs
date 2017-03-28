namespace Repositories
{
    public class TravelHistoryRepository : RepositoryBase<TravelHistory>, ITravelHistoryRepository
    {
        public TravelHistoryRepository(IDataContext dataContext)
            : base(dataContext)
        {
        }
    }
}
