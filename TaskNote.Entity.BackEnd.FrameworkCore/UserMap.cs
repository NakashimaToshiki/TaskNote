using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskNote.Entity.FrameworkCore
{
    public interface IUserDbSet
    {
        public DbSet<UserEntity> Users { get; }
    }

    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Password).HasColumnName("password");
            builder.Property(p => p.SexId).HasColumnName("sex_id");

            builder
                .HasOne(user => user.SexEntity)
                .WithMany(sex => sex.UserEntities)
                .HasForeignKey(user => user.SexId)
                ;
        }
    }
}
