using System;
namespace DDP{

    class Program {
            static void Main(string[] args)
            {
                var itens = new List<Item>{
                    new Item(200.12, "Caneta"),
                    new Item(100.20, "Borracha"),
                    new Item(300.49, "Lápis"),
                    new Item(32.10, "Ovos de Codorna"),
                    new Item(45.32, "Hambúrguer Congelado"),
                    new Item(33.20, "Maracujá"),
                    new Item(50.40, "Filé Mignon")
                };

                Orcamento orcamento = new Orcamento(itens);
                Imposto pis = new PIS();
                pis.Descricao = "PIS";
                Imposto cofins = new COFINS();
                cofins.Descricao = "COFINS";
                 Imposto icms = new ICMS();
                icms.Descricao = "ICMS";
                Imposto iss = new ISS();
                iss.Descricao = "ISS";
                
                var impostos = new List<Imposto>{
                    pis,
                    cofins,
                    icms,
                    iss
                };
                
                void imprimeImpostos(Orcamento orcamento, List<Imposto> impostos){
                    Console.WriteLine("O orçamento informado possui os seguintes itens:" + Environment.NewLine);
                    List<Item> listaItens = orcamento.getListaItens();
                    foreach(var item in listaItens){
                        Console.WriteLine($"Item: {item.Nome} ------ Valor: {item.Valor}");
                    }
                    Console.WriteLine($"O valor total do orçamento é: R${orcamento.Valor}" + Environment.NewLine);
                    Console.WriteLine("Os seguintes impostos deverão ser pagos: " + Environment.NewLine);            
                    foreach(Imposto imposto in impostos){
                        Console.WriteLine($"{imposto.Descricao} ---------- R${Math.Round((imposto.CalculaImposto(orcamento.Valor)),2)}");
                    }
                }
        
                void imprimeDescontos(Orcamento orcamento){
                    IDescontoHandler descontoPorQuantidade = new DescontoPorQuantidadeHandler();
                    IDescontoHandler descontoPorValorTotal = new DescontoPorValorTotalHandler();

                    descontoPorQuantidade.DefinirProximo(descontoPorValorTotal);

                    double descontoFinal = descontoPorQuantidade.CalcularDesconto(orcamento);

                    if (descontoFinal == 0)
                    {
                        Console.WriteLine("Nenhum desconto aplicado");
                    }
                    else
                    {   
                        double valorDesconto = orcamento.Valor * descontoFinal;
                        Console.WriteLine($"Desconto total aplicado: R${Math.Round((valorDesconto),2)}");
                    }
                }
                imprimeImpostos(orcamento, impostos);
                imprimeDescontos(orcamento);
        }
    }
}