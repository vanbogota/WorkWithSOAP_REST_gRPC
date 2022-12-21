using ClinicServiceNamespace;
using Grpc.Net.Client;
using static ClinicServiceNamespace.ClinicService;

namespace ClinicTestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            using var channel = GrpcChannel.ForAddress("http://localhost:5001");

            ClinicServiceClient clinicServiceClient = new ClinicServiceClient(channel);

            var createClientResponse = clinicServiceClient.CreateClient(new CreateClientRequest()
            {
                Document = "DOC11 111",
                Firstname = "Ivan",
                Patronymic = "Serg",
                Surname = "Bogdanov"
            });

            if (createClientResponse.ErrorCode == 0)
            {
                Console.WriteLine($"Client #{createClientResponse.ClientId} created successfully.");
            }
            else
            {
                Console.WriteLine($"Create client error.\nErrorCode: {createClientResponse.ErrorCode}\nErrorMessage: {createClientResponse.ErrorMessage}");
            }

            var getClientResponse = clinicServiceClient.GetClients(new GetClientsRequest());

            if (createClientResponse.ErrorCode == 0)
            {
                Console.WriteLine("Clients:");
                Console.WriteLine("-------\n");

                foreach (var client in getClientResponse.Clients)
                {
                    Console.WriteLine($"#{client.ClientId} {client.Document} {client.Surname} {client.Firstname} {client.Patronymic}");
                }
            }
            else
            {
                Console.WriteLine($"Get clients error.\nErrorCode: {getClientResponse.ErrorCode}\nErrorMessage: {getClientResponse.ErrorMessage}");
            }

            Console.ReadKey();
        }
    }
}