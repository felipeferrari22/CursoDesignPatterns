using System;
using DDP;

namespace DDP
{
    public class Orcamento
    {
        private List<Item> itens{get;set;}
        private double valor{get;set;}

        public double Valor { get => valor; set => valor = value; }

        public Orcamento(List<Item> itens){
            this.itens = itens;
            foreach(var item in itens){
                Valor += item.Valor;
            }
        }

        public int getQuantidadeItens(){
            return this.itens.Count;
        }

        public List<Item> getListaItens(){
            return this.itens;
        }
    }
}