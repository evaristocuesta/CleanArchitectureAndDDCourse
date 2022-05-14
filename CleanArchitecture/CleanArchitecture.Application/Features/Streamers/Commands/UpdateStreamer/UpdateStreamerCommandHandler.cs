using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommand>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<UpdateStreamerCommandHandler> _logger;

        public UpdateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, IEmailService emailService, ILogger<UpdateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToUpdated = await _streamerRepository.GetByIdAsync(request.Id);

            if (streamerToUpdated == null)
            {
                _logger.LogError($"Streamer {request.Id} not found");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            var streamer = _mapper.Map(request, streamerToUpdated, typeof(UpdateStreamerCommand), typeof(Streamer));
            var streamerAdded = await _streamerRepository.UpdateAsync(streamerToUpdated);

            _logger.LogInformation($"Streamer {streamerAdded.Id} updated successfully");

            return Unit.Value;
        }
    }
}
