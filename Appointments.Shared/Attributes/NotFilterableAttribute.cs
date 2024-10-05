namespace Appointments.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]

    public class NotFilterableAttribute: Attribute
    {
        public NotFilterableAttribute()
        {
        }
    }
}
