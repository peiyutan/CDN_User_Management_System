using Microsoft.EntityFrameworkCore;
using CDN_Web_API.Models;

namespace CDN_Web_API.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
