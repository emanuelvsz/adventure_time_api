using Microsoft.EntityFrameworkCore;
using adventure_time_api.Models;
using adventure_time_api.Data.Map;

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
            modelBuilder.ApplyConfiguration(new CharacterMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
