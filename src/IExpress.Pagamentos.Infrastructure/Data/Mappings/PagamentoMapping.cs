using IExpress.Pagamentos.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IExpress.Pagamentos.Infrastructure.Data.Mappings
{
    public class PagamentoMapping : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Valor).IsRequired();
           

            // 1 : 1 => Pagamento : Transacao
            builder.HasOne(c => c.Transacao).WithOne(c => c.Pagamento);

            builder.ToTable("Pagamentos");
        }
    }
}

