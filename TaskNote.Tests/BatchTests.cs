using System;
using Xunit;
using TaskNote.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using TaskNote.Batch;
using System.Threading;

namespace TaskNote.Tests
{
    public class BatchTests
    {
        [Fact]
        public async void Test1()
        {
            // Arrange
            var provider = new ServiceCollection()
                .AddSingleton<SynchronizationContext>(SynchronizationContext.Current)
                .AddTestDoubles()
                .BuildServiceProvider();

            // Act
            var sut = provider.GetService<IStartBatch>();
            await sut.Run();

            // Assert
            
        }
    }
}
