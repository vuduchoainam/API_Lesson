using Microsoft.EntityFrameworkCore;

namespace Lessonapi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }

        #endregion

    }
}
