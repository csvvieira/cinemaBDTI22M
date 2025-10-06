using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTI22M
{
    class ControlFilme
    {
        private DAOFilme dao;

        public ControlFilme()
        {
            dao = new DAOFilme();
        }//Fim do construtor

        public ControlFilme(string titulo, string genero)
        {
            this.dao = new DAOFilme();
            dao.Inserir(titulo, genero);
        }//Fim do construtor

        public void Imprimir()
        {
            this.dao = new DAOFilme();
            Console.WriteLine(this.dao.ConsultarTudoFilme());
        }//Fim do método

        public void ConsultaPorCodigoFilme()
        {
            this.dao = new DAOFilme();
            Console.WriteLine("Informe o código que deseja buscar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(this.dao.ConsultaPorCodigoFilme(codigo));
        }//Fim do método

        public void AtualizarFilme()
        {
            this.dao = new DAOFilme();
            Console.WriteLine("Escolha o que deseja atualizar: " +
                              "\n1. Título" +
                              "\n2. Gênero");
            int escolha = Convert.ToInt32(Console.ReadLine());
            switch(escolha)
            {
                case 1:
                    Console.WriteLine("\nAtualizar Título");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo título: ");
                    string titulo = Console.ReadLine();
                    Console.WriteLine(this.dao.AtualizarFilme(codigo, "titulo", titulo));
                    break;
                case 2:
                    Console.WriteLine("\nAtualizar Gênero");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo gênero: ");
                    string genero = Console.ReadLine();
                    Console.WriteLine(this.dao.AtualizarFilme(codigo1, "genero", genero));
                    break;
                default:
                    Console.WriteLine("Impossível atualizar, algo deu errado!!!");
                    break;
            }//Fim do switch
        }//Fim do método

        public void ExcluirFilme()
        {
            this.dao = new DAOFilme();

            Console.WriteLine("Informe o código que deseja excluir: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //Chama o método para excluir
            Console.WriteLine(this.dao.DeletarFilme(codigo));
        }//Fim do método
    }//Fim da classe
}//Fim do projeto
