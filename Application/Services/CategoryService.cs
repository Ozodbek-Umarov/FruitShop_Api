using Application.Common.Exeptions;
using Application.DTOs.CategoryDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructures.Interfaces;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitofwork;
    private readonly IMapper _mapper;
    private readonly IValidator<Category> _validator;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<Category> validator)
    {
        _mapper = mapper;
        _unitofwork = unitOfWork;
        _validator = validator;
    }

    public async Task AddAsync(AddCategoryDto dto)
    {
        if (dto == null)
            throw new FruitException("Category bo'sh bo'lmasin");
        var category = _mapper.Map<Category>(dto);
        var result = await _validator.ValidateAsync(category);
        if (!result.IsValid) 
            throw new FruitException(result.ToString());
        await _unitofwork.Category.AddAsync(category);
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _unitofwork.Category.GetByIdAsync(id);
        if (category == null)
            throw new NotFoundException("Category topilmadi");
        await _unitofwork.Category.DeleteAsync(category);
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var list = await _unitofwork.Category.GetAllAsync();
        return list.Select(_mapper.Map<CategoryDto>).ToList();
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var model = await _unitofwork.Category.GetByIdAsync(id);
        if (model == null)
            throw new NotFoundException("Category topilmadi");
        return _mapper.Map<CategoryDto>(model);
    }

    public async Task UpdateAsync(CategoryDto dto)
    {
        var model = await _unitofwork.Category.GetByIdAsync(dto.Id);
        if (model == null)
            throw new NotFoundException("Category topilmadi");
        var category = _mapper.Map<Category>(dto);
        var result = await _validator.ValidateAsync(category);
        if (!result.IsValid)
            throw new FruitException("xato");
        await _unitofwork.Category.UpdateAsync(category);
    }
}
