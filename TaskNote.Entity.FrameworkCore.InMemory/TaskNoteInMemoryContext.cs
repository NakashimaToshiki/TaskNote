using Microsoft.EntityFrameworkCore;
using System;

namespace TaskNote.Entity.FrameworkCore.InMemory
{
    public class TaskNoteInMemoryContext : TaskNoteDbContext
    {
        private readonly IDatabaseOptions _storagePath; // ここライブラリに置き換えられるかも

        public TaskNoteInMemoryContext(IDatabaseOptions storagePath, DbContextOptions options) : base(options)
        {
            _storagePath = storagePath ?? throw new ArgumentNullException(nameof(storagePath));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(_storagePath.DatabaseFilePath);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
