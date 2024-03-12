using System;

namespace DDP{
public interface IDescontoHandler
{
    void DefinirProximo(IDescontoHandler proximo);
    double CalcularDesconto(Orcamento orcamento);
}

public abstract class SemDescontoHandler : IDescontoHandler
{
    protected IDescontoHandler Proximo { get; private set; }

    public void DefinirProximo(IDescontoHandler proximo)
    {
        Proximo = proximo;
    }

    public abstract double CalcularDesconto(Orcamento orcamento);
}

public class DescontoPorQuantidadeHandler : SemDescontoHandler
{
    public override double CalcularDesconto(Orcamento orcamento)
    {

        double desconto = 0;
        int quantidadeItens = orcamento.getQuantidadeItens();

        if(quantidadeItens > 5){
            desconto = 0.1;
        }

        if (desconto > 0)
        {
            Console.WriteLine("Desconto por quantidade aplicado");
            return desconto;
        }
        else if (Proximo != null)
        {
            return Proximo.CalcularDesconto(orcamento);
        }
        return 0;
    }
}

public class DescontoPorValorTotalHandler : SemDescontoHandler
{
    public override double CalcularDesconto(Orcamento orcamento)
    {

        double desconto = 0;

        if (orcamento.Valor > 500){
            desconto = 0.07;
        }

        if (desconto > 0)
        {
            return desconto;
        }
        else if (Proximo != null)
        {
            return Proximo.CalcularDesconto(orcamento);
        }
        return 0;
    }
}
}