using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNote.Entity.Sessions;
using TaskNote.Options;
using TaskNote.Entity;
using Microsoft.EntityFrameworkCore;

namespace TaskNote.JQruery.Services
{
    public class TaskService
    {
        private readonly IUserOptions _userOption;
        private readonly ITaskSession _dbSession;

        public TaskService(IUserOptions userOption, ITaskSession dbSession)
        {
            _userOption = userOption ?? throw new ArgumentNullException(nameof(userOption));
            _dbSession = dbSession ?? throw new ArgumentNullException(nameof(dbSession));
        }

        public async Task<IList<TaskShortModel>> GetShortTasks()
        {
            return await _dbSession.GetTasksByUserId("1");
            //_userOption.UserName = "user1";
            //_userOption.UserId = 1;
            //return await _dbSession.GetTasksByUserId(_userOption.UserId);
        }

        public async Task<TaskModel> GetByIdAsync(int id)
        {
            return await _dbSession.GetByIdAsync(id);
        }


        public async Task<bool> PostAsync(TaskModel input)
        {
            return await _dbSession.PostAsync(input);
        }
    }
}
