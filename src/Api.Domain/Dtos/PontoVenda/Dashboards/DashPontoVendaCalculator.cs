﻿using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Dtos.PontoVendaDtos;
using Domain.Entities.PedidoSituacao.Ferramentas;

namespace Domain.Dtos.PontoVenda.Dashboards
{
    public static class DashPontoVendaCalculator<T> where T : PontoVendaDto
    {
        //TUDO REFERENTE A PEDIDOS
        static IEnumerable<PedidoDto> GetPedidosValidos(T pdv)
        {
            var pedidos_validos = from pedido in pdv.PedidoEntities
                                  where pedido.Habilitado == true && pedido.SituacaoPedidoEntity.Id == GuidSituacaoPedido2.SituacaoFechadoID
                                  select pedido;

            return pedidos_validos;
        }
        static IEnumerable<PedidoDto> GetPedidosCancelados(T pdv)
        {
            var pedidos_validos = from pedido in pdv.PedidoEntities
                                  where pedido.Habilitado == false || pedido.SituacaoPedidoEntity.Id != GuidSituacaoPedido2.SituacaoFechadoID
                                  select pedido;

            return pedidos_validos;
        }
        public static string GetPeriodoPdv(T pdv)
        {
            var periodo = pdv.PeriodoPontoVendaEntity.DescricaoPeriodo;
            return periodo;
        }
        public static DateTime GetDataPdvAbertura(T pdv)
        {
            return pdv.CreateAt;
        }
        public static DateTime? GetDataPdvEncerramento(T pdv)
        {
            if (pdv.UpdateAt == null)
                return null;

            return pdv.UpdateAt;
        }
        public static string GetSituacaoPdv(T pdv)
        {
            var situacao = pdv.AbertoFechado ? "Aberto" : "Encerrado";
            return situacao;
        }
        public static string GetUsuarioResponsavelAberturaCaixa(T pdv)
        {
            var user = pdv.UserPdvCreate.User;
            return user.Nome;
        }
        public static string GetUsuarioOperadorCaixa(T pdv)
        {
            var user = pdv.UserPdvUsing.User;
            return user.Nome;
        }
        public static int QtdPedidos(T pdv, bool validos = true)
        {
            IEnumerable<PedidoDto> pedidos = null;

            if (validos)
                pedidos = GetPedidosValidos(pdv);
            else
                pedidos = GetPedidosCancelados(pdv);

            return pedidos.Count();
        }
        public static decimal TotalDescontoPedido(T pdv)
        {
            var pedido = GetPedidosValidos(pdv);
            return pedido.Sum(pedido => pedido.ValorDesconto);
        }
        public static decimal Total(T pdv)
        {
            var pedidos_validos = GetPedidosValidos(pdv).ToList();
            return pedidos_validos.Sum(pedido => pedido.ValorPedido);
        }
        public static decimal TicktMedio(T pdv)
        {
            var tm = Total(pdv) / QtdPedidos(pdv);
            return tm;

        }
        public static IEnumerable<CategoriaPrecoGroupBy>? PedidosByCategoriaPreco(T pdv)
        {
            var pedidos_validos = GetPedidosValidos(pdv);

            var CategoriaPrecoGroupBy = from pedido in pedidos_validos.Where(item => item.ItensPedidoEntities.Any(item => item.Habilitado == true))
                                        group pedido by pedido.CategoriaPrecoEntity.DescricaoCategoria into categoriaGroup
                                        select new CategoriaPrecoGroupBy
                                        {
                                            Categoria = categoriaGroup.Key,
                                            SomaValorPedido = categoriaGroup.Sum(p => p.ValorPedido),
                                            QuantidadePedido = categoriaGroup.Count(),
                                            TicketMedio = categoriaGroup.Average(p => p.ValorPedido)
                                        };

            return CategoriaPrecoGroupBy;
        }
        public static IEnumerable<ProdutosByCategoriaGroupBy>? ProdutosByCategoriaPreco(T pdv)
        {
            var pedidos_validos = GetPedidosValidos(pdv);

            var result = from pedido in pedidos_validos
                         from item in pedido.ItensPedidoEntities
                         group item by new { pedido.CategoriaPrecoEntity.DescricaoCategoria, item.ProdutoEntity.NomeProduto, item.Preco } into produtoGroup
                         select new ProdutosByCategoriaGroupBy
                         {
                             CategoriaPreco = produtoGroup.Key.DescricaoCategoria,
                             NomeProduto = produtoGroup.Key.NomeProduto,
                             Preco = produtoGroup.Key.Preco,
                             QuantidadeTotal = produtoGroup.Sum(i => i.Quatidade),
                             SomaTotal = produtoGroup.Sum(i => i.Total)
                         };

            return result;
        }
        public static IEnumerable<PagamentoByCategoriaPreco>? PagamentosByCategoriaPreco(T pdv)
        {
            var pedidos_validos = GetPedidosValidos(pdv);

            var result = from pedido in pedidos_validos
                         from pagamento in pedido.PagamentoPedidoEntities
                         group pagamento by new { pedido.CategoriaPrecoEntity.DescricaoCategoria, pagamento.FormaPagamentoEntity.DescricaoFormaPg } into pagamentoGroup
                         select new PagamentoByCategoriaPreco
                         {
                             CategoriaPreco = pagamentoGroup.Key.DescricaoCategoria,
                             FormaPagamento = pagamentoGroup.Key.DescricaoFormaPg,
                             SomaValorPago = pagamentoGroup.Sum(p => p.ValorPago)
                         };
            return result;
        }

    }
}
