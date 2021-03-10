using Microsoft.EntityFrameworkCore;
using System;
using TaskNote.Strage;

namespace TaskNote.Database.EntityFramework.InMemory
{
    public class TaskNoteInMemoryContext : TaskNoteDbContext
    {
        private readonly IStoragePath _storagePath; // ここライブラリに置き換えられるかも

        public TaskNoteInMemoryContext(IStoragePath storagePath, DbContextOptions options) : base(options)
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
