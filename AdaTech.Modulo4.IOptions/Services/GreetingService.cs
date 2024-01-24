using Microsoft.Extensions.Options;
using AdaTech.Modulo4.IOptions.Options; // Assumindo que GreetingOptions está dentro do namespace Options

namespace AdaTech.Modulo4.IOptions.Services
{
    public class GreetingService
    {
        private readonly IOptions<GreetingOptions> _options;

        public GreetingService(IOptions<GreetingOptions> options)
        {
            _options = options;
        }

        public string Greet(string name)
        {
            return $"{_options.Value.Greeting}{name}";
        }

        public string Farewell(string name)
        {
            return $"{_options.Value.Farewell}{name}";
        }
    }