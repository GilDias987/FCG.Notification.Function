using FCG.Notification.Func.Interface;
using FCG.Notification.Func.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddScoped<IEmailService, EmailService>();
    })
    .Build();

host.Run();
