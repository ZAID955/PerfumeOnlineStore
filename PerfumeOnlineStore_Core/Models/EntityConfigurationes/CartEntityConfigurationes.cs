using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeOnlineStore_Core.Models.Entites;

namespace PerfumeOnlineStore_Core.Models.EntityConfigurationes
{
    public class CartEntityTypeConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            #region Cart Table
            builder.ToTable("Carts");
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
        }
    }
}
