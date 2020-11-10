using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreFundamentals
{
    public class ExampleContext:DbContext //Database ile iletişimimizi sağlayan sınıf
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database=ExampleDB;Server=(localdb)\MSSQLLocalDB;Trusted_Connection=True;");//Connection String Eklendi
        }
    }
}
