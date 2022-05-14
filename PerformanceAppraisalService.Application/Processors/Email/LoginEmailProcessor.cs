using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerformanceAppraisalService.Application.Processors.Email
{
    public class LoginEmailProcessor: ILoginEmailProcessor
    {
        private readonly ApplicationDbContext _context2;

        public LoginEmailProcessor(ApplicationDbContext context2)
        {
            _context2 = context2;
        }

        public void Process(Guid userId)
        {

            var user = _context2.ApplicationUsers.Where(u => u.Id == userId.ToString()).Single();
            string body = "You have login to the JRC Performance Appraisal System Successfully";
            EmailSender emailSender = new EmailSender();
            emailSender.Send(user.UserName, body, user.FullName);
        }
    }
}
