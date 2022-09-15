using AutoMapper;
using Shop.WebStoreDataContracts.Models;
using Shop.DummyjsonStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DummyjsonStore
{
    public static class Mappers
    {
        public static readonly IMapper Mapper = new MapperConfiguration(config =>
        {
            config.CreateMap<DummyjsonProduct, Product>()
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id))
                .ForMember(p => p.Title, opt => opt.MapFrom(p => p.Title))
                .ForMember(p => p.Description, opt => opt.MapFrom(p => p.Description))
                .ForMember(p => p.Price, opt => opt.MapFrom(p => p.Price))
                .ForMember(p => p.Rating, opt => opt.MapFrom(p => p.Rating))
                .ForMember(p => p.Stock, opt => opt.MapFrom(p => p.Stock))
                .ForMember(p => p.Brand, opt => opt.MapFrom(p => p.Brand))
                .ForMember(p => p.Category, opt => opt.MapFrom(p => p.Category))
                .ForMember(p => p.Thumbnail, opt => opt.MapFrom(p => p.Thumbnail))
                .ForMember(p => p.Images, opt => opt.MapFrom(p => p.Images));

        }).CreateMapper();
    }
}
