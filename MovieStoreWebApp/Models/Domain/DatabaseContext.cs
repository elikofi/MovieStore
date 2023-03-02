using System;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApp.Models.Domain
{
	public class DatabaseContext : DbContext
	{


		public DatabaseContext(DbContextOptions<DatabaseContext> options ) : base(options)
		{

		}

		public DbSet<Genre> Genre { get; set; }

        public DbSet<Production> Production { get; set; }

        public DbSet<Director> Director { get; set; }

        public DbSet<Movie> Movie { get; set; }
    }
}

