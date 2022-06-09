using Microsoft.Extensions.Options;
using PerformanceAppraisalService.Application.Dtos;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Processors.Email
{
    public class EmailSender
    {
        
        public async void Send(string toEmail,string body,string name,string eTemplateId, string url) 
        {
            var apiKey = Environment.GetEnvironmentVariable("SendgridAPIKey");
            var client = new SendGridClient(apiKey);

            var sendGridMessage = new SendGridMessage
            {
                From = new EmailAddress("nipunaaluthdeniya@gmail.com", "JRC-PerformanceAppraisalSystem"),
            };
            sendGridMessage.SetTemplateId(eTemplateId);
            sendGridMessage.SetTemplateData(new
            {
                name = name,
                body = body,
                link = url
            });
            sendGridMessage.AddTo(toEmail);
            await client.SendEmailAsync(sendGridMessage);

        }
    }
}
