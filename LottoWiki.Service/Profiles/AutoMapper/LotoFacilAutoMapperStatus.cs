﻿using LottoWiki.Service.ViewModels.Entities;
using LottoWiki.Domain.Models.Entities;
using AutoMapper;

namespace LottoWiki.Service.Profiles.AutoMapper
{
    public class LotoFacilAutoMapperStatus : Profile
    {
        public LotoFacilAutoMapperStatus()
        {
            CreateMap<LotoFacilStatus, LotoFacilViewModelStatus>().ReverseMap();
        }
    }
}