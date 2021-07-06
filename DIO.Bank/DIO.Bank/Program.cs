using System;
using DIO.Bank.Classes;
using DIO.Bank.Enum;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {

        static List<Conta> listaContas = new List<Conta>();


        static void Main(string[] args)
        {
            string opcaoEscolhida = ObterOpcaoUsuario();

            while(opcaoEscolhida != "X")
            {
                switch (opcaoEscolhida)
                {
                    case "1":
                        ListarContas();
                        break;
    
                    case "2":
                        InserirNovaConta();
                        break;

                    case "3":
                        Transferir();
                        break;

                    case "4":
                        Sacar();
                        break;

                    case "5":
                        Depositar();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoEscolhida = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por usar nosso banco.");
            Console.WriteLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Bem vindo ao banco!");
            Console.WriteLine("Selecione a opção desejada.");
            Console.WriteLine();
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine("");
            return opcaoUsuario;
        }

        private static void InserirNovaConta()
        {
            Console.WriteLine("Digite 1 para FISICA, 2 PARA JURIDICA");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Nome do cliente: ");
            string entradaNome = Console.ReadLine();
            Console.WriteLine("Saldo: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            listaContas.Add(new Conta(tipoConta : (TipoConta)entradaTipoConta,
                                      nome : entradaNome,
                                      saldo: entradaSaldo,
                                      credito : entradaCredito));
        }

        private static void ListarContas()
        {

            if(listaContas.Count == 0)
            {
                Console.WriteLine("Não existem contas cadastradas.");
                return;
            }

            for (int index = 0; index < listaContas.Count; index++)
            {
                Console.WriteLine($"#{index} |{listaContas[index]} ");
            }
        }


        private static void Sacar()
        {
            Console.WriteLine("Numero da conta: ");
            int indiceDaConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Valor do saque: ");
            double valorDoSaque = double.Parse(Console.ReadLine());

            listaContas[indiceDaConta].Sacar(valorDoSaque);
        }

        private static void Depositar()
        {
            Console.WriteLine("Numero da conta: ");
            int indiceDaConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Valor do saque: ");
            double valorDoDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceDaConta].Depositar(valorDoDeposito);
        }


        private static void Transferir()
        {
            Console.WriteLine("Numero da conta de ORIGEM: ");
            int indiceDaContaDeOrigem = int.Parse(Console.ReadLine());
            Console.WriteLine("Numero da conta de DESTINO: ");
            int indiceDaContaDeDestino = int.Parse(Console.ReadLine());
            Console.WriteLine("Valor a ser transferido: ");
            double valorDaTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceDaContaDeOrigem].Transferir(valorDaTransferencia, listaContas[indiceDaContaDeDestino]);
        }
    }
}
