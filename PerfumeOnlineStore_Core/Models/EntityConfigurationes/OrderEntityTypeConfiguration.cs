using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeOnlineStore_Core.Models.Entites;

namespace PerfumeOnlineStore_Core.Models.EntityConfigurationes
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            #region Order Table
            builder.ToTable("Orders");
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

            #region Address
            builder.ToTable(x => x.HasCheckConstraint("CH_Order__Address", "LEN(Address) >0 "));
            builder.Property(x => x.Address)
                   .HasMaxLength(150);
            #endregion



            #region TaxAmount
            builder.ToTable(x => x.HasCheckConstraint("Ch_Order_TaxAmount", "TaxAmount>=0"));
            builder.Property(x => x.TaxAmount)
                   .HasDefaultValue(0);
            #endregion

            #region NetPrice
            builder.ToTable(x => x.HasCheckConstraint("Ch_Order_NetPrice", "NetPrice>=0"));
            builder.Property(x => x.NetPrice)
                   .HasDefaultValue(1);
            #endregion

            #region DelievryPrice
            builder.ToTable(x => x.HasCheckConstraint("Ch_Order_DelievryPrice", "DelievryPrice>=3"));
            builder.Property(x => x.DelievryPrice)
                   .HasDefaultValue(3);
            #endregion

            #region DiscountAmount
            builder.ToTable(x => x.HasCheckConstraint("Ch_Order_DiscountAmount", "DiscountAmount>=0"));
            builder.Property(x => x.DiscountAmount)
                   .HasDefaultValue(0);
            #endregion


            //#region DelievryManPhone
            //builder.ToTable(x => x.HasCheckConstraint("Ch_Order_DelievryManPhone", "(len([DelievryManPhone])=(10) AND ([DelievryManPhone] like '079%' OR [DelievryManPhone] like '078%' OR [DelievryManPhone] like '077%'))"));
            //builder.Property(x => x.DelievryManPhone)
            //       .HasDefaultValue(1);
            //#endregion

        }
    }
}
