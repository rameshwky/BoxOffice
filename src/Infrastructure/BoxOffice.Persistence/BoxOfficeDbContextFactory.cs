using BoxOffice.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOffice.Persistence
{
    public class BoxOfficeDbContextFactory : DesignTimeDbContextFactoryBase<BoxOfficeDbContext>
    {
        protected override BoxOfficeDbContext CreateNewInstance(DbContextOptions<BoxOfficeDbContext> options)
        {
            return new BoxOfficeDbContext(options);
        }
    }
}
