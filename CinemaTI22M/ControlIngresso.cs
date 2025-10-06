using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTI22M
{
    class ControlIngresso
    {
        private DAOIngresso dao;

        public ControlIngresso()
        {
            dao = new DAOIngresso();
        }//Fim do construtor

        public ControlIngresso(DateTime dataIngresso, string assento, double valor, int codigoCliente, int codigoSessao, int codigoPromocao)
        {
            this.dao = new DAOIngresso();
            dao.Inserir(dataIngresso, assento, valor, codigoCliente, codigoSessao, codigoPromocao);
        }//Fim do construtor

        public void Imprimir()
        {
            this.dao = new DAOIngresso();
            Console.WriteLine(this.dao.ConsultarTudoIngresso());
        }//Fim do método

        public void ConsultaPorCodigoIngresso()
        {
            this.dao = new DAOIngresso();
            Console.WriteLine("Informe o código que deseja buscar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(this.dao.ConsultaPorCodigoIngresso(codigo));
        }//Fim do método

        public void AtualizarIngresso()
        {
            this.dao = new DAOIngresso();
            Console.WriteLine("Escolha o que deseja atualizar: " +
                              "\n1. Assento" +
                              "\n2. Valor" +
                              "\n3. Código do Cliente" +
                              "\n4. Código da Sessão" +
                              "\n5. Código da Promoção");
            int escolha = Convert.ToInt32(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("\nAtualizar Assento");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo assento: ");
                    string assento = (Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarIngresso(codigo, "assento", assento));
                    break;
                case 2:
                    Console.WriteLine("\nAtualizar Valor");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo valor: ");
                    double valor = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarIngresso(codigo1, "valor", valor));
                    break;
                case 3:
                    Console.WriteLine("\nAtualizar Código do Cliente");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo código: ");
                    int codigoCliente = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarIngresso(codigo2, "codigoCliente", codigoCliente));
                    break;
                case 4:
                    Console.WriteLine("\nAtualizar Código da Sessão");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo3 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo código: ");
                    int codigoSessao = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarIngresso(codigo3, "codigoSessao", codigoSessao));
                    break;
                case 5:
                    Console.WriteLine("\nAtualizar Código da Promoção");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo4 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo código: ");
                    int codigoPromocao = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarIngresso(codigo4, "codigoPromocao", codigoPromocao));
                    break;
                default:
                    Console.WriteLine("Impossível atualizar, algo deu errado!!!");
                    break;
            }//Fim do switch
        }//Fim do método

        public void ExcluirIngresso()
        {
            this.dao = new DAOIngresso();

            Console.WriteLine("Informe o código que deseja excluir: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //Chama o método para excluir
            Console.WriteLine(this.dao.DeletarIngresso(codigo));
        }//Fim do método
    }//Fim da classe
}//Fim do projeto
