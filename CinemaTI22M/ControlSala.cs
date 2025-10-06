using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTI22M
{
    class ControlSala
    {
        private DAOSala dao;

        public ControlSala()
        {
            dao = new DAOSala();
        }//Fim do construtor

        public ControlSala(int capacidade, string recursos)
        {
            this.dao = new DAOSala();
            dao.Inserir(capacidade, recursos);
        }//Fim do construtor

        public void Imprimir()
        {
            this.dao = new DAOSala();
            Console.WriteLine(this.dao.ConsultarTudoSala());
        }//Fim do método

        public void ConsultaPorCodigoSala()
        {
            this.dao = new DAOSala();
            Console.WriteLine("Informe o código que deseja buscar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(this.dao.ConsultaPorCodigoSala(codigo));
        }//Fim do método

        public void AtualizarSala()
        {
            this.dao = new DAOSala();
            Console.WriteLine("Escolha o que deseja atualizar: " +
                              "\n1. Capacidade" +
                              "\n2. Recursos");
            int escolha = Convert.ToInt32(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("\nAtualizar Capacidade");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe a nova capacidade: ");
                    int capacidade = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarSala(codigo, "capacidade", capacidade));
                    break;
                case 2:
                    Console.WriteLine("\nAtualizar Recursos");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe os novos recursos: ");
                    string recursos = Console.ReadLine();
                    Console.WriteLine(this.dao.AtualizarSala(codigo1, "recursos", recursos));
                    break;
                default:
                    Console.WriteLine("Impossível atualizar, algo deu errado!!!");
                    break;
            }//Fim do switch
        }//Fim do método

        public void ExcluirSala()
        {
            this.dao = new DAOSala();

            Console.WriteLine("Informe o código que deseja excluir: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //Chama o método para excluir
            Console.WriteLine(this.dao.DeletarSala(codigo));
        }//Fim do método
    }//Fim da classe
}//Fim do projeto
