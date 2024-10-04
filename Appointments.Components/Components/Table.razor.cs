using Appointments.Shared.Attributes;
using Microsoft.AspNetCore.Components;

namespace Appointments.Components.Components
{
    public partial class Table<T> : ComponentBase
    {
        [Parameter]
        public List<T> ModelList { get; set; }

        [Parameter]
        public int ColumnCount { get; set; }

        public List<string> GetHeads()
        {
            T model = ModelList.First();
            var properties = typeof(T).GetProperties().Where(x => x.GetShowInfo()).ToList();

            return properties.Select(x => x.Name).ToList();
        }
    }
}
