using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using TaskNote.Database.TaskItems;

namespace TaskNote.Database.EntityFramework
{
    /// <summary>
    /// タスクテーブルにアクセスするプロパティを定義します。
    /// </summary>
    public interface ITaskItemDbSet
    {
        public DbSet<TaskItem> TaskItems { get; }
    }

    public class TaskItemMap : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.ToTable("tasks");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(p => p.UpdateData).HasColumnName("updateData").HasColumnType(nameof(SqlDbType.DateTime2));
            builder.Property(p => p.Title).HasColumnName("title");
            builder.Property(p => p.Description).HasColumnName("description");
        }
    }
}
