using System;
using System.Globalization;

namespace ConsoleApp2 {
    class Conta {

        private double _saldo;
        public int NumeroDaConta { get; private set; }
        public string NomeDoTitular { get; set; }
        public Conta(int numeroDaConta, string nomeDoTitular) {
            NumeroDaConta = numeroDaConta;
            NomeDoTitular = nomeDoTitular;
            _saldo = 0;
        }
        public Conta(int numeroDaConta, string nomeDoTitular, double saldo) : this(numeroDaConta, nomeDoTitular) {
            _saldo = saldo;
        }

        
        public double Saldo {
            get { return _saldo; }
        }

        public void Depositar(double value) {
            _saldo += value;
        }

        public void Sacar(double value) {
            //esse banco não permite empréstimos nem saldo negativo, por isso esse validador
            if( Saldo - value > 5) {
            _saldo -= value + 5;
            }
        }
        

    }
    class Program {

        static void Main(string[] args) {

            Conta conta;

            Console.Write("Entre o número da conta: ");
            int accNumber = int.Parse(Console.ReadLine());
            Console.Write("Entre o titular da conta: ");
            string ownerName = Console.ReadLine();
            Console.Write("Você deseja fazer um depósito inicial? s/n");
            char deposit = char.Parse(Console.ReadLine());
            
            if('s'.Equals(deposit)) {
                Console.Write("Digite o valor do depósito inicial");
                double initialDepValue = double.Parse(Console.ReadLine());
                conta = new Conta(accNumber, ownerName, initialDepValue);
            } else {
                conta = new Conta(accNumber, ownerName);
            }
            Console.Write("Gostaria de depositar ou sacar? depositar/sacar ");
            string operacao = Console.ReadLine();
            
            if(operacao.Equals("sacar")) {
                Console.Write("Digite o valor do saque ");
                double val = double.Parse(Console.ReadLine());
                conta.Sacar(val);
                Console.WriteLine($"Seu novo saldo é de {conta.Saldo} ");
            } else if (operacao.Equals("depositar")) {
                Console.Write("Digite o valor do depósito");
                double val = double.Parse(Console.ReadLine());
                conta.Depositar(val);
                Console.WriteLine($"Seu novo saldo é de {conta.Saldo} ");
            } else {
                Console.WriteLine($"Seu saldo final é de {conta.Saldo} ");
                Console.Write("Abortado pelo usuário");
            }

            

        }
    }
}