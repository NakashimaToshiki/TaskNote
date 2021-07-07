using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;

namespace TaskNote
{
    public static class LoggerExtentions
    {
        private static string GetText(string filePath, string memberName) => $"{System.IO.Path.GetFileNameWithoutExtension(filePath)}.{memberName}";

        public static void LogWarning(this ILogger me, Exception e, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
            => LoggerExtensions.LogWarning(me, e, GetText(filePath, memberName));

        public static void LogError(this ILogger me, Exception e, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
            => LoggerExtensions.LogError(me, e, GetText(filePath, memberName));

        public static void LogCritical(this ILogger me, Exception e, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
            => LoggerExtensions.LogCritical(me, e, GetText(filePath, memberName));
    }
}
