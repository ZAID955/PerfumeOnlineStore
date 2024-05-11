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
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            #region User Table
            builder.ToTable("Users");
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

            #region Email
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(d => d.Email)
                .IsRequired(true)
                .HasDefaultValue(true);
            builder.ToTable(x => x.HasCheckConstraint("CH_User_Email", "Email LIKE '%@gmail.com%' OR Email LIKE  '%@outlook.com%' OR Email LIKE '%@yahoo.com%'"));
            #endregion

            #region Password
            builder.Property(d => d.Password)
                .IsRequired(true);
            builder.ToTable(x => x.HasCheckConstraint("CH_User_Password", "LEN(Password) >= 8 AND LEN(Password) <= 16"));
            #endregion

            #region  ConfirmPassword
            builder.Property(d => d.ConfirmPassword)
                .IsRequired(true);
            builder.ToTable(x => x.HasCheckConstraint("CK_User_ConfirmPassword", "(Password = ConfirmPassword)"));
            #endregion

            #region PhoneNumber
            builder.HasIndex(x => x.PhoneNumber).IsUnique();
            builder.Property(x => x.PhoneNumber)
                .HasDefaultValue(false)
                .IsRequired(true);
            builder.ToTable(x => x.HasCheckConstraint("CH_User_PhoneNumber", "(LEN([PhoneNumber])=(10) AND ([PhoneNumber] LIKE '079%' OR [PhoneNumber] LIKE '078%' OR [PhoneNumber] LIKE '077%'))"));
            #endregion

            #region FirstName
            builder.Property(d => d.FirstName)
                .IsRequired(false)
                .HasMaxLength(30);
            #endregion

            #region SecondName
            builder.Property(d => d.FirstName)
                .IsRequired(false)
                .HasMaxLength(30);
            #endregion

            #region LastName
            builder.Property(d => d.LastName)
                .IsRequired(false)
                .HasMaxLength(30);
            #endregion 

            #region NationalNo 
            builder.Property(d => d.NationalNo)
                .IsRequired(false);
            builder.ToTable(x => x.HasCheckConstraint("CH_User_NationalNo", "LEN([NationalNo]) = (10) OR NationalNo IS NULL")); 
            #endregion

            #region CompanyName
            builder.Property(d => d.CompanyName)
                .IsRequired(false)
                .HasMaxLength(30);
            #endregion

            #region CompanyAddress
            builder.Property(d => d.CompanyAddress)
                .IsRequired(false)
                .HasMaxLength(30);
            #endregion

            #region CompanyCity
            builder.Property(d => d.CompanyCity)
                .IsRequired(false)
                .HasMaxLength(30);
            #endregion

            builder.HasMany(z => z.OrderUser)
            .WithOne(z => z.User).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
