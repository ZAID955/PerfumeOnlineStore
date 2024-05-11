using Microsoft.EntityFrameworkCore;
using PerfumeOnlineStore_Core.Dtos.Client.Account;
using PerfumeOnlineStore_Core.Dtos.Delivery;
using PerfumeOnlineStore_Core.Dtos.Supplier;
using PerfumeOnlineStore_Core.Models.Context;
using PerfumeOnlineStore_Core.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Infra.ReposImplementationes
{
    public class SupplierRepos
    {
        private readonly PerfumeOnlineStoreDbContext _context;
        public SupplierRepos(PerfumeOnlineStoreDbContext context)
        {
            _context = context;
        }

        #region 
        public async Task<int> CreateAccountToSupplier(RegistrationSupplierDTO dto)
        {

            var result = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email
                                                                        || x.PhoneNumber == dto.PhoneNumber
                                                                        && x.UserType == UserType.Supplier);
            if (result != null)
            {
                if (result.PhoneNumber != null && result.Email != null)
                {
                    throw new ArgumentException("The Supplier PhoneNumber is already in use.");
                    throw new ArgumentException("The Supplier Email is already in use.");
                }
                else if (result.PhoneNumber != null && result.Email == null)
                {
                    throw new ArgumentException("The Supplier PhoneNumber is already in use.");
                }
                else if (result.PhoneNumber == null && result.Email != null)
                {
                    throw new ArgumentException("The Supplier Email is already in use.");
                }
                return 0;
            }
            else
            {
                var newSupplier = new User
                {
                    PhoneNumber = dto.PhoneNumber,
                    Email = dto.Email,
                    Password = dto.Password,
                    ConfirmPassword = dto.ConfirmPassword,
                    CompanyAddress = dto.CompanyAddress,
                    CompanyCity = dto.CompanyCity,
                    CompanyName = dto.CompanyName,
                    


                };
                newSupplier.UserType = UserType.Supplier;
                await _context.Users.AddAsync(newSupplier);
                await _context.SaveChangesAsync();
                return newSupplier.Id;
            }
        }
        public async Task<int> Login(LoginDTO dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email
                                                                && u.Password == dto.Password);
            if (user == null)
            {
                throw new KeyNotFoundException("UserName or Password Incorrect ");
            }
            return user.Id;
        }
        public async Task<int> UpdateProfile(UpdateProfileSupplierDTO dto)
        {
            var supplier = await _context.Users.FindAsync(dto.Id);

            if (supplier != null)
            {
                if (supplier.PhoneNumber == dto.PhoneNumber && supplier.Email == dto.Email)
                {
                    throw new ArgumentException("The Supplier PhoneNumber is already in use.");
                    throw new ArgumentException("The Supplier Email is already in use.");
                }
                else if (supplier.PhoneNumber == dto.PhoneNumber && supplier.Email != dto.Email)
                {
                    throw new ArgumentException("The Supplier PhoneNumber is already in use.");
                }
                else if (supplier.PhoneNumber != dto.PhoneNumber && supplier.Email == dto.Email)
                {
                    throw new ArgumentException("The Supplier Email is already in use.");
                }
                else
                {
                    supplier.PhoneNumber = dto.PhoneNumber;
                    supplier.Email = dto.Email;
                    supplier.CompanyAddress = dto.CompanyAddress;
                    supplier.CompanyCity = dto.CompanyCity;
                    supplier.CompanyName = dto.CompanyName;


                    return await _context.SaveChangesAsync();
                }
            }
            else
            {
                throw new ArgumentException("Supplier not found");
            }
        }
        public async Task<User> GetSupplierById(int SupplierId)
        {
            var result = new User();
            var selectUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == SupplierId
                                                                        && x.UserType == UserType.Supplier);
            result.Id = SupplierId;
            result.IsActive = selectUser.IsActive;
            result.CreationDateTime = selectUser.CreationDateTime;
            result.Email = selectUser.Email;
            result.PhoneNumber = selectUser.PhoneNumber;
            result.CompanyAddress = selectUser.CompanyAddress;
            result.CompanyCity = selectUser.CompanyCity;
            result.CompanyName = selectUser.CompanyName;


            return result;
        }
        #endregion
    }
}
