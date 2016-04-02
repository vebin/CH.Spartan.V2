using CH.Spartan.EntityFramework;
using EntityFramework.DynamicFilters;

namespace CH.Spartan.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly SpartanDbContext _context;

        public InitialDataBuilder(SpartanDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.DisableAllFilters();

            new DefaultEditionsBuilder(_context).Build();
            new DefaultTenantRoleAndUserBuilder(_context).Build();
            new DefaultLanguagesBuilder(_context).Build();
        }
    }
}
