using AutoMapper;
using OoptiRH.Common.Dtos;
using OoptiRH.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OoptiRH.Kernel.Mapping
{
    public class OoptiRHMapperProfile : Profile
    {
        public OoptiRHMapperProfile()
        {
            CreateMap<AdresseDto, Adresse>().ReverseMap();
            CreateMap<JobDto, Job>().ReverseMap();
            CreateMap<CollaboratorDto, Collaborator>().ReverseMap();
            CreateMap<JobCollaboratorHistoryDto, ColloboratorJobHistory>().ReverseMap();
        }
    }
}
