using Api.Domain.Entities.Pessoa.PessoaTipo;
using Domain.Entities.FormaPagamento;
using Microsoft.EntityFrameworkCore;

namespace Data.Seeds
{
    public static class FormaPagamentoSeeds
    {
        public static void FormaPagamento(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormaPagamentoEntity>().HasData(
            new FormaPagamentoEntity
            {
                Id = Guid.Parse("249c0c31-ee8e-487b-b4c9-1f14ced84553"),
                DescricaoFormaPg = "DINHEIRO",
                CreateAt = DateTime.Now,
                Habilitado = true
            },
             new FormaPagamentoEntity
             {
                 Id = Guid.Parse("18e68a14-54b5-44b6-87ed-e8b0258d9c1d"),
                 DescricaoFormaPg = "DÉBITO",
                 CreateAt = DateTime.Now,
                 Habilitado = true
             },
             new FormaPagamentoEntity
             {
                 Id = Guid.Parse("ac336bfb-39eb-4da0-9b04-c159f0068676"),
                 DescricaoFormaPg = "CRÉDITO",
                 CreateAt = DateTime.Now,
                 Habilitado = true
             },
             new FormaPagamentoEntity
             {
                 Id = Guid.Parse("d276bcd0-e552-46d4-af7a-390a3af0eb37"),
                 DescricaoFormaPg = "SODEXO",
                 CreateAt = DateTime.Now,
                 Habilitado = true
             },
             new FormaPagamentoEntity
             {
                 Id = Guid.Parse("46152359-216e-4b2e-827c-411092ecc423"),
                 DescricaoFormaPg = "TICKT ELETRON",
                 CreateAt = DateTime.Now,
                 Habilitado = true
             },
             new FormaPagamentoEntity
             {
                 Id = Guid.Parse("cdd1b70b-5c96-472e-a983-3abdcc318c53"),
                 DescricaoFormaPg = "VR",
                 CreateAt = DateTime.Now,
                 Habilitado = true
             },
             new FormaPagamentoEntity
             {
                 Id = Guid.Parse("935f9721-bcc2-4239-88a1-2e0c9b1a75f6"),
                 DescricaoFormaPg = "AMEX",
                 CreateAt = DateTime.Now,
                 Habilitado = true
             },
             new FormaPagamentoEntity
             {
                 Id = Guid.Parse("e93ceba1-40f8-4420-8dc3-bb1b3ee6ee9f"),
                 DescricaoFormaPg = "VALE SHOPPING",
                 CreateAt = DateTime.Now,
                 Habilitado = true
             },
             new FormaPagamentoEntity
             {
                 Id = Guid.Parse("7aaecde9-7290-48e7-bf31-f8dab886381f"),
                 DescricaoFormaPg = "IFOOD",
                 CreateAt = DateTime.Now,
                 Habilitado = true
             });
        }

        internal static void PessoaTipo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PessoaTipoEntity>().HasData(
               new PessoaTipoEntity
               {
                   Id = Guid.Parse("a58b678c-07d4-417b-929b-600dc63858ea"),
                   DescricaoPessoaTipo = "FÍSICA",
                   CreateAt = DateTime.Now,
               },
               new PessoaTipoEntity
               {
                   Id = Guid.Parse("2cc73259-4063-4f20-9c21-34ff2a9cbd58"),
                   DescricaoPessoaTipo = "JURÍDICA",
                   CreateAt = DateTime.Now,
               });
        }
    }
}
