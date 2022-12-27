using ClinicService.Data;
using ClinicServiceNamespace;
using Grpc.Core;
using static ClinicServiceNamespace.ClinicPetService;

namespace ClinicService.Services.Impl
{
    public class ClinicPetService : ClinicPetServiceBase
    {
        private readonly ClinicServiceDbContext _dbContext;

        public ClinicPetService(ClinicServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override Task<CreatePetResponse> CreatePet(CreatePetRequest request, ServerCallContext context)
        {
            try
            {
                Pet pet = new()
                {
                    ClientId = request.ClientId,
                    Name = request.Name,
                    Birthday = DateTime.Parse(request.Birthday),                    
                };

                _dbContext.Pets.Add(pet);
                _dbContext.SaveChanges();

                var response = new CreatePetResponse()
                {
                    PetId = pet.Id,
                    ErrorCode = 0,
                    ErrorMessage ="",
                };
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                var response = new CreatePetResponse()
                {
                    ErrorCode = 1111,
                    ErrorMessage = $"Sorry, troubles while creating pet: {ex.Message}",
                };
                return Task.FromResult(response);
            }
        }

        public override Task<DeletePetResponse> DeletePet(DeletePetRequest request, ServerCallContext context)
        {
            return base.DeletePet(request, context);
        }

        public override Task<UpdatePetResponse> UpdatePet(UpdatePetRequest request, ServerCallContext context)
        {
            return base.UpdatePet(request, context);
        }

        public override Task<GetPetByIdResponse> GetPetById(GetPetByIdRequest request, ServerCallContext context)
        {
            return base.GetPetById(request, context);
        }

        public override Task<GetPetsResponse> GetPets(GetPetsRequest request, ServerCallContext context)
        {
            try
            {
                var response = new GetPetsResponse();

                var pets = _dbContext.Pets.Select(pet => new PetResponse()
                {
                    PetId = pet.Id,
                    Name = pet.Name,
                    Birthday = pet.Birthday.ToString("d"),
                }).ToList();

                response.Pets.AddRange(pets);

                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                var response = new GetPetsResponse()
                {
                    ErrorCode = 5555,
                    ErrorMessage = $"Sorry, troubles while getting pets: {ex.Message}",
                };
                return Task.FromResult(response);
            }
        }
    }
}
