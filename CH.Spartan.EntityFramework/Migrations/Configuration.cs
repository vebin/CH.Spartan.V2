using System.Data.Entity.Migrations;
using CH.Spartan.Migrations.SeedData;

namespace CH.Spartan.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Spartan.EntityFramework.SpartanDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Spartan";
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(Spartan.EntityFramework.SpartanDbContext context)
        {
            new InitialDataBuilder(context).Build();
        }
    }
}
