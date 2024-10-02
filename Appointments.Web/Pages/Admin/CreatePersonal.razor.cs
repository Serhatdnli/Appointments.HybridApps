using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using Appointments.Domain.Models;
using Appointments.Utility;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace Appointments.Web.Pages.Admin
{
    public partial class CreatePersonal : ComponentBase
	{
        private User User { get; set; } = new User();
		private List<UserRoleType> RoleOptions => Enum.GetValues(typeof(UserRoleType)).Cast<UserRoleType>().ToList();
		private async Task CreateAsync()
        {
            //User.CreateDate = DateTime.Now;
            //CreateUserRequest request = new CreateUserRequest
            //{
            //    User = User,
            //};

            try
            {
                //var response = await NetworkManager.SendAsync<CreateUserRequest, CreateUserResponse>(request);
                CreateToastMessage(ToastType.Primary, "Başarılı Şekilde Eklendi");
            }
            catch (Exception e)
            {

                CreateToastMessage(ToastType.Primary, e.ToString());
                throw;
            }

            //ObjectWriter.Write(User);
        }



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
