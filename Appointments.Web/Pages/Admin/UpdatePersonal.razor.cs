using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using Appointments.Domain.Models;
using Appointments.Utility;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace Appointments.Web.Pages.Admin
{
    public partial class UpdatePersonal : ComponentBase
	{
        private User User { get; set; } = new User();
		private List<UserRoleType> RoleOptions => Enum.GetValues(typeof(UserRoleType)).Cast<UserRoleType>().ToList();

		protected override Task OnInitializedAsync()
		{
			
		}
		private async Task CreateAsync()
        {
            User.CreateDate = DateTime.Now;
            CreateUserRequest request = new CreateUserRequest
            {
                User = User,
                RequesterId = Guid.Empty
            };

            try
            {
                var response = await NetworkManager.SendAsync<CreateUserRequest, CreateUserResponse>(request);
                ShowMessage(ToastType.Primary , $"{User.Name} {User.Surname} Personeli Başarılı Şekilde Eklendi");
            }
            catch (Exception e)
            {

                ShowMessage(ToastType.Primary, e.ToString());
                throw;
            }

            //ObjectWriter.Write(User);
        }
		List<ToastMessage> messages = new List<ToastMessage>();

		private void ShowMessage(ToastType toastType, string message) => messages.Add(CreateToastMessage(toastType, message));


		private ToastMessage CreateToastMessage(ToastType toastType, string text)
        => new ToastMessage
        {
            Type = toastType,
            Title = "Blazor Bootstrap",
            HelpText = $"{DateTime.Now}",
            Message = text,
        };

    }
}
