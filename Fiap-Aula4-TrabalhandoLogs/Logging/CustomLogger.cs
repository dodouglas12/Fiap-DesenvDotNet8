
namespace Fiap_Aula4_TrabalhandoLogs.Logging
{
    public class CustomLogger : ILogger
    {
        public static bool Arquivo { get; set; } = false;
        private readonly string loggerName;
        private readonly CustomLoggerProviderConfiguration loggerConfig;

        public CustomLogger(string loggerName, CustomLoggerProviderConfiguration loggerConfig)
        {
            this.loggerName = loggerName;
            this.loggerConfig = loggerConfig;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string mensagem = string.Format($"{logLevel}: {eventId.Id} - {formatter(state, exception)}");

            if (Arquivo)
                EscreverTextoNoArquivo(mensagem);
            if (logLevel.Equals(LogLevel.Information))
                Console.WriteLine(mensagem);
        }

        private void EscreverTextoNoArquivo(string mensagem)
        {
            string caminhoArquivoLog = Environment.CurrentDirectory + @$"\LOG-{DateTime.Now:yyyy-MM-dd}.txt";

            if (!File.Exists(caminhoArquivoLog))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(caminhoArquivoLog));
                File.Create(caminhoArquivoLog).Dispose();
            }

            using StreamWriter streamWriter = new(caminhoArquivoLog, true);
            streamWriter.WriteLine(mensagem);
            streamWriter.Close();
        }
    }
}
