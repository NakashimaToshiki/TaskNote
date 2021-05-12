using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;
using TaskNote.Entity.TaskItems;
using System;
using Microsoft.Extensions.Logging;

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

            await sut.Add(new TaskItem(1, DateTime.MinValue, "title", "description"));
            var a = await sut.GetById(1);
            logger.LogInformation("TaskItem = {TaskItem}", a);

            // Assert


            Assert.Pass();
        }
    }
}