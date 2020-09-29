using AutoMapper;
using IExpress.OAuth.Application.Commands;
using IExpress.OAuth.Application.ViewModels;
using IExpress.OAuth.Domain.DomainObjects;

namespace IExpress.OAuth.Application.AutoMapper
{
    public class AdicionarUsuarioMappingProfile : Profile
    {

        public AdicionarUsuarioMappingProfile()
        {
            CreateMap<AdicionarUsuarioViewModel, AdicionarUsuarioCommand>()
                    .ConstructUsing(u => new AdicionarUsuarioCommand (u.Nome,u.Email, u.Password,u.Latitude,u.Longitude)).ReverseMap();

            CreateMap<AdicionarUsuarioCommand, Usuario>()
                    .ConstructUsing(u => new Usuario() { UserName= u.Nome, Email= u.Email, Latitude =u.Latitude,Longitude= u.Longitude }).ReverseMap();

        }

    }
}
