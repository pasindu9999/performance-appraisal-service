using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerformanceAppraisalService.Application.Processors.Email
{
    public class RegistrationEmailProcessor : IRegistrationEmailProcessor
    {


        private readonly ApplicationDbContext _context1;

        public RegistrationEmailProcessor(ApplicationDbContext context1)
        {
            _context1 = context1;
        }

        public void Process(Guid userId, string url)
        {
           
            var user =  _context1.ApplicationUsers.Where(u => u.Id == userId.ToString()).Single();
            string body = "Your Account has been successfully created! We have sent you a verification link to your email address";
            EmailSender emailSender = new EmailSender();
            string eTemplateId = "d-190f81fbfee94f11a0ac11701ed6fa7b "; 
            emailSender.Send(user.UserName,body,user.FullName,eTemplateId, url);
        }
    }
}
