using AutoMapper;
using IExpress.Core.ValueObjects;
using IExpress.Pagamentos.Application.ViewModels;
using IExpress.Pagamentos.Domain.DomainObjects;


namespace IExpress.Pagamentos.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PagamentoPedidoViewModel, PagamentoCartao>()
                .ConstructUsing(p => new PagamentoCartao(p.PedidoId, p.Total, new Cartao() { Cvv = p.CvvCartao, Expiracao = p.ExpiracaoCartao, Numero = p.NumeroCartao, Titular = p.TitularCartao }));

            CreateMap<PagamentoPedidoViewModel, Pedido>()
                    .ConstructUsing(p => new Pedido() { Id = p.PedidoId, Valor = p.Total });

           
        }




    }
}
