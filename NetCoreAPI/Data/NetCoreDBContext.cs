using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreAPI.Data
{
    public class NetCoreDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public NetCoreDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("ConnectionStrings:NetCoreDBContextConnectionString");
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<USERS> Users { get; set; }

        [Table("USERS")]
        public class USERS
        {
            [Key]
            public int UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
        }
        // The ApplicationDbContext class must expose a public constructor with a DbContextOptions<ApplicationDbContext> parameter.This is how context configuration from AddDbContext is passed to the DbContext. 
        // https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/
    }
}
