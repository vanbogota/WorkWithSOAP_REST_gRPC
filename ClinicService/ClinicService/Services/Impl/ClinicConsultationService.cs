using ClinicService.Data;
using ClinicServiceNamespace;
using Grpc.Core;
using static ClinicServiceNamespace.ClinicConsultationService;

namespace ClinicService.Services.Impl
{
    public class ClinicConsultationService : ClinicConsultationServiceBase
    {
        private readonly ClinicServiceDbContext _dbContext;

        public ClinicConsultationService(ClinicServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override Task<CreateConsultationResponse> CreateConsultation(CreateConsultationRequest request, ServerCallContext context)
        {
            try
            {
                Consultation consultation = new()
                {
                    ClientId= request.ClientId,
                    PetId= request.PetId,
                    ConsultationDate= DateTime.Parse(request.CreationDate),
                    Description = request.Description,
                };

                _dbContext.Consultations.Add(consultation);
                _dbContext.SaveChanges();

                var response = new CreateConsultationResponse()
                {
                    ConsultationId = consultation.Id,
                    ErrorCode = 0,
                    ErrorMessage = "",
                };
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                var response = new CreateConsultationResponse()
                {
                    ErrorCode = 1111,
                    ErrorMessage = $"Sorry, troubles while creating consultation: {ex.Message}",
                };
                return Task.FromResult(response);
            }
        }

        public override Task<GetConsultationsResponse> GetConsultations(GetConsultationsRequest request, ServerCallContext context)
        {
            try
            {
                var response = new GetConsultationsResponse();
                var consultations = _dbContext.Consultations.Select(consultation => new ConsultationResponse()
                {
                    ConsultationId= consultation.Id,
                    CreationDate = consultation.ConsultationDate.ToString("d"),
                    Description= consultation.Description,
                }).ToList();

                response.Consultations.AddRange(consultations);
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                var response = new GetConsultationsResponse()
                {
                    ErrorCode = 5555,
                    ErrorMessage = $"Sorry, troubles while getting consultations: {ex.Message}",
                };
                return Task.FromResult(response);
            }
        }
    }
}
