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

        public EmailFunction(IRegistrationEmailProcessor registrationEmailProcessor, ILoginEmailProcessor loginemailProcessor)
        {
            this.registrationEmailProcessor = registrationEmailProcessor;
            this.loginemailProcessor = loginemailProcessor;
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

                ProcessEmail(userId, emailType);

            }

            catch (Exception ex)
            {
                log.LogError($"Error occured while processing QueueItem {myQueueItem} , Exception - {ex.InnerException}");
            }

        }

        public void ProcessEmail(Guid userId, int emailType)
        {

            switch (emailType)
            {
                case 0:
                    this.registrationEmailProcessor.Process(userId);
                    break;
                case 1:
                    this.loginemailProcessor.Process(userId);
                    break;
                default:
                    return;
            }
        }
    }

    
}
