using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class StreamerCommandHandler : IRequestHandler<StreamerCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly Mapper _mapper;

        public async Task<int> Handle(StreamerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
