
using Weather.Appliction;
using Weather.Delegate;
using Weather.Domain;
using Weather.Domain.Service;
using Weather.Infrastructure;

namespace Weather
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            //µù¥UªA°È
            builder.Services.AddScoped<IWeatherApplication, WeatherApplication>();
            builder.Services.AddScoped<IWeatherApplicationService, WeatherApplicationService>();
            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddScoped<IServiceProvider<AdministrativeService>, AdministrativeServiceProvider>();
            builder.Services.AddTransient<ICoordinateFetcher, CoordinateFetcher>();
            builder.Services.AddScoped<IOpenmeteoServiceProvider, OpenmeteoServiceProvider>();
            builder.Services.AddTransient<IWeatherFetcher, WeatherFetcher>();
            builder.Services.AddTransient<HttpClientFactory<HttpService, string>>(
                sp => (url) =>
                {
                    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
                    var client = clientFactory.CreateClient();
                    new HttpService(url, client);

                    return new HttpService(url, client);
                }
                );
            builder.Services.AddHttpClient();

            var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
