using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.Tests.Mocks;
using CleanArchitecture.Infrastructure.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace CleanArchitecture.Application.Tests.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandlerShould
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<UpdateStreamerCommandHandler>> _logger;

        public UpdateStreamerCommandHandlerShould()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _emailService = new Mock<IEmailService>(); ;
            _logger = new Mock<ILogger<UpdateStreamerCommandHandler>>();
            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);

        }

        [Fact]
        public async Task update_streamer_correctly_and_return_unit()
        {
            var streamerInput = new UpdateStreamerCommand
            {
                Id = 8001,
                Name = "Netflix updated",
                Url = "https://netflix.com"
            };

            var handler = new UpdateStreamerCommandHandler(_unitOfWork.Object, _mapper, _emailService.Object, _logger.Object);
            var result = await handler.Handle(streamerInput, CancellationToken.None);
            result.ShouldBeOfType<Unit>();
        }
    }
}
