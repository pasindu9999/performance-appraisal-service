using System;
using System.Reflection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Application.Processors.Email;
using PerformanceAppraisalService.Infrastructure.Data;

namespace PerformanceAppraisalService.EmailFunction
{
    public class EmailFunction
    {
        private readonly IRegistrationEmailProcessor registrationEmailProcessor;

        private readonly ILoginEmailProcessor loginemailProcessor;

        private readonly IConfirmEmailProcessor confirmEmailProcessor;

        private readonly IForgotPasswordEmailProcessor forgotPasswordEmailProcessor;

        public EmailFunction(IRegistrationEmailProcessor registrationEmailProcessor, ILoginEmailProcessor loginemailProcessor, IConfirmEmailProcessor confirmEmailProcessor, IForgotPasswordEmailProcessor forgotPasswordEmailProcessor)
        {
            this.registrationEmailProcessor = registrationEmailProcessor;
            this.loginemailProcessor = loginemailProcessor;
            this.confirmEmailProcessor = confirmEmailProcessor;
            this.forgotPasswordEmailProcessor = forgotPasswordEmailProcessor;
        }

        [FunctionName("Email")]
        public void Run([QueueTrigger("email-queue", Connection = "AzureWebJobsStorage")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            try
            {
                var queueItem = myQueueItem.ToString();

                dynamic jsonData = JObject.Parse(queueItem);
                Guid  userId = (Guid)jsonData.UserId;
                int emailType = (int)jsonData.EmailType;
                string url = (string)jsonData.Url;

                ProcessEmail(userId, emailType, url);

            }

            catch (Exception ex)
            {
                log.LogError($"Error occured while processing QueueItem {myQueueItem} , Exception - {ex.InnerException}");
            }

        }

        public void ProcessEmail(Guid userId, int emailType, string url)
        {

            switch (emailType)
            {
                case 0:
                    this.registrationEmailProcessor.Process(userId, url);
                    break;
                case 1:
                    this.loginemailProcessor.Process(userId, url);
                    break;
                case 2:
                    this.confirmEmailProcessor.Process(userId, url);
                    break;
                case 3:
                    this.forgotPasswordEmailProcessor.Process(userId, url);
                    break;
                default:
                    return;
            }
        }
    }

    
}
