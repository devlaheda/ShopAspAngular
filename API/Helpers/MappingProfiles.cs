using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        { 
            CreateMap<Product,ProductDto>()
            .ForMember(pd=> pd.ProductBrand, p=> p.MapFrom(s=> s.ProductBrand.Name))
            .ForMember(pd=> pd.ProductType, p=> p.MapFrom(s=> s.ProductType.Name))
            .ForMember(pd=>pd.PictureUrl,o=> o.MapFrom<ProductPictureUrlResolver>());
        }
    }
}