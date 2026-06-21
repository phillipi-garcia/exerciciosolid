namespace Logistica.App.OCP
{
    public interface IFrete
    {
        decimal Calcular(decimal peso);
    }

    public class FreteNormal : IFrete
    {
        public decimal Calcular(decimal peso) => peso * 2;
    }

    public class FreteExpresso : IFrete
    {
        public decimal Calcular(decimal peso) => peso * 5;
    }

    public class FretePremium : IFrete
    {
        public decimal Calcular(decimal peso) => peso * 8;
    }

    public class CalculadoraFrete
    {
        public decimal Calcular(IFrete frete, decimal peso)
        {
            return frete.Calcular(peso);
        }
    }
}
