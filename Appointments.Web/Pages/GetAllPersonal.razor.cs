using Appointments.Application.Filters;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using Appointments.Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;
using System.Data;
using System.Text.Json;

namespace Appointments.Web.Pages
{
	public partial class GetAllPersonal : ComponentBase
	{
		private GetAllUsersCountRequest getAllUsersCountRequest;
		private GetAllUserRequest getAllUserRequest;
		private DeleteUserWithUserIdRequest deleteUserWithUserIdRequest;

		private GetAllUsersCountResponse getAllUsersCountResponse;
		private DeleteUserWithUserIdResponse deleteUserWithUserIdResponse;
		private GetAllUsersResponse getAllUsersResponse = new GetAllUsersResponse
		{
			
			Users = new List<User>
			{
			}
		};

		private UserFilter UserFilter = new UserFilter();

		[Inject]
		public IHttpClientFactory _httpClientFactory { get; set; }
		[Inject]
		private IJSRuntime jsRuntime { get; set; }

		int currentPage = 0;
		int lastPage = -1;
		int totalData = -1;
		int dataPerPage = 10;
		int curDataOrder = 0;



		private IEnumerable<SelectListItem> RoleOptions => Enum.GetValues(typeof(UserRoleType))
		   .Cast<UserRoleType>()
		   .Select(role => new SelectListItem
		   {
			   Value = ((int)role).ToString(),
			   Text = role.ToString()
		   }).ToList();

		protected override async Task OnInitializedAsync()
		{

			await GoToPage(currentPage);
		}
		private async Task GetPersonalByPage()
		{
			Console.WriteLine("Kullanıcılar çekiliyor");
			var httpClient = _httpClientFactory.CreateClient();
			getAllUserRequest = new GetAllUserRequest
			{
				Count = dataPerPage,
				Index = currentPage * dataPerPage,
				RequesterId = Guid.Empty,
				userFilter = UserFilter
			};

			string jsonString = JsonSerializer.Serialize(getAllUserRequest);
			var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
			var response = await httpClient.PostAsync("https://localhost:7777/api/User/GetAllUsers", httpContent);

			if (response.IsSuccessStatusCode)
			{
				// Yanıt içeriğini oku
				var jsonResponse = await response.Content.ReadAsStringAsync();

				// JSON'u User listesine çevir

				try
				{
					getAllUsersResponse = JsonSerializer.Deserialize<GetAllUsersResponse>(jsonResponse);
				}
				catch (JsonException ex)
				{
					Console.WriteLine($"JSON Dönüşüm Hatası: {ex.Message}");
				}

				Console.WriteLine("----ISIMLER----");

				foreach (var user in getAllUsersResponse.Users)
				{
					Console.WriteLine($"User Name: {user.Name}");
				}
			}
			else
			{
				Console.WriteLine("Hata: " + response.ReasonPhrase);
			}

			var client = _httpClientFactory.CreateClient(); // HttpClient nesnesi oluşturuluyor
		}

	
		private async Task ApplyFilterAsync()
		{
			Console.WriteLine($"Name: {getAllUserRequest.userFilter.Name}");
			Console.WriteLine($"Surname: {getAllUserRequest.userFilter.Surname}");
			Console.WriteLine($"Email: {getAllUserRequest.userFilter.Email}");
			Console.WriteLine($"TC ID: {getAllUserRequest.userFilter.TcId}");
			Console.WriteLine($"Phone Number: {getAllUserRequest.userFilter.PhoneNumber}");
			Console.WriteLine($"Role: {getAllUserRequest.userFilter.Role}");
			Console.WriteLine($"Create Date: {getAllUserRequest.userFilter.CreateDate}");

			await GoToPage(0);
		}
		private async Task SetUsersCountAsync()
		{
			var httpClient = _httpClientFactory.CreateClient();
			getAllUsersCountRequest = new GetAllUsersCountRequest
			{
				RequesterId = Guid.Empty,
				userFilter = UserFilter
			};


			string jsonString = JsonSerializer.Serialize(getAllUsersCountRequest);
			var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
			var response = await httpClient.PostAsync("https://localhost:7777/api/User/GetAllUsersCount", httpContent);

			if (response.IsSuccessStatusCode)
			{
				// Yanıt içeriğini oku
				var jsonResponse = await response.Content.ReadAsStringAsync();

				// JSON'u User listesine çevir

				try
				{
					getAllUsersCountResponse = JsonSerializer.Deserialize<GetAllUsersCountResponse>(jsonResponse);
					totalData = getAllUsersCountResponse.UserCount;
					lastPage = totalData % dataPerPage == 0 ? totalData / dataPerPage - 1 : totalData / dataPerPage;
				}
				catch (JsonException ex)
				{
					Console.WriteLine($"JSON Dönüşüm Hatası: {ex.Message}");
				}
			}
			else
			{
				Console.WriteLine("Hata: " + response.ReasonPhrase);
			}

			Console.WriteLine("---[BOYRAZ] TOPLAM KİŞİ SAYISI ÇEKİLDİ. TOPLAM KİŞİ : " + totalData + " LASTPAGE : " + lastPage);
		}

		private void DateChanged(string createDate)
		{
			DateTime dateTimeValue;
			if (DateTime.TryParse(createDate, out dateTimeValue))
			{
				UserFilter.CreateDate = dateTimeValue;
			}
			else
			{
				// Hatalı tarih formatı
				Console.WriteLine("Geçersiz tarih formatı.");
			}

		}

		private void OnRoleChanged(string newRole)
		{
			if (Enum.TryParse(typeof(UserRoleType), newRole, out var role))
			{
				UserFilter.Role = (UserRoleType)role;
				Console.WriteLine($"Rol değişti: {newRole}");
			}
		}
		private async Task ConfirmDelete(User user)
		{
			var confirmed = await jsRuntime.InvokeAsync<bool>("confirm", user.Name + " " + user.Surname + " Kullanıcısını Silmek İstedğinize Emin misiniz?");
			if (confirmed)
			{
				Console.WriteLine("evete tıkladı. kullanıcı :" + user.Name + " " + user.Surname + "id : " + user.Id);

				var httpClient = _httpClientFactory.CreateClient();
				deleteUserWithUserIdRequest = new DeleteUserWithUserIdRequest
				{
					RequesterId = Guid.Empty,
					Id = user.Id,
				};


				string jsonString = JsonSerializer.Serialize(deleteUserWithUserIdRequest);
				var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
				var response = await httpClient.PostAsync("https://localhost:7777/api/User/DeleteUserWithUserId", httpContent);

				if (response.IsSuccessStatusCode)
				{
					await GoToPage(currentPage);
				}
			}
		}
		private async Task GoToPage(int page)
		{
			await SetUsersCountAsync();

			if (page > lastPage)
			{
				lastPage = page;
			}
			currentPage = page;
			Console.WriteLine("[BOYRAZ] SAYFAYA GİDİLİYOR, CURRENT PAGE: " + currentPage);
			await GetPersonalByPage();

			StateHasChanged();
		}
	}
}
public class SelectListItem
{
	public string Value { get; set; }
	public string Text { get; set; }
}