using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EMP_CRM.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            _logger.LogInformation($"Email sent to {email}: {subject} - {message}");
            return Task.CompletedTask;
        }
    }
}
