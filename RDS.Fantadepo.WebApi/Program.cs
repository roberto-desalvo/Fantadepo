
using Microsoft.EntityFrameworkCore;
using RDS.Fantadepo.WebApi.Business.Utilities;
using RDS.Fantadepo.DataAccess;
using RDS.Fantadepo.DataAccess.Utilities;
using RDS.Fantadepo.WebApi.Business.Utilities.Extensions;
using RDS.Fantadepo.WebApi.Business.Models.Mappings;

namespace RDS.Fantadepo.WebApi
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
            builder.Services.AddSwaggerGen();


            builder.Services.AddBusinessServices();
            builder.Services.AddAutoMapper(x => x.AddProfile<WebApiBusinessProfile>());


            builder.Services.AddDbContext<FantadepoContext>(opt =>
            {
                opt.UseSqlServer(AzureHelper.GetEntraIdConnectionString());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
