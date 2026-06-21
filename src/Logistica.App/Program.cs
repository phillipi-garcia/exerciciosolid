using System;
using Logistica.App.DIP;
using Logistica.App.OCP;

namespace Logistica.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" SISTEMA DE LOGÍSTICA \n");
            Console.ResetColor();

         
            Console.WriteLine(" Testando OCP (Cálculo de Fretes)");
            CalculadoraFrete calculadora = new CalculadoraFrete();
            decimal pesoEncomenda = 10.5m;

            IFrete regraNormal = new FreteNormal();
            Console.WriteLine($"Frete Normal (10.5kg): R$ {calculadora.Calcular(regraNormal, pesoEncomenda):F2}");

            IFrete regraPremium = new FretePremium();
            Console.WriteLine($"Frete Premium (10.5kg): R$ {calculadora.Calcular(regraPremium, pesoEncomenda):F2}");


            Console.WriteLine("\n Testando DIP (Serviço de Notificações)");
            
            INotificacao servicoEmail = new EmailService();
            PedidoService pedidoViaEmail = new PedidoService(servicoEmail);
            pedidoViaEmail.FinalizarPedido();

            INotificacao servicoWpp = new WhatsAppService();
            PedidoService pedidoViaWpp = new PedidoService(servicoWpp);
            pedidoViaWpp.FinalizarPedido();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTestes executados com sucesso! Todos os princípios SOLID foram respeitados.");
            Console.ResetColor();
        }
    }
}
