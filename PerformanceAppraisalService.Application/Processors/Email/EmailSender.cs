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
        
        public async void Send(string toEmail,string body,string name)
        {
            var apiKey = Environment.GetEnvironmentVariable("SendgridAPIKey");
            var client = new SendGridClient(apiKey);

            var sendGridMessage = new SendGridMessage
            {
                From = new EmailAddress("nipunaaluthdeniya@gmail.com", "JRC-PerformanceAppraisalSystem"),
            };
            sendGridMessage.SetTemplateId("d-2a2c063235e04a7babf95468fbe467f1");
            sendGridMessage.SetTemplateData(new
            {
                name = name,
                body = body
            });
            sendGridMessage.AddTo(toEmail);
            await client.SendEmailAsync(sendGridMessage);

        }
    }
}
