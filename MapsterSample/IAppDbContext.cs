using Microsoft.EntityFrameworkCore;

namespace MapsterSample;

public interface IAppDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
}
