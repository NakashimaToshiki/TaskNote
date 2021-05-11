using Microsoft.Extensions.DependencyInjection;

namespace TaskNote
{
    public interface IOptionsServices
    {
        void Configure(IServiceCollection services);
    }

    public class OptionsServices : IOptionsServices
    {
        public void Configure(IServiceCollection services)
        {
            services.AddSingleton<IUserOptions, UserOptions>();
            services.AddSingleton<IDateTimeOptions, DateTimeOptions>();
        }
    }
}
