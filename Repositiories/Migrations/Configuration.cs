namespace Repositories
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        // For more information, see http://blog.safaribooksonline.com/2013/05/20/entity-framework-using-database-migration-to-seed-our-database/    
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {
            context.Roles.AddOrUpdate(p => p.Name,
                new Role() { Name = "Super Admin" },
                new Role() { Name = "Admin" });
            context.SaveChanges();

            context.Users.AddOrUpdate(p => p.FirstName,
               new User() { FirstName = "Nitin", LastName = "Singh", UserName = "nitin27may", Password = "Sh@kti009", Status = true, RoleId = context.Roles.First(x => x.Name == "Super Admin").Id });
            context.SaveChanges();
        }
    }
}