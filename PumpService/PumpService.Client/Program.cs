using PumpService.Client.PumpServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PumpService.Client
{
    //client for testing PumpService
    public class Program
    {
        static void Main(string[] args)
        {
            InstanceContext instanceContext = new InstanceContext(new CallbackHandler());
            PumpServiceClient pumpServiceClient = new PumpServiceClient(instanceContext);

            pumpServiceClient.UpdateAndCompliteScript(@"D:\ScriptsTestWCF\Sample.script");
            pumpServiceClient.RunScript();

            Console.WriteLine("press enter to exit...");
            Console.ReadKey(true);
            pumpServiceClient.Close();

        }
    }
}
