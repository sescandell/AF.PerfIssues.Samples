using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AF.PerfIssues.Samples.Net9Isolated516;

public class Function1
{
    private readonly ILogger<Function1> _logger;

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }

    [Function(nameof(Function1))]
    public async Task Run(
        [ServiceBusTrigger("queue-net9isolated516", Connection = "SBConnectionString")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        _logger.LogInformation("C# ServiceBus queue trigger function {netVersion} {mode} {sbLibVersion}", "net9", "isolated", "516");

        await Task.Delay(TimeSpan.FromMilliseconds(100));
        await messageActions.CompleteMessageAsync(message);
    }
}
