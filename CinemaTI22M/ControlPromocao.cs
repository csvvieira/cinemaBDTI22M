using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTI22M
{
    class ControlPromocao
    {
        private DAOPromocao dao;
        
        public ControlPromocao()
        {
            dao = new DAOPromocao();
        }//Fim do construtor

        public ControlPromocao(DateTime dataPromocao, DateTime horario)
        {
            this.dao = new DAOPromocao();
            dao.Inserir(dataPromocao, horario);
        }//Fim do construtor

        public void Imprimir()
        {
            this.dao = new DAOPromocao();
            Console.WriteLine(this.dao.ConsultarTudoPromocao());
        }//Fim do método

        public void ConsultaPorCodigoPromocao()
        {
            this.dao = new DAOPromocao();
            Console.WriteLine("Informe o código que deseja buscar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(this.dao.ConsultaPorCodigoPromocao(codigo));
        }//Fim do método

        public void AtualizarPromocao()
        {
            this.dao = new DAOPromocao();
            Console.WriteLine("Escolha o que deseja atualizar: " +
                              "\n1. Data da Promoção" +
                              "\n2. Horário");
            int escolha = Convert.ToInt32(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("\nAtualizar Data da Promoção");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe a nova data: ");
                    DateTime dataPromocao = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarPromocao(codigo, "dataPromocao", dataPromocao));
                    break;
                case 2:
                    Console.WriteLine("\nAtualizar Horário");
                    Console.WriteLine("Informe o código onde vai atualizar");
                    int codigo1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo horário: ");
                    DateTime horario = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine(this.dao.AtualizarPromocao(codigo1, "horario", horario));
                    break;
                default:
                    Console.WriteLine("Impossível atualizar, algo deu errado!!!");
                    break;
            }//Fim do switch
        }//Fim do método

        public void ExcluirPromocao()
        {
            this.dao = new DAOPromocao();

            Console.WriteLine("Informe o código que deseja excluir: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //Chama o método para excluir
            Console.WriteLine(this.dao.DeletarPromocao(codigo));
        }//Fim do método
    }//Fim da classe
}//Fim do projeto
