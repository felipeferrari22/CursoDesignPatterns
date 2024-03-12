using System;
using DDP;

namespace DDP
{
    public class Item
    {
        private double valor{get;set;}
        private string nome{get;set;}

        public double Valor { get => valor; set => valor = value; }
        public string Nome { get => nome; set => nome = value; }

        public Item(double valor, string nome){
            this.valor = valor;
            this.nome = nome;
        }
    }
}