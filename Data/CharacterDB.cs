using Microsoft.EntityFrameworkCore;
using adventure_time_api.Models;

namespace adventure_time_api.Data
{
    public class CharacterDBContext : DbContext
    {
        public CharacterDBContext(DbContextOptions<CharacterDBContext> options)
            : base(options)
        {
        }

        public DbSet<CharacterModel> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
