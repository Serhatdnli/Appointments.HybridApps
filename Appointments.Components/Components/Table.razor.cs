using Appointments.Utility;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Components.Components
{
	public partial class Table<T> : ComponentBase
	{
		[Parameter]
		public List<T> ModelList { get; set; }

		[Parameter]
		public EventCallback<T> DeleteMethod { get; set; }

		[Parameter]
		public EventCallback ApplyFilterMethod { get; set; }

		[Parameter]
		public T FilterItem { get; set; }

		[Parameter]
		public int ColumnCount { get; set; }

		[Parameter]
		public bool isUpdateButton { get; set; }

		[Parameter]
		public string UpdatePath { get; set; }

		[Parameter]
		public bool isDeleteButton { get; set; } = false;

		[Parameter]
		public bool isPagination { get; set; } = false;

		[Parameter]
		public bool isFilter { get; set; }

		private bool isOperationArea => isDeleteButton || isUpdateButton;

	

		protected override void OnParametersSet()
		{
			if (isUpdateButton && string.IsNullOrEmpty(UpdatePath))
			{
				throw new ArgumentException("\n\nUpdateButton görüntülensin istedin ama updatePath değeri girmedin, {örnek : '/admin/updatePersonal'}\n\n");
			}

			if (isDeleteButton && !DeleteMethod.HasDelegate)
			{
				throw new ArgumentException("\n\nDelete butonu ekledin ama deleteMethod parametresini boş geçtin\n\n");
			}
		}

		private void UpdateEnumValue(string propertyName, string selectedValue)
		{
			var enumType = typeof(T).GetProperty(propertyName).PropertyType;
			if (Enum.TryParse(enumType, selectedValue, out var enumValue))
			{
				typeof(T).GetProperty(propertyName).SetValue(FilterItem, enumValue);
				//ObjectWriter.Write(FilterItem);
			}
		}

		private void UpdateProperty(string propertyName, object value)
		{
			var propertyInfo = typeof(T).GetProperty(propertyName);
			if (propertyInfo != null)
			{
				propertyInfo.SetValue(FilterItem, value);
				//ObjectWriter.Write(FilterItem);
			}
		}
	}
}
