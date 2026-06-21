using System;

namespace Logistica.App.ISP{
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
}
