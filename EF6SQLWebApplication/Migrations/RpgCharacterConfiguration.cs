using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF6SQLWebApplication.Migrations
{
    public partial class RpgCharacterConfiguration : IEntityTypeConfiguration<RpgCharacter>
    {
        public void Configure(EntityTypeBuilder<RpgCharacter> builder)
        {
            builder.ToTable("RpgCharacters");

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Name).IsRequired().HasColumnName("Name").HasColumnType("nvarchar(max)");
            builder.Property(e => e.CharacterClass).HasColumnName("CharacterClass").HasColumnType("int");
            builder.Property(e => e.HitPoints).HasColumnName("HitPoints").HasColumnType("int");

            builder.HasKey(e => e.Id);
        }
    }
}
