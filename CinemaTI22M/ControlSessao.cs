using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTI22M
{
    class ControlSessao
    {
        private DAOSessao dao;

        public ControlSessao(DateTime horarioSessao, int codigoSala, int codigoFilme)
        {
            this.dao = new DAOSessao();
            dao.Inserir(horarioSessao, codigoSala, codigoFilme);
        }//Fim do construtor

        public void Imprimir()
        {
            this.dao = new DAOSessao();
            Console.WriteLine(this.dao.ConsultarTudoSessao());
        }//Fim do método

        public void ConsultaPorCodigoSessao()
        {
            this.dao = new DAOSessao();
            Console.WriteLine("Informe o código que deseja buscar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(this.dao.ConsultaPorCodigoSessao(codigo));
        }//Fim do método

        public void AtualizarSessao()
        {
            this.dao = new DAOSessao();
            Console.WriteLine("Escolha o que deseja atualizar: " +
                              "\n1. Horário da Sessão" +
                              "\n2. Codigo da Sala" +
                              "\n3.Codigo do Filme");
            int escolha = Convert.ToInt32(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("\nAtualizar Horário");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo horário: ");
                    DateTime horarioSessao = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarSessao(codigo, "horarioSessao", horarioSessao));
                    break;
                case 2:
                    Console.WriteLine("\nAtualizar Código da Sala");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo código: ");
                    int codigoSala = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarSessao(codigo1, "codigoSala", codigoSala));
                    break;
                case 3:
                    Console.WriteLine("\nAtualizar Código do Filme");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo código: ");
                    int codigoFilme = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarSessao(codigo2, "codigoFilme", codigoFilme));
                    break;
                default:
                    Console.WriteLine("Impossível atualizar, algo deu errado!!!");
                    break;
            }//Fim do switch
        }//Fim do método

        public void ExcluirSessao()
        {
            this.dao = new DAOSessao();

            Console.WriteLine("Informe o código que deseja excluir: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //Chama o método para excluir
            Console.WriteLine(this.dao.DeletarSessao(codigo));
        }//Fim do método
    }//Fim da classe
}//Fim do projeto
