using app11.Entities;
using Microsoft.EntityFrameworkCore;

namespace app11.Persistence
{

    public class CollegeDbContext : DbContext
    {

        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
        {

        }

        public DbSet<Professor> Professors { get; set; }

    }

}