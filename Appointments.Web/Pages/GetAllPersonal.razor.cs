using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;
using Azure;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Appointments.Web.Pages
{
	public partial class GetAllPersonal : ComponentBase
	{
		private GetAllUsersCountRequest getAllUsersCountRequest;
		private GetAllUserRequest getAllUserRequest;
		private DeleteUserWithUserIdRequest deleteUserWithUserIdRequest;

		private GetAllUsersCountResponse getAllUsersCountResponse;
		private DeleteUserWithUserIdResponse deleteUserWithUserIdResponse;
		private GetAllUsersResponse getAllUsersResponse = new GetAllUsersResponse { Users = new List<User> { 
		} };

		[Inject]
		public IHttpClientFactory _httpClientFactory { get; set; }
		[Inject]
		private IJSRuntime jsRuntime { get; set; }

		int currentPage = 0;
		int lastPage = -1;
		int totalData = -1;
		int dataPerPage = 10;
		int curDataOrder = 0;


		private async Task GetPersonalByPage()
		{
			Console.WriteLine("Kullanıcılar çekiliyor");
			var httpClient = _httpClientFactory.CreateClient();
			getAllUserRequest = new GetAllUserRequest
			{
				Count = dataPerPage,
				Index = currentPage * dataPerPage,
				RequesterId = Guid.Empty
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

		protected override async Task OnInitializedAsync()
		{
			
			await GoToPage(currentPage);
		}

		private async Task SetUsersCountAsync()
		{
			var httpClient = _httpClientFactory.CreateClient();
			getAllUsersCountRequest = new GetAllUsersCountRequest
			{
				RequesterId = Guid.Empty
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
					lastPage = totalData % dataPerPage == 0 ? totalData / dataPerPage - 1: totalData / dataPerPage;
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
	
		private async Task ConfirmDelete(User user)
		{
			var confirmed = await jsRuntime.InvokeAsync<bool>("confirm", user.Name + " " + user.Surname + " Kullanıcısını Silmek İstedğinize Emin misiniz?");
			if (confirmed)
			{
				Console.WriteLine("evete tıkladı. kullanıcı :" +user.Name + " "+ user.Surname + "id : " + user.Id );
				
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
					GoToPage(currentPage);
				}
			}
		}
		private async Task GoToPage(int page)
		{
			await SetUsersCountAsync();

			if(page > lastPage)
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
