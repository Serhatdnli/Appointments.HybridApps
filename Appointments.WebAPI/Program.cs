using Appointments.Application.MediatR.Registiration;
using Appointments.Infrastructure.Extensions;
using Newtonsoft.Json.Converters;


namespace Appointments.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllers()
						   .AddNewtonsoftJson(options =>
						   {
							   options.SerializerSettings.Converters.Add(new StringEnumConverter());
						   });

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


			builder.Services.AddInfrastructureRegistration(builder.Configuration);
			builder.Services.MediatRRegistiration();
			builder.Services.AutoMapperRegistration();

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAllOrigins",
					builder => builder
						.AllowAnyOrigin() // Tüm kaynaklardan eriþime izin verir
						.AllowAnyMethod() // Tüm HTTP yöntemlerine izin verir
						.AllowAnyHeader()); // Tüm baþlýklara izin verir
			});

			var app = builder.Build();

			app.UseCors("AllowAllOrigins");

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
