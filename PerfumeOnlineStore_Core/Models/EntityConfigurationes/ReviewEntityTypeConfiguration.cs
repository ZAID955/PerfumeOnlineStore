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
    public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            #region Review Table
            builder.ToTable("Reviewes");
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

            #region Title 
            builder.ToTable(x => x.HasCheckConstraint("CH_Review__Title", "LEN(Title) > 0 "));
            builder.Property(x => x.Title)
                   .HasMaxLength(30);
            #endregion

            #region Rating 
            builder.ToTable(x => x.HasCheckConstraint("CH_Review_Rating", "Rating BETWEEN 1 AND 5"));
            builder.Property(x => x.Rating)
                   .HasDefaultValue(0);
            #endregion

            #region Comment 
            builder.ToTable(x => x.HasCheckConstraint("CH_Review__Comment", "LEN(Comment) > 0 "));
            builder.Property(x => x.Comment)
                   .HasMaxLength(150);
            #endregion
        }
    }
}
