using Microsoft.Extensions.Options;
using AdaTech.Modulo4.IOptions;
using AdaTech.Modulo4.IOptions.Services;

namespace AdaTech.Modulo4.IOptions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<GreetingOptions>(builder.Configuration.GetSection("GreetingConfig"));
            builder.Services.AddSingleton<GreetingService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            if (args.Length > 0)
            {
                var command = args[0].ToLowerInvariant();
                var name = args.Length > 1 ? args[1] : "usuário";
                var greetings = app.Services.GetRequiredService<IOptions<GreetingOptions>>().Value;

                string message = command switch
                {
                    "saudacao" => $"{greetings.Greeting}{name}",
                    "despedida" => $"{greetings.Farewell}{name}",
                    _ => "O programa será encerrado"
                };

                Console.WriteLine(message);
            }

            app.Run();
        }
    }

    public class GreetingOptions
    {
        public string Greeting { get; set; }
        public string Farewell { get; set; }
    }
}
