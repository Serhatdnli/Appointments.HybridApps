using Appointments.Utility;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Appointments.Web
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");
			builder.RootComponents.Add<HeadOutlet>("head::after");

			builder.Services.AddBlazorBootstrap();
		

			builder.Services.AddHttpClient();


			HandlerGenerator.Generate("Ilhan", "", "");

			await builder.Build().RunAsync();
		}
	}
}
