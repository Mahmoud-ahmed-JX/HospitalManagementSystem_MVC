using HospitalBLL.DTOs.AuthenticationDtos;
using HospitalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.Services.Interfaces
{
    public interface IAccountService
    {
        ApplicationUser? ValidateUser(LoginDto loginDto);

        ApplicationUser? SignIn(RegisterDto registerDto);
    }
}
