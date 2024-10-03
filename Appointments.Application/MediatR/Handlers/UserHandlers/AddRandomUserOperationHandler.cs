using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;
using MediatR;
using System.Text;

namespace Appointments.Application.MediatR.Handlers.UserHandlers
{
    public class AddRandomUserOperationHandler : IRequestHandler<AddRandomUserRequest, AddRandomUserResponse>
    {
        private readonly IUserRepository userRepository;

        public AddRandomUserOperationHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<AddRandomUserResponse> Handle(AddRandomUserRequest request, CancellationToken cancellationToken)
        {

            List<User> users = new();
            for (int i = 0; i < request.Count; i++)
            {
                User user = new User
                {
                    CreateDate = DateTime.Now,
                    Email = RastgeleStringUret(15),
                    Name = RastgeleStringUret(7),
                    Password = RastgeleStringUret(8),
                    PhoneNumber = RastgeleStringUret(13),
                    Role = Domain.Enums.UserRoleType.Personal,
                    Surname = RastgeleStringUret(10),
                    TcId = RastgeleStringUret(11)

                };

                users.Add(user);
            }


            await userRepository.AddRangeAsync(users, cancellationToken: cancellationToken);
            await userRepository.CompleteAsync(cancellationToken);


            return new AddRandomUserResponse();
        }

        string RastgeleStringUret(int uzunluk)
        {
            const string ingilizceKarakterler = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder sonuc = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < uzunluk; i++)
            {
                int index = random.Next(ingilizceKarakterler.Length);
                sonuc.Append(ingilizceKarakterler[index]);
            }

            return sonuc.ToString();
        }
    }
}
