using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskNote.Entity.FrameworkCore
{
    public interface ISexDbSet
    {
        public DbSet<SexEntity> Sexs { get; set; }
    }

    public class SexMap : IEntityTypeConfiguration<SexEntity>
    {
        public void Configure(EntityTypeBuilder<SexEntity> builder)
        {
            builder.ToTable("m_sex");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Name).HasColumnName("name");
        }
    }
}
