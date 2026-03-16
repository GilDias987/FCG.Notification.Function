using Azure.Messaging.ServiceBus;
using FCG.Notification.Func.Dto;
using FCG.Notification.Func.Interface;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace FCG.Notification.Func;

public class SendEmail
{
    private readonly ILogger<SendEmail> _logger;
    private readonly IEmailService _emailService;

    public SendEmail(ILogger<SendEmail> logger, IEmailService emailService)
    {
        _logger = logger;
        _emailService = emailService;
    }

    [Function(nameof(SendEmail))]
    public async Task Run(
        [ServiceBusTrigger("email-queue", Connection = "ServiceBusConnection")]
        string messageJson,
        FunctionContext context)
    {
        using JsonDocument doc = JsonDocument.Parse(messageJson);
        var messageElement = doc.RootElement.GetProperty("message");
        var email = messageElement.Deserialize<EmailMessageDto>();

        _logger.LogInformation($"Sending email to {email.To}");
        await _emailService.SendAsync(email);
    }
}