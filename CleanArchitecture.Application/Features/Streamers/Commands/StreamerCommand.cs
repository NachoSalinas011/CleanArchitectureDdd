using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class StreamerCommand : IRequest<int>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
