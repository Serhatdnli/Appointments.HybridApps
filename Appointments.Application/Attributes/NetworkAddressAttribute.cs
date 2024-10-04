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


}
