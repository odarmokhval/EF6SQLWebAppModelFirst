using EF6SQLWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF6SQLWebApplication.Migrations
{
    public partial class RpgCharacterInventoryConfiguration : IEntityTypeConfiguration<RpgCharacterInventory>
    {
        public void Configure(EntityTypeBuilder<RpgCharacterInventory> builder)
        {
            builder.ToTable("RpgCharacterInventory");

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.ItemName).IsRequired().HasColumnName("ItemName").HasColumnType("nvarchar(max)");
            builder.Property(e => e.Quantity).HasColumnName("Quantity").HasColumnType("int");
            builder.Property(e => e.RpgCharacterId).HasColumnName("RpgCharacterId").HasColumnType("int");

            builder.HasKey(e => e.Id);

            builder.HasOne(d => d.RpgCharacter)
                   .WithMany()
                   .HasForeignKey(d => d.RpgCharacterId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
        }
    }
}
