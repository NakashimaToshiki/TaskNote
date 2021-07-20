using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskNote.Server.Entity.Tasks;

namespace TaskNote.Server.Entity.FrameworkCore
{
    public interface ITaskDbSet : IUserDbSet
    {
        public DbSet<TaskEntity> Tasks { get; }
    }

    public class TaskMap : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("tasks");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(p => p.Title).HasColumnName("title");
            builder.Property(p => p.Description).HasColumnName("description");
            builder.Property(p => p.CreatedDate).HasColumnName("createdDate");
            builder.Property(p => p.UpdateDate).HasColumnName("updateData");
        }
    }
}
