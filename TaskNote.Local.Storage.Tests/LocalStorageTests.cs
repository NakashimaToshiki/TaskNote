using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace TaskNote.Storage.Tests
{
    public class LocalStorageTests
    {
        [Test]
        public void �S�폜�e�X�g()
        {
            // Arrange
            var provider = new ServiceCollection().UseTest().BuildServiceProvider();

            // Act
            var sut = provider.GetRequiredService<ILocalStorage>();
            sut.AllDeleteApplication();

            // Assert
            Assert.Pass();
        }
    }
}