using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace TaskNote.BackEnd.Entity.FrameworkCore.SqlServer
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
            // 下記の接続文字はAuzre上のデータベースをVisualStudioのNugetでマイグレーションしたい場合にコメントインします。
            // 正しい方法はCI/CDでデプロイ時にデータベースのマイグレーションが発生すべきなので一時的な利用方法として認識して下さい。
            //optionsBuilder.UseSqlServer("@Data Source=tasknote.database.windows.net;Initial Catalog=TaskNote.Server_db;User ID=admin;Password=abcdefg");
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Database"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
