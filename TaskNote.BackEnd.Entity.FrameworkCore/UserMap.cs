using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TaskNote.BackEnd.Entity.ClientTraceLogs;
using TaskNote.BackEnd.Entity.Users;
using TaskNote.Users;

namespace TaskNote.BackEnd.Entity.FrameworkCore
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
