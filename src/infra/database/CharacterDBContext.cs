using adventure_time_api.src.domain.models;
using adventure_time_api.src.infra.database.map;
using Microsoft.EntityFrameworkCore;

namespace adventure_time_api.src.infra.database
{
    public class CharacterDBContext : DbContext
    {
        public CharacterDBContext(DbContextOptions<CharacterDBContext> options)
            : base(options)
        { }
        public DbSet<CharacterModel> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CharacterMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
