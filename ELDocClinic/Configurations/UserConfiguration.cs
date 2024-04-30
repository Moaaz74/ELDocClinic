using ELDocClinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ELDocClinic.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property<bool>("IsDeleted");
            builder.Property<DateTime>("CreatedAt");
            builder.Property<DateTime>("LastUpdatedAt");
            builder.HasDiscriminator<string>("Discriminator").HasValue("Patient");
        }
    }
}
