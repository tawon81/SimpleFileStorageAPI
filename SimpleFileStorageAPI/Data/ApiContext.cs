using Microsoft.EntityFrameworkCore;
using SimpleFileStorageAPI.Models;

namespace SimpleFileStorageAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext()
        {
        }

        public virtual DbSet<BinaryFile> ApiFiles { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
