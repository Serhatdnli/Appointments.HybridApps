﻿using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;
using Azure;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;


namespace Appointments.Web.Pages
{
	public partial class GetAllPersonal : ComponentBase
	{
		private GetAllUsersCountRequest getAllUsersCountRequest;
		private GetAllUserRequest getAllUserRequest;


		private GetAllUsersCountResponse getAllUsersCountResponse;
		private GetAllUsersResponse getAllUsersResponse;


		int currentPage = 0;
		int lastPage = -1;
		int totalData = -1;
		int dataPerPage = 10;
		

		[Inject]
		public IHttpClientFactory _httpClientFactory { get; set; }

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

		protected override void OnInitialized()
		{
			SetUsersCountAsync();
		}

		private async void SetUsersCountAsync()
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
			StateHasChanged();
		}

		private void GoToPage(int page)
		{
			currentPage = page;
			Console.WriteLine("[BOYRAZ] SAYFAYA GİDİLİYOR, CURRENT PAGE: " + currentPage);
			GetPersonalByPage();
			StateHasChanged();
		}

		private async Task<GridDataProviderResult<User>> PersonalsDataProvider(GridDataProviderRequest<User> request)
		{

			await GetPersonalByPage();

			return new GridDataProviderResult<User>
			{
				Data = getAllUsersResponse.Users, // Kullanıcı verileri
				TotalCount = getAllUsersResponse.Users.Count // Eğer toplam sayıyı API'den alıyorsanız, bunu güncelleyin
			};
		}


	}
}
