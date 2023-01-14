using RootServiceReference;

namespace SampleService.Services.Impl
{
    public class RootServiceClient : IRootServiceClient
    {

        #region Services

        private readonly ILogger<RootServiceClient> _logger;
        private RootServiceReference.RootServiceClient _rootServiceClient;

        #endregion

        public RootServiceClient(HttpClient httpClient,
            ILogger<RootServiceClient> logger)
        {
            _logger = logger;
            _rootServiceClient = new RootServiceReference.RootServiceClient("http://localhost:5075/", httpClient);
        }

        public RootServiceReference.RootServiceClient Client => _rootServiceClient;

        public async Task<ICollection<RootServiceReference.WeatherForecast>> Get() => await _rootServiceClient.GetWeatherForecastAsync();
        
    }
}
