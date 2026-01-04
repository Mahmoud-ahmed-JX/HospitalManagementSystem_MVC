using HospitalBLL.DTOs.AuthenticationDtos;
using HospitalBLL.Services.Interfaces;
using HospitalDAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.Services.Classes
{
    public class AccountService : IAccountService
    {
        //private readonly UserManager<ApplicationUser> userManager;

        //public AccountService(UserManager<ApplicationUser> userManager)
        //{
        //    this.userManager = userManager;
        //}
        public ApplicationUser? SignIn(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser? ValidateUser(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }
    }
}
