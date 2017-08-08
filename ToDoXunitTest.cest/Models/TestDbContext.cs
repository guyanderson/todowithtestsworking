using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoXUnitTest.Models;

namespace ToDoXUnitTest.test.Models
{
    public class TestDbContext : ToDoDbContext
    {
        public override DbSet<Item> Items { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ToDoTest;integrated security = True");
        }
    }
}
