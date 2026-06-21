using System;

namespace Logistica.App.SRP
{
    public class Pedido
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
    }

    public class PedidoRepository
    {
        public void SalvarNoBanco(Pedido pedido)
        {
            Console.WriteLine($"[SRP] Salvando pedido {pedido.Id} no banco de dados...");
        }
    }

    public class RelatorioPedidoService
    {
        public void GerarRelatorio(Pedido pedido)
        {
            Console.WriteLine($"[SRP] Gerando relatório comercial para o pedido {pedido.Id}...");
        }
    }

    public class CalculadoraFreteService
    {
        public void CalcularFrete(Pedido pedido)
        {
            Console.WriteLine($"[SRP] Calculando valor logístico do pedido {pedido.Id}...");
        }
    }
}
