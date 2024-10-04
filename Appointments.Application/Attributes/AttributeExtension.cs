using Appointments.Application.MediatR.Requests;
using Appointments.Application.MediatR.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Attributes
{
    public  static partial class AttributeExtension
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
