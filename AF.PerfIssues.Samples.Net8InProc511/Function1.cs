using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;

namespace AF.PerfIssues.Samples.Net8InProc511;

public class Function1
{
    [FunctionName("FunctionMain")]
    public async Task RunAsync(
        [ServiceBusTrigger("queue-n8inproc511", Connection = "SBConnectionString")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions,
        ILogger log)
    {
        log.LogInformation("C# ServiceBus queue trigger function {netVersion} {mode} {sbLibVersion} {region}", "net8", "inproc", "511", "we");
        await Task.Delay(TimeSpan.FromMilliseconds(100));
        await messageActions.CompleteMessageAsync(message);
    }

    [FunctionName("FunctionFallback")]
    public async Task RunFallbackAsync(
        [ServiceBusTrigger("queue-n8inproc511", Connection = "SBConnectionStringFallback")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions,
        ILogger log)
    {
        log.LogInformation("C# ServiceBus queue trigger function {netVersion} {mode} {sbLibVersion} {region}", "net8", "inproc", "511", "ne");
        await Task.Delay(TimeSpan.FromMilliseconds(100));
        await messageActions.CompleteMessageAsync(message);
    }
}
