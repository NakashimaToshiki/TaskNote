using Microsoft.EntityFrameworkCore;
using System;

namespace TaskNote.Entity.FrameworkCore.InMemory
{
    public class TaskNoteInMemoryContext : TaskNoteDbContext
    {
        private readonly IFileInfoFacade _fileInfoFacade; // ここライブラリに置き換えられるかも

        public TaskNoteInMemoryContext(IFileInfoFacade fileInfoFacade, DbContextOptions options) : base(options)
        {
            _fileInfoFacade = fileInfoFacade ?? throw new ArgumentNullException(nameof(fileInfoFacade));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(_fileInfoFacade.Database);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
