using AutoMapper;
using Data.Dtos;
using Data.Models;

namespace API.AutoMapper
{
    public class AppAutoMapper : Profile
    {
        public AppAutoMapper()
        {
            CreateMap<AddQuestionTypeDto, QuestionType>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString())).ReverseMap();

            CreateMap<AddQuestionDto, Question>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString())).ReverseMap();

            CreateMap<UpdateQuestionDto, Question>().ReverseMap();

            CreateMap<ApplicationDto, Application>()
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString())).ReverseMap();

            CreateMap<PersonalInformationDto, PersonalInformation>().ReverseMap();

            CreateMap<AdditionalQuestionDto, AdditionalQuestion>().ReverseMap();

            CreateMap<ViewApplicationDto, Application>().ReverseMap();
        }
    }
}
