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
    public class ProductSizeEntityTypeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            #region ProductSize Table
            builder.ToTable("ProductSizes");
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

            #region Size
            builder.HasIndex(x => x.Size).IsUnique();
            builder.ToTable(x => x.HasCheckConstraint("CH_ProductSize_Size", "Size >= 0"));
            builder.Property(x => x.Size)
                   .HasDefaultValue(0);
            #endregion

        }
    }
}
