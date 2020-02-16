using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.EntityFrameworkDataAccess
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
    }
}
