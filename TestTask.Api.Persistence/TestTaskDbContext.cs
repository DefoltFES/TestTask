using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Api.Domain;

namespace TestTask.Api.Persistence
{
    public class TestTaskDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options):base(options)
        {

        }

    }
}
