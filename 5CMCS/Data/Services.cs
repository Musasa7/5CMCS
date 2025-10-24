using Microsoft.EntityFrameworkCore;

namespace _5CMCS.Data
{
    public static class Services
    {
        // Creating a short lived DbContext each time you need DB access
        public static AppDbContext CreateDb()
        {
            var opts = new DbContextOptionsBuilder<AppDbContext>();
            opts.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CMCS;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new AppDbContext(opts.Options);
        }
    }
}
