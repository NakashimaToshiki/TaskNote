using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskNote.Models.VerificationModels;

namespace TaskNote.Platform.Tests
{
    public class UserInfoViewModelTest
    {
        [Test]
        public async ValueTask 成功()
        {
            // Arrange
            var provider = new ServiceCollection().UseTest().BuildServiceProvider();

            // Act
            var viewModel = provider.GetRequiredService<UserInfoViewModel>();
            viewModel.UserId = "abc";
            viewModel.Password = "a";

            // Assert
            var model = await viewModel.CheckVertification();
            Assert.Pass();
        }

        [Test]
        public async ValueTask 入力なしのため失敗()
        {
            // Arrange
            var provider = new ServiceCollection().UseTest().BuildServiceProvider();

            // Act
            var viewModel = provider.GetRequiredService<UserInfoViewModel>();

            // Assert
            Assert.IsTrue(await viewModel.CheckVertification() is VerificationErrorModel);
        }
    }
}
