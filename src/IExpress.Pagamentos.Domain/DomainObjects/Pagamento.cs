﻿using IExpress.Core.DomainObjects;
using IExpress.Pagamentos.Domain.Enumerators;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IExpress.Pagamentos.Domain.DomainObjects
{
    public class Pagamento : Entity, IAggregateRoot
    {
        public Pagamento(Guid pedidoId, decimal valor)
        {
            PedidoId = pedidoId;
            Valor = valor;
        }

        public Guid PedidoId { get; private set; }
        public StatusPagamento Status { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; private set; }

        // EF. Rel.
        public Transacao Transacao { get; set; }


        public void AtualizarStatus(StatusPagamento status)
        {
            Status = status;
        }

    }
}
