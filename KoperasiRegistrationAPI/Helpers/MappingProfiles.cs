using AutoMapper;
using KoperasiRegistrationAPI.DTOs;
using KoperasiRegistrationAPI.Models;

namespace KoperasiRegistrationAPI.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterRequest, Account>();
    }
}
