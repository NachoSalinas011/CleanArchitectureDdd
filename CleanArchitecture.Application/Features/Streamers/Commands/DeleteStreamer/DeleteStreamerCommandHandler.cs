using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public DeleteStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, ILogger logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToDelete = await _streamerRepository.GetByIdAsync(request.Id);

            if (streamerToDelete is null)
            {
                _logger.LogError($"No se encontró el streamer id {request.Id}");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            await _streamerRepository.DeleteAsync(streamerToDelete);
            _logger.LogInformation($"Streamer {request.Id} eliminado");
            return Unit.Value;
        }
    }
}
