using Microsoft.EntityFrameworkCore;
using Job_Search;

namespace Job_Search.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Jobs> Jobs { get; set; } = null!;
        public DbSet<Openings> Openings { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
        }
    }
}
