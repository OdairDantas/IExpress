using AutoMapper;
using IExpress.OAuth.Application.Commands;
using IExpress.OAuth.Application.ViewModels;

namespace IExpress.OAuth.Application.AutoMapper
{
    public class AdicionarUsuarioMappingProfile : Profile
    {

        public AdicionarUsuarioMappingProfile()
        {
            CreateMap<AdicionarUsuarioViewModel, AdicionarUsuarioCommand>()
                    .ConstructUsing(u => new AdicionarUsuarioCommand (u.Nome,u.Email, u.Password,u.Latitude,u.Longitude)).ReverseMap();

        }

    }
}
