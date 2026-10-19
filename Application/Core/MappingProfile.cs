using API.Dtos;
using AutoMapper;
using Domain;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Expense, Expense>();
        CreateMap<ExpenseDto, Expense>()
        .ForMember(x => x.Name, y => y.MapFrom(c => c.Title));
        CreateMap<Expense, ExpenseDto>()
        .ForMember(x => x.Title, y => y.MapFrom(c => c.Name));
    }
}