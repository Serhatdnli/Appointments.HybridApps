namespace Appointments.Application.MediatR.Responses
{
    public class MediatRBaseResponse
    {
		public HttpResponseMessage message { get; set; }
		public string ErrorMessage { get; set; } // Hata mesajı
		public int? ErrorCode { get; set; } // Hata kodu
	}
}
