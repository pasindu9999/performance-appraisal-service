using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerformanceAppraisalService.Application.Processors.Email
{
    public class ForgotPasswordEmailProcessor : IForgotPasswordEmailProcessor
    {
        private readonly ApplicationDbContext _context2;

        public ForgotPasswordEmailProcessor(ApplicationDbContext context2)
        {
            _context2 = context2;
        }

        public void Process(Guid userId, string url)
        {

            var user = _context2.ApplicationUsers.Where(u => u.Id == userId.ToString()).Single();
            string body = "Click the following button to reset the password";
            EmailSender emailSender = new EmailSender();
            string eTemplateId = "d-2fc0eb305bcf45b3b9f2e05bf9b96d3e";
            emailSender.Send(user.UserName, body, user.FullName, eTemplateId, url);
        }
    }
}
