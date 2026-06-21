using System;

namespace Logistica.App.LSP{
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
}
