using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TaskNote.Server.Entity.ClientTraceLogs;
using TaskNote.Server.Entity.Users;

namespace TaskNote.Server.Entity.FrameworkCore
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
        }
    }
}
