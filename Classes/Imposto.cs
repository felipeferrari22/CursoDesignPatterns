using System;

namespace DDP {
    public class Imposto {

        public string Descricao { get; set; }
        public double Porcentagem { get; set; }

        public virtual double CalculaImposto(double valorInicial) {
            return valorInicial * Porcentagem;
        }
    }

    public class ICMS : Imposto {
        public ICMS() {
            Porcentagem = 0.12;
        }

        public override double CalculaImposto(double valorInicial) {
            return base.CalculaImposto(valorInicial);
        }
    }

    public class PIS : Imposto {
        public PIS() {
            Porcentagem = 0.16;
        }

        public override double CalculaImposto(double valorInicial) {
            return base.CalculaImposto(valorInicial);
        }
    }

    public class COFINS : Imposto {
        public COFINS() {
            Porcentagem = 0.18;
        }

        public override double CalculaImposto(double valorInicial) {
            return base.CalculaImposto(valorInicial);
        }
    }

    public class ISS : Imposto {
        public ISS() {
            Porcentagem = 0.11;
        }

        public override double CalculaImposto(double valorInicial) {
            return base.CalculaImposto(valorInicial);
        }
    }
}
