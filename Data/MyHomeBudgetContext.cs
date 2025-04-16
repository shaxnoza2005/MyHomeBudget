using Microsoft.EntityFrameworkCore;
using MyHomeBudget.Models;

namespace MyHomeBudget.Data
{
    public class MyHomeBudgetContext : DbContext
    {
        public MyHomeBudgetContext(DbContextOptions<MyHomeBudgetContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
