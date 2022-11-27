using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class ContactInformationConfiguration: IEntityTypeConfiguration<ContactInformation>
    {
        public void Configure(EntityTypeBuilder<ContactInformation> builder)
        {
            builder.Property(ci => ci.ViberNumber)
                .HasMaxLength(400);

            builder.Property(ci => ci.TelegramName)
                .HasMaxLength(400);

            builder.Property(ci => ci.InstagramName)
                .HasMaxLength(400);

            builder
                .HasOne(ci => ci.User)
                .WithOne(u => u.ContactInformation);
        }
    }
}