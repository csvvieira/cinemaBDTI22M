using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTI22M
{
    class ControlCliente
    {
        private DAOCliente dao;

        public ControlCliente(string nome, long CPF, string email, DateTime dtNascimento, string telefone, int codigoFidelidade)
        {
            this.dao = new DAOCliente();
            dao.Inserir(nome, CPF, email, dtNascimento, telefone, codigoFidelidade);
        }//Fim do construtor

        public void Imprimir()
        {
            this.dao = new DAOCliente();
            Console.WriteLine(this.dao.ConsultarTudoCliente());
        }//Fim do método

        public void ConsultaPorCodigoCliente()
        {
            this.dao = new DAOCliente();
            Console.WriteLine("Informe o código que deseja buscar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(this.dao.ConsultaPorCodigoCliente(codigo));
        }//Fim do método

        public void AtualizarCliente()
        {
            this.dao = new DAOCliente();
            Console.WriteLine("Escolha o que deseja atualizar: " +
                              "\n1. Nome" +
                              "\n2. Email" +
                              "\n3. Telefone" +
                              "\n4. Código do Cartão de Fidelidade");
            int escolha = Convert.ToInt32(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("\nAtualizar Nome");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o nome atualizado: ");
                    string nome = (Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarCliente(codigo, "nome", nome));
                    break;
                case 2:
                    Console.WriteLine("\nAtualizar Email");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo Email: ");
                    string email = Console.ReadLine();
                    Console.WriteLine(this.dao.AtualizarCliente(codigo1, "email", email));
                    break;
                case 3:
                    Console.WriteLine("\nAtualizar Telefone");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo telefone: ");
                    string telefone = Console.ReadLine();
                    Console.WriteLine(this.dao.AtualizarCliente(codigo2, "telefone", telefone));
                    break;
                case 4:
                    Console.WriteLine("\nAtualizar Código do Cartão Fidelidade");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo3 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo código: ");
                    int codigoFidelidade = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarCliente(codigo3, "codigoFidelidade", codigoFidelidade));
                    break;
                default:
                    Console.WriteLine("Impossível atualizar, algo deu errado!!!");
                    break;
            }//Fim do switch
        }//Fim do método

        public void ExcluirCliente()
        {
            this.dao = new DAOCliente();

            Console.WriteLine("Informe o código que deseja excluir: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //Chama o método para excluir
            Console.WriteLine(this.dao.DeletarCliente(codigo));
        }//Fim do método
    }//Fim da classe
}//Fim do projeto
