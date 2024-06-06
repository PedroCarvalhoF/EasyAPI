using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Dtos.PontoVendaDtos;
using Domain.Entities.PedidoSituacao.Ferramentas;

namespace Domain.Dtos.PontoVenda.Dashboards
{
    public static class DashPontoVendaCalculator<T> where T : PontoVendaDto
    {
        //TUDO REFERENTE A PEDIDOS
        static IEnumerable<PedidoDto> GetPedidosValidos(T pdv)
        {
            IEnumerable<PedidoDto> pedidos_validos = from pedido in pdv.PedidoEntities
                                                     where pedido.Habilitado == true && pedido.SituacaoPedidoEntity.Id == GuidSituacaoPedido.SituacaoFechadoID
                                                     select pedido;
            return pedidos_validos;
        }
        static IEnumerable<PedidoDto> GetPedidosCancelados(T pdv)
        {
            IEnumerable<PedidoDto> pedidos_validos = from pedido in pdv.PedidoEntities
                                                     where pedido.Habilitado == false || pedido.SituacaoPedidoEntity.Id != GuidSituacaoPedido.SituacaoFechadoID
                                                     select pedido;
            return pedidos_validos;
        }

        public static Guid GetIdPdv(T pdv)
        {
            return pdv.Id;
        }
        public static string GetPeriodoPdv(T pdv)
        {
            string? periodo = pdv.PeriodoPontoVendaEntity.DescricaoPeriodo;
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
            string situacao = pdv.AbertoFechado ? "Aberto" : "Encerrado";
            return situacao;
        }
        public static string GetUsuarioResponsavelAberturaCaixa(T pdv)
        {
            Identity.UserIdentity.User? user = pdv.UserPdvCreate.User;
            return user.Nome;
        }
        public static string GetUsuarioOperadorCaixa(T pdv)
        {
            Identity.UserIdentity.User? user = pdv.UserPdvUsing.User;
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
            IEnumerable<PedidoDto> pedido = GetPedidosValidos(pdv);
            return pedido.Sum(pedido => pedido.ValorDesconto);
        }
        public static decimal Total(T pdv)
        {
            List<PedidoDto> pedidos_validos = GetPedidosValidos(pdv).ToList();
            return pedidos_validos.Sum(pedido => pedido.ValorPedido);
        }
        public static decimal TicktMedio(T pdv)
        {
            decimal tm = Total(pdv) / QtdPedidos(pdv);
            return tm;

        }
        public static IEnumerable<ResumoPagamento> ResumoPagamentos(T pdv)
        {
            IEnumerable<PedidoDto> pedidos_validos = GetPedidosValidos(pdv);

            IEnumerable<ResumoPagamento> result = from pedido in pedidos_validos
                                                  from pagamento in pedido.PagamentoPedidoEntities
                                                  group pagamento by pagamento.FormaPagamentoEntity.DescricaoFormaPg into pagamentoGroup
                                                  select new ResumoPagamento
                                                  {
                                                      FormaPagamento = pagamentoGroup.Key,
                                                      ValorPagoInformado = pagamentoGroup.Sum(p => p.ValorPago)
                                                  };

            result = result.OrderBy(f => f.FormaPagamento);
            return result;
        }
        public static IEnumerable<ResumoProdutos> ResumoProdutos(T pdv)
        {
            IEnumerable<PedidoDto> pedidos_validos = GetPedidosValidos(pdv);
            IEnumerable<ResumoProdutos> result = from pedidos in pedidos_validos
                                                 from itens in pedidos.ItensPedidoEntities.Where(i => i.Habilitado)
                                                 group itens by itens.ProdutoEntity.NomeProduto into itensGroup
                                                 select new ResumoProdutos
                                                 {
                                                     NomeProduto = itensGroup.Key,
                                                     TotalProdutos = itensGroup.Sum(p => p.Quatidade)
                                                 };

            result = result.OrderBy(p => p.NomeProduto).ThenByDescending(p => p.TotalProdutos);

            return result;
        }

        //consultas por categoria de preço
        public static IEnumerable<CategoriaPrecoGroupBy>? PedidosByCategoriaPreco(T pdv)
        {
            IEnumerable<PedidoDto> pedidos_validos = GetPedidosValidos(pdv);

            IEnumerable<CategoriaPrecoGroupBy> CategoriaPrecoGroupBy = from pedido in pedidos_validos.Where(item => item.ItensPedidoEntities.Any(item => item.Habilitado == true))
                                                                       group pedido by pedido.CategoriaPrecoEntity.DescricaoCategoria into categoriaGroup
                                                                       select new CategoriaPrecoGroupBy
                                                                       {
                                                                           Categoria = categoriaGroup.Key,
                                                                           SomaValorPedido = categoriaGroup.Sum(p => p.ValorPedido),
                                                                           QuantidadePedido = categoriaGroup.Count(),
                                                                           TicketMedio = categoriaGroup.Average(p => p.ValorPedido)
                                                                       };

            CategoriaPrecoGroupBy = CategoriaPrecoGroupBy.OrderBy(cat => cat.Categoria);
            return CategoriaPrecoGroupBy;
        }
        public static IEnumerable<ProdutosByCategoriaGroupBy>? ProdutosByCategoriaPreco(T pdv)
        {
            IEnumerable<PedidoDto> pedidos_validos = GetPedidosValidos(pdv);

            IEnumerable<ProdutosByCategoriaGroupBy> result = from pedido in pedidos_validos
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

            result = result.OrderBy(cat => cat.CategoriaPreco).ThenBy(p => p.NomeProduto).ThenBy(pr => pr.Preco).ThenBy(qtd => qtd.QuantidadeTotal);
            return result;
        }
        public static IEnumerable<PagamentoByCategoriaPreco>? PagamentosByCategoriaPreco(T pdv)
        {
            IEnumerable<PedidoDto> pedidos_validos = GetPedidosValidos(pdv);

            IEnumerable<PagamentoByCategoriaPreco> result = from pedido in pedidos_validos
                                                            from pagamento in pedido.PagamentoPedidoEntities
                                                            group pagamento by new { pedido.CategoriaPrecoEntity.DescricaoCategoria, pagamento.FormaPagamentoEntity.DescricaoFormaPg } into pagamentoGroup
                                                            select new PagamentoByCategoriaPreco
                                                            {
                                                                CategoriaPreco = pagamentoGroup.Key.DescricaoCategoria,
                                                                FormaPagamento = pagamentoGroup.Key.DescricaoFormaPg,
                                                                QtdPagamentoGroup = pagamentoGroup.Count(p => p.Habilitado),
                                                                SomaValorPago = pagamentoGroup.Sum(p => p.ValorPago)
                                                            };

            result = result.OrderBy(cat => cat.CategoriaPreco).ThenBy(cat => cat.FormaPagamento);
            return result;
        }

        public static IEnumerable<ProdutosByCategoriaGroupBy>? GetResumoProdutosQtdPrecoTotalByAvulso(T pdv)
        {
            IEnumerable<PedidoDto> pedidos_validos = GetPedidosValidos(pdv).Where(pedido => pedido.NumeroPedido == "avulso");

            IEnumerable<ProdutosByCategoriaGroupBy> result = from pedido in pedidos_validos
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

            result = result.OrderBy(cat => cat.CategoriaPreco).ThenBy(p => p.NomeProduto).ThenBy(pr => pr.Preco).ThenBy(qtd => qtd.QuantidadeTotal);

            return result;
        }

    }
}
