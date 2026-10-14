using API.Dtos;
using AutoMapper;
using Domain;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Expense, Expense>();
        CreateMap<ExpenseDto, Expense>();
    }
}