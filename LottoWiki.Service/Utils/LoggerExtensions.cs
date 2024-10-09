using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace LottoWiki.Service.Utils
{
    public static class LoggerExtensions
    {
        public static void LogMethodWarning(this ILogger logger)
        {
            if (logger.IsEnabled(LogLevel.Warning))
            {
                string methodName = GetCurrentMethodName();
                logger.LogWarning("Um aviso foi disparado no método: {MethodName}", methodName);
            }
        }

        public static void LogMethodInfo(this ILogger logger)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                string methodName = GetCurrentMethodName();
                logger.LogInformation("Método {MethodName} foi acessado", methodName);
            }
        }

        public static void LogMethodInfo(this ILogger logger, string message)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                string methodName = GetCurrentMethodName();
                var msg = $"Método: {methodName} Msg: {message}";
                logger.LogInformation(msg);
            }
        }

        public static void LogMethodError(this ILogger logger)
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                string methodName = GetCurrentMethodName();
                logger.LogError("Houve um erro no método: {MethodName}", methodName);
            }
        }

        public static void LogMethodError(this ILogger logger, string message)
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                string methodName = GetCurrentMethodName();
                var msg = $"Método: {methodName} Msg: {message}";
                logger.LogError(msg);
            }
        }

        public static void LogWorkerInfo(this ILogger logger)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                string methodName = GetCurrentMethodName();
                logger.LogInformation("O worker: {MethodName} foi inicializado", methodName);
            }
        }

        private static string GetCurrentMethodName()
        {
            var stackTrace = new StackTrace(true);
            var frame = stackTrace.GetFrame(2);
            return frame?.GetMethod()?.Name ?? "Unknown Method";
        }
    }
}