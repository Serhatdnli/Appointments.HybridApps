using Appointments.Application.MediatR.Requests;
using Appointments.Application.MediatR.Responses;

namespace Appointments.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NetworkAddressAttribute : Attribute
    {
        public string Address;

        public NetworkAddressAttribute(string address)
        {
            this.Address = address;
        }


    }

    public static class NetworkAdressExtension
    {
        public static string GetNetworkAddress<T>(this MediatRBaseRequest<T> request) where T : MediatRBaseResponse
        {
            var type = request.GetType();

            var attributes = type.GetCustomAttributes(typeof(NetworkAddressAttribute), true);

            if (attributes.Length > 0)
            {
                var stringValueAttribute = (NetworkAddressAttribute)attributes[0];
                return stringValueAttribute.Address;
            }
            else
            {
                throw new Exception("Attribute Not Found");
            }

        }
    }
}
