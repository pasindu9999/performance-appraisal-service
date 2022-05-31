using Azure.Storage.Queues;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Services
{
    public class QueueService : IQueueService
    {

        private UserManager<ApplicationUser> _userManager;

        private readonly QueueStorageString _queueStorageString;

        public QueueService(UserManager<ApplicationUser> userManager, IOptions<QueueStorageString> queueStorageString)
        {
            _userManager = userManager;
            _queueStorageString = queueStorageString.Value;
        }


        public async Task<string> SendToQueue(string email, EmailType type)
        {
            try
            {
                var client = new QueueClient(_queueStorageString.QueueClientString, "email-queue");

                var user = await _userManager.FindByNameAsync(email);

                EmailQueueDto e = new EmailQueueDto();
                e.UserId = new Guid(user.Id);
                e.EmailType = type;

                var jsonString = JsonConvert.SerializeObject(e);

                string encodedStr = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonString));

                await client.SendMessageAsync(encodedStr);

                return "Sent to Queue Successfully";
            }
            catch (Exception e)
            {
                return "Exception Occured " + e;
            }
        }
    }
}
