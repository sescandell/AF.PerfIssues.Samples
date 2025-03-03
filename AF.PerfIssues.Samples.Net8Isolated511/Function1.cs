using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AF.PerfIssues.Samples.Net8Isolated511;

public class Function1
{
    private readonly ILogger<Function1> _logger;

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }

    [Function(nameof(Run))]
    public async Task Run(
        [ServiceBusTrigger("queue-net8isolated511", Connection = "SBConnectionString")]
        ServiceBusReceivedMessage message)
    {
        _logger.LogInformation("C# ServiceBus queue trigger function {netVersion} {mode} {sbLibVersion} {region}", "net8", "isolated", "511", "we");

        // Completing the message is not available with this version. It's automatically done by the host
        await Task.Delay(TimeSpan.FromMilliseconds(100));
    }

    [Function(nameof(RunFallback))]
    public async Task RunFallback(
        [ServiceBusTrigger("queue-net8isolated511", Connection = "SBConnectionStringFallback")]
        ServiceBusReceivedMessage message)
    {
        _logger.LogInformation("C# ServiceBus queue trigger function {netVersion} {mode} {sbLibVersion} {region}", "net8", "isolated", "511", "ne");

        // Completing the message is not available with this version. It's automatically done by the host
        await Task.Delay(TimeSpan.FromMilliseconds(100));
    }
}
