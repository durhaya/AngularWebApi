using System.Data.Entity;

namespace Repositories
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext()
            : base("database")
        {
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<TravelHistory> TravelHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TravelHistory>().Property(x => x.Lat).HasPrecision(11, 7);
            modelBuilder.Entity<TravelHistory>().Property(x => x.Long).HasPrecision(11, 7);
            base.OnModelCreating(modelBuilder);
        }

        public void ExecuteCommand(string command, params object[] parameters)
        {
            base.Database.ExecuteSqlCommand(command, parameters);
        }

    }
}
