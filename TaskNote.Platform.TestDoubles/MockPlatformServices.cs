using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace TaskNote.Platform
{
    public class MockPlatformServices : IPlatformServices
    {
        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddSingleton<IMessageBox>( _ => new Mock<IMessageBox>().Object)
                .AddSingleton<IMainWindow>(_ => new Mock<IMainWindow>().Object)
                .AddSingleton<ITaskListBox>(_ => new Mock<ITaskListBox>().Object)
                .AddSingleton<SpyUserInfoView>()
                .AddSingleton<IUserInfoView>(_ => _.GetService<SpyUserInfoView>())
                ;
    }
}
