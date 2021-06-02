using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace TaskNote.Configuration
{
    public class DatabaseConfigureOptions : IConfigureOptions<DatabaseOptions>
    {
        private readonly IConfiguration _configuration;

        private const string Key = "Database";

        public DatabaseConfigureOptions(IConfigurationRoot configuration)
        {
            _configuration = configuration.GetSection(DatabaseConfigureOptions.Key);
        }

        public void Configure(DatabaseOptions options)
        {
            LoadDefualtConfigureValues(options);
        }

        private void LoadDefualtConfigureValues(DatabaseOptions options)
        {
            if (options is null)
            {
                return;
            }

            options.Type = _configuration.GetValue<string>(nameof(options.Type));
        }
    }
}
