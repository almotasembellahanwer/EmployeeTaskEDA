using EmployeeTask.Aggregator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTask.Aggregator.EntitiesConfig;
public class AreaConfiguration : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder
            .HasKey(a => a.AreaID);

        builder
            .Property(a => a.EnglishName)
            .HasMaxLength(40)
            .IsRequired();
        builder
            .Property(a => a.ArabicName)
            .HasMaxLength(40)
            .IsRequired();
        builder
           .HasOne(a => a.Governorate)
           .WithOne()
           .HasForeignKey<Area>(a => a.GovernorateID)
           .IsRequired(false);
        builder.ToTable("Areas");
    }
}
