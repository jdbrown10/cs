using Microsoft.EntityFrameworkCore;

namespace template.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        //ADD DB SETS HERE
        public DbSet<User> Users {get;set;}
    }
}