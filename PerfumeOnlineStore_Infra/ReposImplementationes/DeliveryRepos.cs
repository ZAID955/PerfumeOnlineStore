
using Microsoft.EntityFrameworkCore;
using PerfumeOnlineStore_Core.Dtos.Client.Account;
using PerfumeOnlineStore_Core.Dtos.Delivery;
using PerfumeOnlineStore_Core.Dtos.Supplier;
using PerfumeOnlineStore_Core.Helper.Enums;
using PerfumeOnlineStore_Core.IRepos;
using PerfumeOnlineStore_Core.Models.Context;
using PerfumeOnlineStore_Core.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Infra.ReposImplementation
{
    public class DeliveryRepos : IDeliveryReposInterface
    {
        private readonly PerfumeOnlineStoreDbContext _context;
        public DeliveryRepos(PerfumeOnlineStoreDbContext context)
        {
            _context = context;
        }
        #region 
        public async Task<int> CreateAccountToDelivery(RegistrationDeliveryDTO dto)
        {

            var result = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email
                                                                        || x.PhoneNumber == dto.PhoneNumber
                                                                        && x.UserType == UserType.Delivery);
            if (result != null)
            {
                if (result.PhoneNumber != null && result.Email != null)
                {
                    throw new ArgumentException("The Delivery PhoneNumber is already in use.");
                    throw new ArgumentException("The Delivery Email is already in use.");
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
                var newDelivery = new User
                {
                    PhoneNumber = dto.PhoneNumber,
                    Email = dto.Email,
                    Password = dto.Password,
                    ConfirmPassword = dto.ConfirmPassword,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    SecondName = dto.SecondName,
                    Brithday = dto.Brithday,
                    Gendear = dto.Gendear,
                    DeliveryCar = dto.DeliveryCar,
                    DeliveryLicenseImageUrl = dto.DeliveryLicenseImageUrl,
                    NationalNo = dto.NationalNo,
                    Name = dto.Name,

                    
                };
                newDelivery.UserType = UserType.Delivery;
                await _context.Users.AddAsync(newDelivery);
                await _context.SaveChangesAsync();
                return newDelivery.Id;
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
        public async Task<int> UpdateProfile(UpdateProfileDeliveryDTO dto)
        {
            var delivery = await _context.Users.FindAsync(dto.Id);

            if (delivery != null)
            {
                if (delivery.PhoneNumber == dto.PhoneNumber && delivery.Email == dto.Email)
                {
                    throw new ArgumentException("The Delivery PhoneNumber is already in use.");
                    throw new ArgumentException("The Delivery Email is already in use.");
                }
                else if (delivery.PhoneNumber == dto.PhoneNumber && delivery.Email != dto.Email)
                {
                    throw new ArgumentException("The Delivery PhoneNumber is already in use.");
                }
                else if (delivery.PhoneNumber != dto.PhoneNumber && delivery.Email == dto.Email)
                {
                    throw new ArgumentException("The Delivery Email is already in use.");
                }
                else
                {
                    delivery.PhoneNumber = dto.PhoneNumber;
                    delivery.Email = dto.Email;
                    delivery.FirstName = dto.FirstName;
                    delivery.LastName = dto.LastName;
                    delivery.SecondName = dto.SecondName;
                    delivery.Brithday = dto.Brithday;
                    delivery.Gendear = dto.Gendear;
                    delivery.Name = dto.Name;
                    delivery.DeliveryLicenseImageUrl = dto.DeliveryLicenseImageUrl;
                    delivery.DeliveryCar = dto.DeliveryCar;
                    delivery.NationalNo = dto.NationalNo;

                    return await _context.SaveChangesAsync();
                }
            }
            else
            {
                throw new ArgumentException("Delivery not found");
            }
        }
        public async Task<User> GetDeliveryById(int DeliveryId)
        {
            var result = new User();
            var selectUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == DeliveryId
                                                                        && x.UserType == UserType.Delivery);
            result.Id = DeliveryId;
            result.IsActive = selectUser.IsActive;
            result.CreationDateTime = selectUser.CreationDateTime;
            result.Email = selectUser.Email;
            result.FirstName = selectUser.FirstName;
            result.LastName = selectUser.LastName;
            result.SecondName = selectUser.SecondName;
            result.PhoneNumber = selectUser.PhoneNumber;
            result.ConfirmPassword = selectUser.ConfirmPassword;
            result.Brithday = selectUser.Brithday;
            result.Gendear = selectUser.Gendear;
            result.UserType = selectUser.UserType;
            result.DeliveryCar = selectUser.DeliveryCar;
            result.DeliveryLicenseImageUrl = selectUser.DeliveryLicenseImageUrl;
            result.NationalNo = selectUser.NationalNo;

            return result;
        }
        #endregion


    }
}
