using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;

namespace TaskNote.Http.Client.Tests
{
    public class AuthServiceTests
    {
        [Test]
        public void 認証テスト()
        {
            // Arrange
            var provider = new ServiceCollection().UseHttpTest().BuildServiceProvider();

            // Act
            var logger = provider.GetRequiredService<ILogger>();
            var sut = provider.GetRequiredService<IAuthService>();

            logger.LogWarning(new TaskNoteException(new AssertionException("1", new Exception("2", new Exception("3")))));
            logger.LogWarning(new TaskNoteException("ddddd"));
            logger.LogInformation("abc");

            // Assert
            sut.GetAuthentication();

            Assert.Pass();
        }
    }
}