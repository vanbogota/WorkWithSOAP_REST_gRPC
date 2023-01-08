using ClinicService.Data;
using ClinicServiceNamespace;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using static ClinicServiceNamespace.ClinicService;

namespace ClinicService.Services.Impl
{
    [Authorize]
    public class ClinicService : ClinicServiceBase
    {
        private readonly ClinicServiceDbContext _dbContext;
        private readonly ILogger<ClinicService> _logger;

        public ClinicService(ClinicServiceDbContext dbContext, ILogger<ClinicService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
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
            return base.GetClientById(request, context);
        }

        public override Task<GetClientsResponse> GetClients(GetClientsRequest request, ServerCallContext context)
        {
            try
            {
                var response = new GetClientsResponse();

                var clients = _dbContext.Clients.Select(client => new ClientResponse()
                {
                    ClientId = client.Id,
                    Document= client.Document,
                    Firstname = client.FirstName,
                    Patronymic = client.Patronymic,
                    Surname= client.Surname,
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
