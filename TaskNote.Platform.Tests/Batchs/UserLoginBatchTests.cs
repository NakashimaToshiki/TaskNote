using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;
using TaskNote.Http.Client;
using TaskNote.Platform.Batchs;

namespace TaskNote.Platform.Tests.Batchs
{
    public class UserLoginBatchTests
    {
        [Test]
        public async Task ログインに成功する()
        {
            // Arrange
            var provider = new ServiceCollection().UseBatchTest().BuildServiceProvider();

            // Act
            var sut = provider.GetRequiredService<UserLoginBatch>();
            var ret = await sut.Run();

            // Assert
            Assert.IsTrue(ret);
        }

        [Test]
        public async Task ログインに失敗した場合はログインダイアログを開く()
        {
            // Arrange
            var provider = new ServiceCollection().UseBatchTest().BuildServiceProvider();
            var dialog = provider.GetService<SpyUserInfoView>();
            dialog.Result = UserInfoDialogResult.OK; // ここは普通にMoqでいいかも

            // Act
            var sut = provider.GetRequiredService<UserLoginBatch>();
            var ret = await sut.Run();

            // Assert
            Assert.IsTrue(ret);
        }

        // Configで必ずfalseが返るの

        /*
        [Test]
        public async Task 通信に失敗した場合は３回リトライをしてから通信環境が悪いメッセージを表示する()
        {
            // Arrange
            var provider = new ServiceCollection().UseBatchTest()
                .AddSpyAuthServiceInHttpClientException()
                .BuildServiceProvider();
            var dialog = provider.GetService<SpyUserInfoView>();
            dialog.Result = UserInfoDialogResult.OK; // ここは普通にMoqでいいかも

            // Act
            var sut = provider.GetRequiredService<UserLoginBatch>();
            await sut.Run();

            // Assert
            var spy = provider.GetService<SpyAuthService>();
            Assert.AreEqual(spy.GetAuthenticationCount, 3);
        }*/
    }

}
