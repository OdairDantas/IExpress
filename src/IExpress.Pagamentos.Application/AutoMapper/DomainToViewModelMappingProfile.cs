using AutoMapper;
using IExpress.Pagamentos.Application.ViewModels;
using IExpress.Pagamentos.Domain.DomainObjects.DTO;

namespace IExpress.Pagamentos.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile()
        {
            CreateMap<PagamentoPedido, PagamentoPedidoViewModel>()
                .ForMember(d => d.TitularCartao, o => o.MapFrom(s => s.Cartao.Titular))
                .ForMember(d => d.NumeroCartao, o => o.MapFrom(s => s.Cartao.Numero))
                .ForMember(d => d.ExpiracaoCartao, o => o.MapFrom(s => s.Cartao.Expiracao))
                .ForMember(d => d.CvvCartao, o => o.MapFrom(s => s.Cartao.Cvv));
               
        }
    }
}
