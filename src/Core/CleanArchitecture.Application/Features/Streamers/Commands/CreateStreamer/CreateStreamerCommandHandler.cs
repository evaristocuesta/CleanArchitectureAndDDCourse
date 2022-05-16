using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamer = _mapper.Map<Streamer>(request);
            _unitOfWork.StreamerRepository.AddEntity(streamer);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                _logger.LogError("Error creating Streamer");
                throw new Exception("Error creating Streamer");
            }

            _logger.LogInformation($"Streamer {streamer.Id} created successfully");
            await SendEmail(streamer);
            return streamer.Id;
        }

        public async Task SendEmail(Streamer streamer)
        {
            var email = new Email()
            {
                To = "evaristocg@gmail.com",
                Subject = $"Stremer {streamer.Name} added",
                Body = $"Stremer {streamer.Name} added"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending email: {ex.Message}");
            }
        }
    }
}
