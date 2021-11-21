using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace TaskNote.Entity.FrameworkCore
{
    /// <summary>
    /// タスクテーブルにアクセスするプロパティを定義します。
    /// </summary>
    public interface ITaskItemDbSet
    {
        public DbSet<TaskEntity> TaskItems { get; }
    }

    public class TaskItemMap : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("tasks");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(p => p.UpdateDate).HasColumnName("updateData").HasColumnType(nameof(SqlDbType.DateTime2));
            builder.Property(p => p.CreatedDate).HasColumnName("createdData").HasColumnType(nameof(SqlDbType.DateTime2));
            builder.Property(p => p.Title).HasColumnName("title");
            builder.Property(p => p.Description).HasColumnName("description");
        }
    }
}
