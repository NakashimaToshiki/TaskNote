using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Platform.Wpf
{
    public class WpfPlatformServices : IPlatformServices
    {
        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddSingleton<MainWindow>()
                .AddSingleton<TaskListBox>()
                .AddSingleton<IMainWindow>(_ => _.GetService<MainWindow>())
                .AddSingleton<ITaskListBox>(_ => _.GetService<TaskListBox>())
                .AddSingleton<IMessageBox, MessageBoxDialog>()
            ;
    }
}
