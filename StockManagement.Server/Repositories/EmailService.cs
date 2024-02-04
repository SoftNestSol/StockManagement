
using System;
using System.Net.Http;
using System.Text;





namespace StockManagement.Server.Repositories
{

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string htmlContent);
}


public class EmailService : IEmailService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "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"; 

    public EmailService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
    }

    public async Task SendEmailAsync(string to, string subject, string htmlContent)
    {
        var emailData = new
        {
            sender = new { email = "andrei.iordache2017@gmail.com" }, 
            to = new[] { new { email = to } },
            subject = subject,
            htmlContent = htmlContent
        };

        var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(emailData), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://api.sendinblue.com/v3/smtp/email", jsonContent);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to send email: {response.ReasonPhrase}");
        }
    }
}

}
