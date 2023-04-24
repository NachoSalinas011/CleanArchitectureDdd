using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommand>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStreamerCommandHandler> _logger;

        public UpdateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, ILogger<UpdateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamer = _streamerRepository.GetByIdAsync(request.Id);
        }
    }
}
