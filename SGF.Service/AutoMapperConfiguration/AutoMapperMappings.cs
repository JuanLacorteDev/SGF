using AutoMapper;
using SGF.Application.ViewModels;
using SGF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Application.AutoMapperConfiguration
{
    public class AutoMapperMappings : Profile
    {
        public AutoMapperMappings()
        {
            CreateMap<DespesaVM, Despesa>().ReverseMap();
        }
    }
}
