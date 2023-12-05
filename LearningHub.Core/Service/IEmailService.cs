using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningHub.Core.Data;

namespace LearningHub.Core.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);

        //Task SendEmailWithAttachmentAsync(string to, string subject, string body, Stream attachmentStream, string attachmentFileName);

    }
}
