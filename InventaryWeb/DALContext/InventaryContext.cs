using InventaryWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace InventaryWeb.DALContext
{
    public class InventaryContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product{ get; set; }
        public DbSet<EntryDetails> EntryDetails { get; set; }
        public DbSet<ExitDetails> ExitDetails { get; set; }
        public DbSet<EntryNote> EntryNote { get; set; }
        public DbSet<ExitNote> ExitNote { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }


    }
}