using API.Entities;
using API.Models;
using AutoMapper;
using System;
using System.Globalization;

namespace API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccessiblePageEntity, AccessiblePageDto>();
            CreateMap<RoleEntity, RoleDto>();
            CreateMap<UserEntity, UserDto>();

            CreateMap<Topic, TopicDto>();
            CreateMap<TopicDto, Topic>()
                .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<Lesson, LessonDto>()
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(x =>
                    x.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(d => d.TopicName, opt => opt.MapFrom(x =>
                    x.Topic.Title));

            CreateMap<LessonForCreationDto, Lesson>()
                .ForMember(d => d.CreatedAt, opt => opt.Ignore())
                .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<Card, CardDto>()
               .ForMember(d => d.CreatedAt, opt => opt.MapFrom(x =>
                   x.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")))
                   .ForMember(d => d.CardTypeName, opt => opt.MapFrom( x => x.CardType.Type))
                   .ForMember(d => d.LessonName, opt => opt.MapFrom( x => x.Lesson.Title));

            CreateMap<CardForCreationDto, Card>()
                .ForMember(d => d.CreatedAt, opt => opt.Ignore())
                .ForMember(d => d.Id, opt => opt.Ignore());

        }
    }
}
