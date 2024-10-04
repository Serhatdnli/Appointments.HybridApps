namespace Appointments.Shared.Attributes
{
    public static partial class AttributeExtension
    {


        public static bool GetShowInfo<T>(this T obj)
        {
            var type = obj.GetType();

            var attributes = type.GetCustomAttributes(typeof(NotShowAttribute), true);

            return attributes.Length > 0;



        }
    }
}
