using adventure_time_api.src.domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace adventure_time_api.src.infra.database.map
{
    public class CharacterMap : IEntityTypeConfiguration<CharacterModel>
    {
        public void Configure(EntityTypeBuilder<CharacterModel> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.HasPower).HasMaxLength(200);
        }
    }
}
