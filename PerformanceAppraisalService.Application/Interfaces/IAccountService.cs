using Microsoft.AspNetCore.Identity;
using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IAccountService
    {
        Task<string> PostApplicationUser(ApplicationUserDto applicationUserDto);
        Task<UserManagerResponse> ConfirmEmailAsync(string userid, string token);
        Task<string> LogIn(LogInDto logInDto);
        Task<string> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
        Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordViewModel model);
    }
}
