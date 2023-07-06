using adventure_time_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace adventure_time_api.Data.Map
{
    public class CharacterMap : IEntityTypeConfiguration<CharacterModel> 
    {
        public void Configure(EntityTypeBuilder<CharacterModel> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.HavePowers).IsRequired();
        }
    }
}