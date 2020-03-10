using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class EventHubToCosmosDBFunction
    {
        [FunctionName("EventHubToCosmosDBFunction")]
        public static async Task Run(
            [EventHubTrigger("storetocosmosdb", Connection = "eh_listener_EVENTHUB")] EventData[] events,
            [CosmosDB(
                databaseName: "SensorData",
                collectionName: "Sensors",
                ConnectionStringSetting = "CosmosDBConnection")]IAsyncCollector<dynamic> document,
                 ILogger log)
        {
            var exceptions = new List<Exception>();

            foreach (EventData eventData in events)
            {
                try
                {
                    string messageBody = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);

                    // Replace these two lines with your processing logic.
                    log.LogInformation($"C# Event Hub trigger function processed a message: {messageBody}");
                    dynamic messageBodyJson = Newtonsoft.Json.JsonConvert.DeserializeObject(messageBody);
                    if (messageBodyJson.Type == Newtonsoft.Json.Linq.JTokenType.Array) {
                        foreach (dynamic m in messageBodyJson)
                        {
                            await document.AddAsync(m);
                        }
                    }
                    else
                    {
                        await document.AddAsync(messageBodyJson);
                    }

                    await Task.Yield();
                }
                catch (Exception e)
                {
                    // We need to keep processing the rest of the batch - capture this exception and continue.
                    // Also, consider capturing details of the message that failed processing so it can be processed again later.
                    exceptions.Add(e);
                }
            }

            // Once processing of the batch is complete, if any messages in the batch failed processing throw an exception so that there is a record of the failure.

            if (exceptions.Count > 1)
                throw new AggregateException(exceptions);

            if (exceptions.Count == 1)
                throw exceptions.Single();
        }
    }
}
