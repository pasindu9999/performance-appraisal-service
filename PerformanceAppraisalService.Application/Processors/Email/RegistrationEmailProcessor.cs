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

        public void Process(Guid userId)
        {
           
            var user =  _context1.ApplicationUsers.Where(u => u.Id == userId.ToString()).Single();
            string body = "You have registered to the JRC Performance Appraisal System Successfully";
            EmailSender emailSender = new EmailSender();
            emailSender.Send(user.UserName,body,user.FullName);
        }
    }
}
