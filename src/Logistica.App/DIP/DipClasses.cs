using System;

namespace Logistica.App.DIP{
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
}
