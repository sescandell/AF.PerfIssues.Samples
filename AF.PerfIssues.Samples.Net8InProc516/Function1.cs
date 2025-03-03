using System;
using Azure.Messaging.ServiceBus;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;

namespace AF.PerfIssues.Samples.Net8InProc516;

public class Function1
{
    [FunctionName("Function1")]
    public async Task RunAsync(
        [ServiceBusTrigger("queue-n8inproc516", Connection = "SBConnectionString")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions,
        ILogger log)
    {
        log.LogInformation("C# ServiceBus queue trigger function {netVersion} {mode} {sbLibVersion}", "net8", "inproc", "516");
        await Task.Delay(TimeSpan.FromMilliseconds(100));
        await messageActions.CompleteMessageAsync(message);
    }
}
