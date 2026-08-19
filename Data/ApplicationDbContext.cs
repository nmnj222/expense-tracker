using expense_tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace expense_tracker.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<TransactionGroup> TransactionGroups { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<SavingsPlan> SavingsPlans { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
    }
}
