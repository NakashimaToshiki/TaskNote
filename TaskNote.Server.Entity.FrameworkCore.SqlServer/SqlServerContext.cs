using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace TaskNote.Server.Entity.FrameworkCore.SqlServer
{
    public class SqlServerContext : BaseContext
    {
        private readonly IConfiguration _configuration;

        public SqlServerContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Database"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
