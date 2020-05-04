using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCExchange
{
	class ExchangeContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Card> Cards { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = GCExchange; Integrated Security = True; Connect Timeout = 30;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(e =>
			{
				e.ToTable("Users");
				e.HasKey(u => u.UserID);
				e.Property(u => u.UserID)
					.ValueGeneratedOnAdd();

				e.Property(u => u.EmailAddress)
					.IsRequired()
					.HasMaxLength(100);

				e.Property(u => u.UserName)
					.IsRequired()
					.HasMaxLength(250);
			});

			modelBuilder.Entity<Card>(e =>
			{
				e.ToTable("Cards");
				e.HasKey(c => c.CardID);
				e.Property(c => c.CardID)
					.ValueGeneratedOnAdd();

				e.Property(c => c.VendorName)
					.IsRequired()
					.HasMaxLength(100);

				e.Property(c => c.EmailAddress)
					.IsRequired()
					.HasMaxLength(100);
			});

			modelBuilder.Entity<Transaction>(e =>
			{
				e.ToTable("Transactions");
				e.HasKey(t => t.TransactionID);
				e.Property(t => t.TransactionID)
					.ValueGeneratedOnAdd();
			});
		}
	}
}
