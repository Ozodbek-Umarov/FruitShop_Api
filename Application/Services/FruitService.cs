using Application.Common.Exeptions;
using Application.DTOs.FruitDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructures.Interfaces;

namespace Application.Services;

public class FruitService : IFruitService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<Fruit> _validator;

    public FruitService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<Fruit> validator)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task AddAsync(AddFruitDto dto)
    {
        if (dto == null)
            throw new FruitException("Meva Bo'sh bo'lmasin");
        var fruit = _mapper.Map<Fruit>(dto);
        var result = await _validator.ValidateAsync(fruit);
        if (!result.IsValid)
            throw new FruitException(result.ToString());
        await _unitOfWork.Fruit.AddAsync(dto);
    }

    public async Task DeleteAsync(int id)
    {
        var model = await _unitOfWork.Fruit.GetByIdAsync(id);
        if (model == null)
            throw new NotFoundException("Meva Topilmadi");
        await _unitOfWork.Fruit.DeleteAsync(model);
    }

    public async Task<List<FruitDto>> GetAllAsync()
    {
        var list = await _unitOfWork.Fruit.GetAllAsync();
        return list.Select(_mapper.Map<FruitDto>).ToList();
    }

    public async Task<FruitDto> GetByIdAsync(int id)
    {
        var model = await _unitOfWork.Fruit.GetByIdAsync(id);
        if (model == null)
            throw new NotFoundException("Meva topilmadi");
        return _mapper.Map<FruitDto>(model);
    }

    public async Task UpdateAsync(FruitDto dto)
    {
        var model = await _unitOfWork.Fruit.GetByIdAsync(dto.Id);
        if (model == null)
            throw new NotFoundException("Meva Toplmadi");
        var fruit = _mapper.Map<Fruit>(dto);
        var result = await _validator.ValidateAsync(fruit);
        if (!result.IsValid)
            throw new FruitException("Xato");
        await _unitOfWork.Fruit.UpdateAsync(fruit);
    }
}
