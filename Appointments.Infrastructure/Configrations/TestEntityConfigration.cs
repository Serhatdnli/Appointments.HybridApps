using Appointments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointments.Infrastructure.Configrations
{
    public class TestEntityConfigration : BaseEntityConfiguration<Test>
    {

        public override void Configure(EntityTypeBuilder<Test> builder)
        {
            base.Configure(builder);
            builder.ToTable("Tests");
        }
    }
}
