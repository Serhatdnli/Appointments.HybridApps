using Microsoft.AspNetCore.Components;

namespace Appointments.Components.Components
{
	public partial class FilterInput : ComponentBase
	{
		[Parameter]
		public Action<string, object> UpdatePropertyMethod {get;set;}

		[Parameter]
		public Action<string, string> UpdateEnumMethod { get; set; }

		[Parameter]
		public Type propType { get; set; }

		[Parameter]
		public string propertyName { get; set; }


	}
}
