namespace Easy.Services.DTOs.PDV
{
    public class PontoVendaDto
    {
        public Guid Id { get; private set; }
        public DateTime DataHoraAbertura { get; private set; }
        public Guid UsuarioGerentePdvId { get; private set; }
        public string UsuarioGerenteNome { get; private set; }
        public Guid UsuarioPdvId { get; private set; }
        public string UsuarioPdvNome { get; private set; }
        public bool Aberto { get; private set; }
        public Guid PeriodoPdvId { get; private set; }
        public string PeriodoDescricao { get; private set; }

        #region Campos Auxiliares
        public int QtdPedidos { get; private set; } = 0;
        public int QuantidadePedidosValidos { get; private set; } = 0;
        public int QuantidadePedidosCancelados { get; private set; } = 0;
        public decimal SomaValorTotalPedidos { get; private set; } = 0;
        public decimal SomaValorTotalPedidosValidos { get; private set; } = 0;
        public decimal SomaValorTotalPedidosCancelados { get; private set; } = 0;
        public decimal TicketMedio { get; private set; } = 0;
        public decimal SomaDescontoPedidosValidos { get; private set; } = 0;

        #endregion
        public PontoVendaDto(Guid id, Guid usuarioGerentePdvId, string usuarioGerenteNome, Guid usuarioPdvId, string usuarioPdvNome, bool aberto, Guid periodoPdvId, string periodoDescricao, DateTime dataHoraAbertura, int qtdPedidos)
        {
            Id = id;
            UsuarioGerentePdvId = usuarioGerentePdvId;
            UsuarioGerenteNome = usuarioGerenteNome;
            UsuarioPdvId = usuarioPdvId;
            UsuarioPdvNome = usuarioPdvNome;
            Aberto = aberto;
            PeriodoPdvId = periodoPdvId;
            PeriodoDescricao = periodoDescricao;
            DataHoraAbertura = dataHoraAbertura;
            QtdPedidos = qtdPedidos;
        }


        public PontoVendaDto(Guid id, Guid usuarioGerentePdvId, string usuarioGerenteNome, Guid usuarioPdvId, string usuarioPdvNome, bool aberto, Guid periodoPdvId, string periodoDescricao, DateTime dataHoraAbertura, int qtdPedidos, int quantidadePedidosValidos, int quantidadePedidosCancelados, decimal somaValorTotalPedidos, decimal somaValorTotalPedidosValidos, decimal somaValorTotalPedidosCancelados, decimal ticketMedio, decimal somaDescontoPedidosValidos)
        {
            Id = id;
            UsuarioGerentePdvId = usuarioGerentePdvId;
            UsuarioGerenteNome = usuarioGerenteNome;
            UsuarioPdvId = usuarioPdvId;
            UsuarioPdvNome = usuarioPdvNome;
            Aberto = aberto;
            PeriodoPdvId = periodoPdvId;
            PeriodoDescricao = periodoDescricao;
            DataHoraAbertura = dataHoraAbertura;
            QtdPedidos = qtdPedidos;

            QtdPedidos = qtdPedidos;
            QuantidadePedidosValidos = quantidadePedidosValidos;
            QuantidadePedidosCancelados = quantidadePedidosCancelados;
            SomaValorTotalPedidos = somaValorTotalPedidos;
            SomaValorTotalPedidosValidos = somaValorTotalPedidosValidos;
            SomaValorTotalPedidosCancelados = somaValorTotalPedidosCancelados;
            TicketMedio = ticketMedio;
            SomaDescontoPedidosValidos = somaDescontoPedidosValidos;
        }
        public override string ToString()
        {
            return $"Ponto de Venda: Total de Pedidos {QtdPedidos}";
        }
    }
}
