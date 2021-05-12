using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using TaskNote.Logging;

namespace TaskNote.Http.Client.Tests
{
    public class AuthServiceTests
    {
        [Test]
        public void 認証テスト()
        {
            // Arrange
            var provider = new ServiceCollection().UseTest().BuildServiceProvider();

            // Act
            var logger = provider.GetRequiredService<ILogger>();
            var sut = provider.GetRequiredService<IAuthService>();

            logger.LogWarning(new TaskNoteException(new AssertionException("1", new System.Exception("2", new System.Exception("3")))));
            logger.LogWarning(new TaskNoteException("ddddd"));
            logger.LogInformation("abc");

            // Assert
            sut.GetAuthentication();

            Assert.Pass();
        }
    }
}