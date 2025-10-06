using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTI22M
{
    class ControlFidelidade
    {
        private DAOFidelidade dao;

        public ControlFidelidade()
        {
            dao = new DAOFidelidade();
        }//Fim do construtor

        public ControlFidelidade(int quantidadeDeCompras, int pontos)
        {
            this.dao = new DAOFidelidade();
            dao.Inserir(quantidadeDeCompras, pontos);
        }//Fim do construtor

        public void Imprimir()
        {
            this.dao = new DAOFidelidade();
            Console.WriteLine(this.dao.ConsultarTudoFidelidade());
        }//Fim do método

        public void ConsultaPorCodigoFidelidade()
        {
            this.dao = new DAOFidelidade();
            Console.WriteLine("Informe o código que deseja buscar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(this.dao.ConsultaPorCodigoFidelidade(codigo));
        }//Fim do método

        public void AtualizarFidelidade()
        {
            this.dao = new DAOFidelidade();
            Console.WriteLine("Escolha o que deseja atualizar: " +
                              "\n1. Quantidade de Compras" +
                              "\n2. Pontos");
            int escolha = Convert.ToInt32(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("\nAtualizar Quantidade de Compras");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe a nova quantidade de compras: ");
                    int quantidadeDeCompras = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarFidelidade(codigo, "quantidadeDeCompras", quantidadeDeCompras));
                    break;
                case 2:
                    Console.WriteLine("\nAtualizar Pontos");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe a nova quantidade de pontos: ");
                    int pontos = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarFidelidade(codigo1, "pontos", pontos));
                    break;
                default:
                    Console.WriteLine("Impossível atualizar, algo deu errado!!!");
                    break;
            }//Fim do switch
        }//Fim do método

        public void ExcluirFidelidade()
        {
            this.dao = new DAOFidelidade();

            Console.WriteLine("Informe o código que deseja excluir: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //Chama o método para excluir
            Console.WriteLine(this.dao.DeletarFidelidade(codigo));
        }//Fim do método
    }//Fim da classe
}//Fim do projeto
