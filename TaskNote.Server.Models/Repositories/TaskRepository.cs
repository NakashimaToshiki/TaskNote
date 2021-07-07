using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TaskNote.Server.Entity;
using TaskNote.Server.Models.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace TaskNote.Server.Models.Repositories
{
    public class TaskRepository
    {
        private readonly ILogger<TaskRepository> _logger;
        private readonly ITaskSession _session;
        private readonly TaskModelFactory _factory;

        public TaskRepository(ILogger<TaskRepository> logger, ITaskSession session, TaskModelFactory factory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _session = session ?? throw new ArgumentNullException(nameof(session));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public async ValueTask<TaskModel> Get(int id)
        {
            try
            {
                var entity = await _session.GetTaskById(id);
                return _factory.Create(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                return NullTaskModel.Instance;
            }
        }

        public async ValueTask<IEnumerable<TaskModel>> GetByUserName(string username)
        {
            try
            {
                var entities = await _session.GetTasksByUserName(username);
                return entities.Select(_ => _factory.Create(_));
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                return new TaskModel[0];
            }
        }

        public async ValueTask<bool> AddTask(string username, string title, string description)
        {
            try
            {
                var entities = await _session.GetTasksByUserName(username);
                return await _session.Add(username, title, description);
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                return false;
            }
        }
    }
}
