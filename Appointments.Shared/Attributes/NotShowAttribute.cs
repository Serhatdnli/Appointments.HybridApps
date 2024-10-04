namespace Appointments.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]

    public class NotShowAttribute : Attribute
    {

        public NotShowAttribute()
        {
        }
    }
}
