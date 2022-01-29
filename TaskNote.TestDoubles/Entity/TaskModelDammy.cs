using System;
using System.Collections.Generic;

namespace TaskNote.Entity
{
    public class TaskModelDammy
    {
        public IList<TaskModel> Dammys = new List<TaskModel>() {
            new TaskModel(){
                Id = 1,
                Title = "Title1",
                Description = "Description1",
                CreatedDate = DateTime.MinValue,
                UpdateDate = DateTime.MinValue,
                IsCompleted = false,
                UserId = "1",
            },
            new TaskModel(){
                Id = 2,
                Title = "Title2",
                Description = "Description3",
                CreatedDate = DateTime.MinValue,
                UpdateDate = DateTime.MinValue,
                IsCompleted = false,
                UserId = "1",
            },
            new TaskModel(){
                Id = 3,
                Title = "Title2",
                Description = "Description3",
                CreatedDate = DateTime.MinValue,
                UpdateDate = DateTime.MinValue,
                IsCompleted = false,
                UserId = "1",
            }
        };
    }
}
