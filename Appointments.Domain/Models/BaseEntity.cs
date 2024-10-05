using Appointments.Shared.Attributes;

namespace Appointments.Domain.Models
{
    public abstract class BaseEntity
    {
        [NotShow]
        [NotFilterable]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
