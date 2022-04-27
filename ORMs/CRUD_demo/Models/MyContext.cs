using Microsoft.EntityFrameworkCore;
namespace CRUD_demo.Models
{ 
    // the MyContext class representing a session with our MySQL 
    // database allowing us to query for or save data
    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }
        // the "Monsters" table name will come from the DbSet variable name
        public DbSet<Pet> Pets { get; set; } //call the db a plural version of what it is-> it's a db filled with pets so call it "pets"
    }
}
