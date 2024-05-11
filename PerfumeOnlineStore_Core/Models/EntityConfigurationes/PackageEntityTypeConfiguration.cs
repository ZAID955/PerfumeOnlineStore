using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PerfumeOnlineStore_Core.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Models.EntityConfigurationes
{
    public class PackageEntityTypeConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            #region Package Table
            builder.ToTable("Packages");
            #endregion

            #region Id 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            #endregion

            #region IsActive 
            builder.Property(x => x.IsActive)
                .IsRequired(true)
                .HasDefaultValue(true);
            #endregion

            #region CreationDateTime 
            builder.Property(x => x.CreationDateTime)
                .IsRequired(true)
                .HasDefaultValue(DateTime.Now);
            #endregion

            #region Name
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(d => d.Name)
                .IsRequired(true)
                .HasMaxLength(30);
            #endregion

            #region Quantity
            builder.ToTable(x => x.HasCheckConstraint("CH_Package_Quantity", "Quantity >= 0"));
            builder.Property(x => x.Quantity)
                   .HasDefaultValue(0);
            #endregion

            #region Price
            builder.ToTable(x => x.HasCheckConstraint("CH_Package__Price", "LEN(Price) > 0 "));
            builder.Property(x => x.Price)
                   .HasDefaultValue(1);
            #endregion

            #region Description
            builder.ToTable(x => x.HasCheckConstraint("CH_Package__Description", "LEN(Description) > 0 "));
            builder.Property(x => x.Description)
                   .HasMaxLength(150);
            #endregion
        }
    }
}
