using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data
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
