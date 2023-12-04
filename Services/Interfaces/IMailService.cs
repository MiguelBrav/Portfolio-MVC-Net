using Portfolio.Models;

namespace Portfolio.Services.Interfaces
{
    public interface IMailService
    {
        Task<bool> SendEmail(ContactViewModel contactModel);
    }
}
