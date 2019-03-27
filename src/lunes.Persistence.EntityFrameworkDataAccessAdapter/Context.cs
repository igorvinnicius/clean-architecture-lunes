using System.Threading.Tasks;
using lunes.Domain.Accounts;
using Microsoft.EntityFrameworkCore;

namespace lunes.Persistence.EntityFrameworkDataAccessAdapter
{
    public class Context : DbContext, IContext
    {
	    public DbSet<Account> Accounts { get; set; }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    optionsBuilder
			    .UseSqlServer(@"Server=(LocalDB)\\MSSQLLocalDB;Database=LunesDb;Integrated Security=true;");
	    }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
		    modelBuilder.Entity<Account>();
	    }

		public async  Task ExecuteSaveChangesAsync()
	    {
		    await this.SaveChangesAsync();
	    }

	    public async Task UpdateEntity(Account account)
	    {
		    this.Update(account);
		    await Task.CompletedTask;
	    }

	    public async Task DeleteEntity(Account account)
	    {
		    this.Remove(account);
		    await Task.CompletedTask;
	    }

	}
}
