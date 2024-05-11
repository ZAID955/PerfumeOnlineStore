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
    public class ProductSectionEntityTypeConfiguration : IEntityTypeConfiguration<ProductSection>
    {
        public void Configure(EntityTypeBuilder<ProductSection> builder)
        {
            #region ProductSection Table
            builder.ToTable("ProductSections");
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
            builder.ToTable(x => x.HasCheckConstraint("CH_ProductSection__Name", "LEN(Name) >0 "));
            builder.Property(x => x.Name)
                   .HasMaxLength(150);
            #endregion
        }
    }
}
