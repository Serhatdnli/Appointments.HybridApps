using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Domain.Models;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;
namespace Appointments.Web.Areas.Pages
{
	public partial class GetAllPersonal
	{
		private List<User> Users = new List<User>();
	
	

		private async Task<GridDataProviderResult<User>> PersonalsDataProvider(GridDataProviderRequest<User> request)
		{
			var request2 = new GetAllUserRequest
			{
				Count = 10,
				Index = 0,
				RequesterId = new Guid()
			};


			using HttpClient httpClient = new HttpClient();

			try
			{


				string jsonString = JsonSerializer.Serialize(request2);
				var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
				var response = await httpClient.PostAsync("https://localhost:7235/api/User/GetAllUsers", httpContent);

				if (response.IsSuccessStatusCode)
				{
					// Yanıt içeriğini oku
					var jsonResponse = await response.Content.ReadAsStringAsync();
					Console.WriteLine($"JSON Yanıt: {jsonResponse}");

					// JSON'u User listesine çevir
					Users = JsonSerializer.Deserialize<List<User>>(jsonResponse);
					foreach (var user in Users)
					{
						Console.WriteLine($"User Name: {user.Name}");
					}
				}
				else
				{
					Console.WriteLine("Hata: " + response.ReasonPhrase);
				}
			}
			catch (HttpRequestException httpEx)
			{
				Console.WriteLine($"HTTP Hatası: {httpEx.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Hata: {ex.Message}");
			}
			StateHasChanged();
			return await Task.FromResult(request.ApplyTo(Users));
		}


	}
}
