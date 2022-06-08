using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreAPI.Data
{
    public class NetCoreDBContext : DbContext
    {
        public NetCoreDBContext(DbContextOptions<NetCoreDBContext> options): base(options)
        {}

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
