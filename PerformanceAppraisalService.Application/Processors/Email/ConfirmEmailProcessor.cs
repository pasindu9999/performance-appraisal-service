using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerformanceAppraisalService.Application.Processors.Email
{
    public class ConfirmEmailProcessor : IConfirmEmailProcessor
    {
        private readonly ApplicationDbContext _context1;

        public ConfirmEmailProcessor(ApplicationDbContext context1)
        {
            _context1 = context1;
        }

        public void Process(Guid userId, string url)
        {

            var user = _context1.ApplicationUsers.Where(u => u.Id == userId.ToString()).Single();
            string body = "Thank you for using the JRC-PerformanceAppraisalSystem, Click on the following link to verify your email";
            EmailSender emailSender = new EmailSender();
            string eTemplateId = "d-7e73bc856d274a8d97d660d70e70d2c1";
            emailSender.Send(user.UserName, body, user.FullName, eTemplateId, url);
        }
    }
}
