
using Weather.Delegate;
using Weather.Infrastructure;
using Weather.Service;

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
            builder.Services.AddSingleton<IWeatherApplicationService, WeatherApplicationService>();
            builder.Services.AddSingleton<IServiceProvider<AdministrativeService>, AdministrativeServiceProvider>();
            builder.Services.AddTransient<ServiceFactory<OpenmeteoService, string>>(
                sp => (url) =>
                {
                    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
                    var client = clientFactory.CreateClient();
                    var httpservice = new HttpService(url, client);

                    return new OpenmeteoService(httpservice);
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
