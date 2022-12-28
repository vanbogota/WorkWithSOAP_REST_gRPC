using ClinicService.Data;
using ClinicService2Namespace;
using Grpc.Core;
using static ClinicService2Namespace.ClinicService;

namespace ClinicService2.Services.Impl
{
    public class ClinicClientService : ClinicServiceBase
    {
        private readonly ClinicServiceDbContext _dbContext;

        public ClinicClientService(ClinicServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override Task<CreateClientResponse> CreateClient(CreateClientRequest request, ServerCallContext context)
        {
            try
            {
                Client client = new Client()
                {
                    Document = request.Document,
                    FirstName = request.Firstname,
                    Patronymic = request.Patronymic,
                    Surname = request.Surname,
                };
                _dbContext.Clients.Add(client);
                _dbContext.SaveChanges();

                var response = new CreateClientResponse()
                {
                    ClientId = client.Id,
                    ErrorCode = 0,
                    ErrorMessage = ""
                };
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                var response = new CreateClientResponse()
                {
                    ErrorCode = 1111,
                    ErrorMessage = "Sorry, troubles while creating client"
                };
                return Task.FromResult(response);
            }
        }

        public override Task<UpdateClientResponse> UpdateClient(UpdateClientRequest request, ServerCallContext context)
        {
            return base.UpdateClient(request, context);
        }

        public override Task<DeleteClientResponse> DeleteClient(DeleteClientRequest request, ServerCallContext context)
        {
            return base.DeleteClient(request, context);
        }
        public override Task<GetClientByIdResponse> GetClientById(GetClientByIdRequest request, ServerCallContext context)
        {
            try
            {
                Client client = _dbContext.Clients.FirstOrDefault(client => client.Id == request.ClientId);
                if (client != null)
                {
                    var response = new GetClientByIdResponse()
                    {
                        Client = new ClientResponse()
                        {
                            ClientId = client.Id,
                            Document = client.Document,
                            Firstname = client.FirstName,
                            Patronymic = client.Patronymic,
                            Surname = client.Surname
                        },
                        ErrorCode = 0,
                        ErrorMessage = "",
                    };

                    return Task.FromResult(response);
                }
                else
                {
                    var response = new GetClientByIdResponse()
                    {
                        ErrorCode = 4441,
                        ErrorMessage = "Client is not found",
                    };
                    return Task.FromResult(response);
                }
            }
            catch (Exception)
            {
                var response = new GetClientByIdResponse()
                {
                    ErrorCode = 4442,
                    ErrorMessage = "Troubles while searching client",
                };
                return Task.FromResult(response);
            }
        }

        public override Task<GetClientsResponse> GetClients(GetClientsRequest request, ServerCallContext context)
        {
            try
            {
                var response = new GetClientsResponse();

                var clients = _dbContext.Clients.Select(client => new ClientResponse()
                {
                    ClientId = client.Id,
                    Document = client.Document,
                    Firstname = client.FirstName,
                    Patronymic = client.Patronymic,
                    Surname = client.Surname,
                }).ToList();

                response.Clients.AddRange(clients);

                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                var response = new GetClientsResponse()
                {
                    ErrorCode = 5555,
                    ErrorMessage = "Sorry, troubles while getting clients",
                };

                return Task.FromResult(response);
            };
        }
    }
}
