using System;

namespace Logistica.App{
    
    // SRP
    public class Pedido{
        public int Id { get; set; }
        public decimal Valor { get; set; }
    }

    public class PedidoRepository{
        public void SalvarNoBanco(Pedido pedido){
            Console.WriteLine($"[SRP] Salvando pedido {pedido.Id} no banco de dados...");
        }
    }

    public class RelatorioPedidoService{
        public void GerarRelatorio(Pedido pedido){
            Console.WriteLine($"[SRP] Gerando relatório comercial para o pedido {pedido.Id}...");
        }
    }

    public class CalculadoraFreteService{
        public void CalcularFrete(Pedido pedido){
            Console.WriteLine($"[SRP] Calculando valor logístico do pedido {pedido.Id}...");
        }
    }

    // OCP
    public interface IFrete{
        decimal Calcular(decimal peso);
    }

    public class FreteNormal : IFrete{
        public decimal Calcular(decimal peso) => peso * 2;
    }

    public class FreteExpresso : IFrete{
        public decimal Calcular(decimal peso) => peso * 5;
    }

    public class FretePremium : IFrete{
        public decimal Calcular(decimal peso) => peso * 8;
    }

    public class CalculadoraFrete{
        public decimal Calcular(IFrete frete, decimal peso){
            return frete.Calcular(peso);
        }
    }

    // LSP
    public abstract class Veiculo{
        public string Placa { get; set; }
    }

    public interface IVeiculoACombustao{
        void Abastecer();
    }

    public interface IVeiculoEletrico{
        void Recarregar();
    }

    public class Carro : Veiculo, IVeiculoACombustao{
        public void Abastecer(){
            Console.WriteLine("[LSP] Abastecendo o carro com gasolina/etanol no posto.");
        }
    }

    public class CarroEletrico : Veiculo, IVeiculoEletrico{
        public void Recarregar(){
            Console.WriteLine("[LSP] Plugando o carro elétrico na estação de recarga.");
        }
    }

    // ISP
    public interface ITrabalhador{
        void Trabalhar();
    }

    public interface IControlePonto{
        void BaterPonto();
    }

    public interface IGestor{
        void GerenciarEquipe();
    }

    public class Desenvolvedor : ITrabalhador, IControlePonto{
        public void Trabalhar(){
            Console.WriteLine("[ISP] Desenvolvedor programando o sistema...");
        }

        public void BaterPonto(){
            Console.WriteLine("[ISP] Desenvolvedor registrou o ponto eletrônico.");
        }
    }

    public class Gerente : ITrabalhador, IControlePonto, IGestor{
        public void Trabalhar(){
            Console.WriteLine("[ISP] Gerente analisando métricas de entrega...");
        }

        public void BaterPonto(){
            Console.WriteLine("[ISP] Gerente registrou o ponto eletrônico.");
        }

        public void GerenciarEquipe(){
            Console.WriteLine("[ISP] Gerente realizando reunião de alinhamento 1:1 com a equipe.");
        }
    }

    // DIP
    public interface INotificacao{
        void Enviar(string mensagem);
    }

    public class EmailService : INotificacao{
        public void Enviar(string mensagem){
            Console.WriteLine($"[DIP] Email disparado: {mensagem}");
        }
    }

    public class SmsService : INotificacao{
        public void Enviar(string mensagem){
            Console.WriteLine($"[DIP] SMS enviado via provedor: {mensagem}");
        }
    }

    public class WhatsAppService : INotificacao{
        public void Enviar(string mensagem){
            Console.WriteLine($"[DIP] Mensagem de WhatsApp enviada: {mensagem}");
        }
    }

    public class PedidoService{
        private readonly INotificacao _notificacao;

        public PedidoService(INotificacao notificacao){
            _notificacao = notificacao;
        }

        public void FinalizarPedido(){
            Console.WriteLine("\n[DIP] Pedido finalizado internamente no sistema.");
            _notificacao.Enviar("Seu pedido de logística foi concluído com sucesso!");
        }
    }

    // Execução Principal
    class Program{
        static void Main(string[] args){
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
