using PerfumeOnlineStore_Core.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeOnlineStore_Core.Models.Context;
using Microsoft.EntityFrameworkCore;
using PerfumeOnlineStore_Core.Models.Entites;
using Microsoft.Extensions.Options;
using PerfumeOnlineStore_Core.Dtos.Shared;

namespace PerfumeOnlineStore_Infra.ReposImplementation
{
    public class SharedRepos : ISharedReposInterface
    {
        private readonly PerfumeOnlineStoreDbContext _context;
        public SharedRepos(PerfumeOnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task ResetPassword(UpdatePasswordDTO dto)
        {
            if (dto.NewPassword != dto.ConfirmNewPassword)
            {
                throw new ArgumentException("New password and confirm password do not match.");
            }
            var user = _context.Users.FirstOrDefault(c => c.Email == dto.Email);
            if (user != null)
            {
                if (user.Password != dto.Password)
                {
                    throw new Exception("Current password is incorrect.");
                }
                user.Password = dto.NewPassword;

                await _context.SaveChangesAsync();
                throw new ArgumentException("Successfully Deleted");
            }
            else
            {
                throw new Exception("User not found.");
            }
        }
    }
}
