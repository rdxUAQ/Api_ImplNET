namespace ApiImpl.Services {

    public class LoggerService
    {


        private readonly ILogger<ProductsService> _logger;

        public LoggerService(ILogger<ProductsService> logger)
        {
            _logger = logger;
        }
        public void LogInfo(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogError(string message, Exception ex)
        {
            _logger.LogError(ex, message);
        }

    }
}