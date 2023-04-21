using AutoMapper;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : Profile //En esta clase se configuran los mapeos entre clases
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVm>();
        }
    }
}
