
using Newtonsoft.Json;
using RDS.Fantadepo.WebApi.Business.Mappings;
using RDS.Fantadepo.WebApi.Business.Utilities.Extensions;
using RDS.Fantadepo.WebApi.Business.Options;
using RDS.Fantadepo.WebApi.DataAccess.Options;
using RDS.Fantadepo.WebApi.DataAccess.Utilities;
using RDS.Fantadepo.WebApi.DataAccess;

namespace RDS.Fantadepo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add options
            builder.Services.Configure<ScoreOptions>(builder.Configuration.GetSection(nameof(ScoreOptions)));
            builder.Services.Configure<KeyVaultOptions>(builder.Configuration.GetSection(nameof(KeyVaultOptions)));

            // Add services to the container.
            builder.Services.AddBusinessServices();
            builder.Services.AddAutoMapper(x => x.AddProfile<WebApiBusinessProfile>());


            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                }); ;

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            var app = builder.Build();

            

            // enable swagger for deployment purpose
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
