using AutoMapper;
using CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.Tests.Mocks;
using CleanArchitecture.Infrastructure.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace CleanArchitecture.Application.Tests.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandlerShould
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<DeleteStreamerCommandHandler>> _logger;

        public DeleteStreamerCommandHandlerShould()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<DeleteStreamerCommandHandler>>();
            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task delete_streamer_corretly_and_return_unit()
        {
            var streamerInput = new DeleteStreamerCommand
            {
                Id = 8001
            };

            var handler = new DeleteStreamerCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(streamerInput, CancellationToken.None);
            result.ShouldBeOfType<Unit>();
        }
    }
}
