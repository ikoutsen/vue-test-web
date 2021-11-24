using Microsoft.EntityFrameworkCore;

namespace VueTestWebAPI.Models {
    public class ContactsContext : DbContext {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Position> Position { get; set; }
        public ContactsContext(DbContextOptions<ContactsContext> options) :
            base(options) {

        }
    }
}
