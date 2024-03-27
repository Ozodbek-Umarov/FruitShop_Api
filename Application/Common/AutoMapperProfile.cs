using Application.DTOs.CategoryDtos;
using Application.DTOs.FruitDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
        CreateMap<Category, CategoryDto>()
            .ReverseMap();

        CreateMap<AddFruitDto, Fruit>();
        CreateMap<UpdateFruitDto, Fruit>();
        CreateMap<Fruit, FruitDto>()
            .ReverseMap();
    }
}
