using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.Tests.Mocks;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace CleanArchitecture.Application.Tests.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandlerShould
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<ILogger<CreateStreamerCommandHandler>> _logger;

        public CreateStreamerCommandHandlerShould()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _emailService = new Mock<IEmailService>(); ;
            _logger = new Mock<ILogger<CreateStreamerCommandHandler>>();
            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);

        }

        [Fact]
        public async Task create_streamer_correctly_and_returns_id()
        {
            var streamerInput = new CreateStreamerCommand
            {
                Name = "Netflix",
                Url = "https://netflix.com"
            };

            var handler = new CreateStreamerCommandHandler(_unitOfWork.Object, _mapper, _emailService.Object, _logger.Object);
            var result = await handler.Handle(streamerInput, CancellationToken.None);
            result.ShouldBeOfType<int>();
            result.ShouldBeGreaterThan(0);
        }
    }
}
