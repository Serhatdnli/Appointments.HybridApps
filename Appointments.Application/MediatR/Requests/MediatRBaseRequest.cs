using Appointments.Application.MediatR.Responses;
using MediatR;

namespace Appointments.Application.MediatR.Requests
{
    public class MediatRBaseRequest<TResponse> : IRequest<TResponse> where TResponse : MediatRBaseResponse
    {
        public Guid UserId { get; set; } = Guid.Empty;

    }

    public class MediatRBaseRequest : IRequest
    {
        public Guid UserId { get; set; } = Guid.Empty;
    }
}
