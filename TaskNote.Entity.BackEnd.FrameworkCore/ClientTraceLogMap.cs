using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskNote.BackEnd.Entity.ClientTraceLogs;

namespace TaskNote.Entity.FrameworkCore
{
    public interface IClientTraceLogDbSet : IUserDbSet
    {
        public DbSet<ClientTraceLogEntity> ClientTraceLogs { get; }
    }

    public class ClientTraceLogMap : IEntityTypeConfiguration<ClientTraceLogEntity>
    {
        public void Configure(EntityTypeBuilder<ClientTraceLogEntity> builder)
        {
            builder.ToTable("client_trace_logs");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(p => p.UserId).HasColumnName("user_id");
            builder.Property(p => p.Content).HasColumnName("content");
            builder.Property(p => p.CreateDate).HasColumnName("create_date");
        }
    }
}
