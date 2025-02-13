using System.Threading.Tasks;

namespace EMP_CRM.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
