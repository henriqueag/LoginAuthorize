using System.Data.Entity.Migrations;

namespace LoginAuthorize.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LoginAuthorize.Data.AppDbContext";
        }

        protected override void Seed(Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
