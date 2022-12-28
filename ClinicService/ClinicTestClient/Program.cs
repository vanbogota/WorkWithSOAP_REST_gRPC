using ClinicServiceNamespace;
using Grpc.Net.Client;
using static ClinicServiceNamespace.ClinicConsultationService;
using static ClinicServiceNamespace.ClinicPetService;
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

            ClinicConsultationServiceClient consultServiceClient = new ClinicConsultationServiceClient(channel);

            ClinicPetServiceClient petServiceClient = new ClinicPetServiceClient(channel);

            //testing client creation

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
            Console.WriteLine();

            //testing pet creation
            var createPetResponse = petServiceClient.CreatePet(new CreatePetRequest()
            {
                ClientId = (int)createClientResponse.ClientId,
                Name = "Pet1",
                Birthday = "21.11.1990",
            });

            if (createPetResponse.ErrorCode == 0)
            {
                
                Console.WriteLine($"Pet #{createPetResponse.PetId} created successfully.");
            }
            else
            {
                Console.WriteLine($"Create pet error.\n" +
                    $"ErrorCode: {createPetResponse.ErrorCode}\n" +
                    $"ErrorMessage: {createPetResponse.ErrorMessage}");
            }

            var getPetsResponse = petServiceClient.GetPets(new GetPetsRequest());

            if (getPetsResponse.ErrorCode == 0)
            {
                Console.WriteLine("Pets:");
                Console.WriteLine("-------\n");

                foreach (var pet in getPetsResponse.Pets)
                {
                    Console.WriteLine($"#{pet.PetId}:{pet.Name}");
                }
            }
            else
            {
                Console.WriteLine($"Get pets error.\nErrorCode: {getPetsResponse.ErrorCode}\nErrorMessage: {getPetsResponse.ErrorMessage}");
            }
            Console.WriteLine();

            //testing consultation creation 
            var createConsultationResponse = consultServiceClient.CreateConsultation(new CreateConsultationRequest()
            {
                ClientId = (int)createClientResponse.ClientId,
                PetId= (int)createPetResponse.PetId,
                CreationDate = DateTime.Now.ToString("d"),
                Description = "Some description of slient and pet",
            });

            if(createConsultationResponse.ErrorCode == 0)
            {
                Console.WriteLine($"Consultation #{createConsultationResponse.ConsultationId} created successfully.");
            }
            else
            {
                Console.WriteLine($"Create consultation error.\n" +
                    $"ErrorCode: {createConsultationResponse.ErrorCode}\n" +
                    $"ErrorMessage: {createConsultationResponse.ErrorMessage}");

            }

            var getConsultationsResponse = consultServiceClient.GetConsultations(new GetConsultationsRequest());
            if (getConsultationsResponse.ErrorCode==0)
            {
                Console.WriteLine("Consultations:");
                Console.WriteLine("-------\n");

                foreach (var consultation in getConsultationsResponse.Consultations)
                {
                    Console.WriteLine($"#{consultation.ConsultationId}: {consultation.Description}");
                }
            }
            else
            {
                Console.WriteLine($"Get consultations error.\nErrorCode: {getConsultationsResponse.ErrorCode}\nErrorMessage: {getConsultationsResponse.ErrorMessage}");
            }
            Console.WriteLine();
            

            Console.ReadKey();
        }
    }
}