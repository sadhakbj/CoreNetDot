using Microsoft.EntityFrameworkCore;

namespace movies.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = "Server=localhost;Port=3306;Database=movies;User Id=root;Password=root;";

            optionsBuilder.UseMySql(connection);
        }

    }
}