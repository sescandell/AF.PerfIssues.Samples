using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AF.PerfIssues.Samples.Net9Isolated512;

public class Function1
{
    private readonly ILogger<Function1> _logger;

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }

    [Function(nameof(Function1))]
    public async Task Run(
        [ServiceBusTrigger("queue-net9isolated512", Connection = "SBConnectionString")]
        ServiceBusReceivedMessage message)
    {
        _logger.LogInformation("C# ServiceBus queue trigger function {netVersion} {mode} {sbLibVersion}", "net9", "isolated", "512");

        // Completing the message is not available with this version. It's automatically done by the host
        await Task.Delay(TimeSpan.FromMilliseconds(100));
    }
}