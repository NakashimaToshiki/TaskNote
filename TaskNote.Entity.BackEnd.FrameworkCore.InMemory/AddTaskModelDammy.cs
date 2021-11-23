using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace TaskNote.Entity.FrameworkCore.InMemory
{
    public class AddTaskModelDammy : IDbContextAddDammy
    {
        private readonly TaskModelDammy _dammy;

        public AddTaskModelDammy(TaskModelDammy dammy)
        {
            _dammy = dammy ?? throw new ArgumentNullException(nameof(dammy));
        }

        public void AddDammy(ModelBuilder modelBuilder)
        {
            var items = _dammy.Dammys.Select(d =>new TaskEntity()
            {
                Id = d.Id,
                Title = d.Title,
                Description = d.Description,
                IsCompleted = d.IsCompleted,
                CreatedDate = d.CreatedDate,
                UpdateDate = d.UpdateDate,
                UserId = d.UserId
            }).ToArray();
            modelBuilder.Entity<TaskEntity>().HasData(items);
        }
    }
}
