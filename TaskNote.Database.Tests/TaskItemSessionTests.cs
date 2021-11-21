using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using TaskNote.Entity.Sessions;

namespace TaskNote.Entity.Tests
{
    public class TaskItemSessionTests
    {
        [Test]
        public async Task データベースにタスクを追加する()
        {
            // Arrange
            var provider = new ServiceCollection().UseTest().BuildServiceProvider();

            // Act
            var sut = provider.GetRequiredService<ITaskItemSession>();
            var logger = provider.GetRequiredService<ILogger>();

            await sut.Add(new TaskEntity()
            {
                Id = 1,
                CreatedDate = DateTime.MinValue,
                Title = "title",
                Description = "description"
            });
            var a = await sut.GetById(1);
            logger.LogInformation("TaskItem = {TaskItem}", a);

            // Assert


            Assert.Pass();
        }
    }
}