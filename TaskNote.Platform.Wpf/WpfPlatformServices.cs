using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Platform.Wpf
{
    public class WpfPlatformServices : IPlatformServices
    {
        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddSingleton<IMessageBox, MessageBoxDialog>()
                .AddSingleton<IMainWindow>(_ => _.GetService<MainWindow>())
                .AddSingleton<IUserInfoView, UserInfoDialog>()
                .AddSingleton<MainWindow>()
                .AddSingleton<TaskListBox>()
                .AddSingleton<ITaskListBox>(_ => _.GetService<TaskListBox>())
            ;
    }
}
