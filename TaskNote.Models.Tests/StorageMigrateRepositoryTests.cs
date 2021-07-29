using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;
using TaskNote.Models.Repositoris;

namespace TaskNote.Models.Tests
{
    public class StorageMigrateRepositoryTests
    {

        [Test]
        public void Test1()
        {
            // Arrange
            var provider = new ServiceCollection().UseTest().BuildServiceProvider();

            // Act
            var sut = provider.GetRequiredService<StorageMigrateRepository>();

            // Asset
            Assert.Pass();
        }
    }
}