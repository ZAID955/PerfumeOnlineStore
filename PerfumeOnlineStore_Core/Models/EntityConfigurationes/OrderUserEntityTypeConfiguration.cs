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
    public class OrderUserEntityTypeConfiguration : IEntityTypeConfiguration<OrderUser>
    {
        public void Configure(EntityTypeBuilder<OrderUser> builder)
        {
            #region OrderUser Table
            builder.ToTable("OrderUsers");
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