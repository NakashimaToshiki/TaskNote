using Microsoft.AspNetCore.Http;
using System;
using TaskNote.Options;

namespace TaskNote.Services
{
    public class UserOption : IUserOptions
    {
        private readonly ISession _httpSession;

        private const string userNameKey = "userName";
        private const string userIdKey = "userId";

        public UserOption(IHttpContextAccessor accessor)
        {
            if (accessor is null)
            {
                throw new ArgumentNullException(nameof(accessor));
            }

            _httpSession = accessor.HttpContext.Session;
        }

        public string UserName
        {
            get => _httpSession.GetString(userNameKey) ?? throw new UserOptionException($"{UserName}が存在しない");
            set => _httpSession.SetString(userNameKey, value);
        }

        public int UserId
        {
            get => _httpSession.GetInt32(userIdKey) ?? throw new UserOptionException($"{UserId}が存在しない");
            set => _httpSession.SetInt32(userIdKey, value);
        }
    }
}
