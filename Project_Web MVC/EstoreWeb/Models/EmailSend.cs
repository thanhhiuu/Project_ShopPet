using Microsoft.AspNetCore.Identity.UI.Services;

public class EmailSend : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
       return Task.CompletedTask;
    }
}
