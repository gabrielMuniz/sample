using AutoMapper;
using SampleApp.Domain.Entities;
using SampleApp.SampleApi.ViewModels;

namespace SampleApp.SampleApi.Configuration.Profile
{
    public class AutoMapperProfile : AutoMapper.Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Todo, TodoViewModel>().ReverseMap();
        }

    }
}
