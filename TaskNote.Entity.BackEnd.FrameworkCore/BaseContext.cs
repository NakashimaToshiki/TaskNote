﻿using Microsoft.EntityFrameworkCore;

namespace TaskNote.Entity.FrameworkCore
{
    public abstract class BaseContext : DbContext, ITaskDbSet, IClientTraceLogDbSet, IUserDbSet
    {
        public DbSet<TaskEntity> Tasks { get; set; }

        public DbSet<ClientTraceLogEntity> ClientTraceLogs { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new ClientTraceLogMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
