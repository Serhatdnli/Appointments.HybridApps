using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Domain.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;


namespace Appointments.Web.Pages
{
	public partial class GetAllPersonal : ComponentBase
	{

		[Inject]
		public IHttpClientFactory _httpClientFactory { get; set; }
		private List<User> users;

		public int count = 0;


		protected override async Task OnInitializedAsync()
		{
			await GetAllPersonalsAsync();
		}

		private async Task GetAllPersonalsAsync()
		{
			var postRequest = new GetAllUserRequest
			{
				Count = 0, // İsteğe bağlı olarak sayfa boyutunu ayarlayın
				Index = 10, // Sayfa indeksini ayarlayın
				RequesterId = new Guid() // İlgili isteği yapacak kişi ID'si
			};

			var client = _httpClientFactory.CreateClient(); // HttpClient nesnesi oluşturuluyor


			var response = await client.PostAsJsonAsync("https://localhost:7235/api/User/GetAllUsers", postRequest);

			if (response.IsSuccessStatusCode)
			{
				var jsonResponse = await response.Content.ReadAsStringAsync();

				try
				{
					users = JsonSerializer.Deserialize<List<User>>(jsonResponse);
				}

				catch (JsonException ex)
				{
					throw new Exception("Deserialization hatası: " + ex.Message);
				}
			}

			count = users.Count;

			Console.WriteLine("userscount : " + count);

		}



		//private async Task<GridDataProviderResult<User>> PersonalsDataProvider(GridDataProviderRequest<User> request)
		//{
		//	var postRequest = new GetAllUserRequest
		//	{
		//		Count = 0, // İsteğe bağlı olarak sayfa boyutunu ayarlayın
		//		Index = 10, // Sayfa indeksini ayarlayın
		//		RequesterId = new Guid() // İlgili isteği yapacak kişi ID'si
		//	};

		//	var client = _httpClientFactory.CreateClient(); // HttpClient nesnesi oluşturuluyor


		//	var response = await client.PostAsJsonAsync("https://localhost:7235/api/User/GetAllPersonal", postRequest);

		//	if (response.IsSuccessStatusCode)
		//	{
		//		var users = await response.Content.ReadFromJsonAsync<List<User>>();
		//		return new GridDataProviderResult<User>
		//		{
		//			Data = users, // Kullanıcı verileri
		//			TotalCount = users.Count // Eğer toplam sayıyı API'den alıyorsanız, bunu güncelleyin
		//		};
		//	}
		//	else
		//	{
		//		throw new Exception("Hata: " + response.ReasonPhrase);
		//	}
		//}


	}
}
