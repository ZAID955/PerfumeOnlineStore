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
    public class CartItemEntityTypeConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            #region CartItem Table
            builder.ToTable("CartItems");
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

            #region Quantity
            builder.ToTable(x => x.HasCheckConstraint("CH_CartItem_Quantity", "Quantity >= 0"));
            builder.Property(x => x.Quantity)
                   .HasDefaultValue(0);
            #endregion

            #region Note
            builder.ToTable(x => x.HasCheckConstraint("CH_CartItem__Note", "LEN(Note) >0 "));
            builder.Property(x => x.Note)
                   .HasMaxLength(150);
            #endregion
        }
    }
}
