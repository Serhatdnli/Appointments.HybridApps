using Appointments.Domain.Enums;
using Appointments.Domain.Models;

namespace Appointments.Application.FilterExtensions
{
    public static class UserFilterExtension
    {

        public static bool Find(this User user, Dictionary<UserFilterType, string> filter)
        {
            bool allConditions = true;
            foreach (var key in filter.Keys)
            {
                var value = filter[key];

                switch (key)
                {
                    case UserFilterType.Name:
                        allConditions = allConditions && user.Name.ToLower().Contains(value.ToLower());
                        break;
                    case UserFilterType.Surname:
                        allConditions = allConditions && user.Surname.ToLower().Contains(value.ToLower());
                        break;
                    case UserFilterType.Email:
                        allConditions = allConditions && user.Email.ToLower().Contains(value.ToLower());
                        break;
                    case UserFilterType.TcId:
                        allConditions = allConditions && user.TcId.ToLower().Contains(value.ToLower());
                        break;
                    case UserFilterType.PhoneNumber:
                        allConditions = allConditions && user.PhoneNumber.ToLower().Contains(value.ToLower());
                        break;
                    case UserFilterType.Role:
                        UserRoleType valueRoleType = Enum.Parse<UserRoleType>(value);
                        allConditions = allConditions && user.Role == valueRoleType;
                        break;
                    default:
                        break;
                }

                if (!allConditions)
                    break;
            }

            return allConditions;

        }

    }
}
