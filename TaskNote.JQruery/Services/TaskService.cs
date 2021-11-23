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
            _userOption.UserName = "abcde";
            return await _dbSession.GetTasksByUserName(_userOption.UserName);
        }
    }
}
