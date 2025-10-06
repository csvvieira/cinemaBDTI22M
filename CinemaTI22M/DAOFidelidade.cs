using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.Mozilla;

namespace CinemaTI22M
{
    class DAOFidelidade
    {

        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public int[] codigo;
        public int[] quantidadeDeCompras;
        public int[] pontos;
        public int i;
        public int contador;
        public string msg;
        public DAOFidelidade()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=cinema;Uid=root;Password=;Convert Zero DateTime=True");
            try
            {
                conexao.Open();
                Console.WriteLine("Conectado Sucesso!");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu errado!!!\n\n {erro}");
                conexao.Close();
            }//Fim do try_catch
        }//Fim do construtor

        public void Inserir(int quantidadeDeCompras, int pontos)
        {
            try
            {
                dados = $"('','{quantidadeDeCompras}','{pontos}')";
                comando = $"Insert into cartaoFidelidade(codigo, quantidadeDeCompras, pontos) values{dados}";
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine($"Inserido com sucesso! {resultado}");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu errado!\n\n {erro}");
            }//Fim do try_catch
        }//Fim do método

        public void PreencherVetorFidelidade()
        {
            string query = "select * from cartaoFidelidade";
            codigo = new int[100];
            quantidadeDeCompras = new int[100];
            pontos = new int[100];

            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                quantidadeDeCompras[i] = 0;
                pontos[i] = 0;
            }//Fim do for

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                quantidadeDeCompras[i] = Convert.ToInt32(leitura["quantidadeDeCompras"]);
                pontos[i] = Convert.ToInt32(leitura["pontos"]);
                i++;
                contador++;
            }//Fim do while

            leitura.Close();
        }//Fim do método

        public string ConsultarTudoFidelidade()
        {
            PreencherVetorFidelidade();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                msg += $"\nCódigo: {codigo[i]} \nQuantidade de Compras: {quantidadeDeCompras[i]} \nPontos: {pontos[i]}\n";
            }//Fim do for

            return msg;
        }//Fim do método

        public string ConsultaPorCodigoFidelidade(int codigo)
        {
            PreencherVetorFidelidade();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    msg = $"\nCódigo: {this.codigo[i]} \nQuantidade de Compras: {quantidadeDeCompras[i]} \nPontos: {pontos[i]}\n";
                    return msg;
                }//Fim do if
            }//Fim do for
            return "\n\nCódigo informado não foi encontrado";
        }//Fim do método

        public string AtualizarFidelidade(int codigo, string campo, int novoDado)
        {
            try
            {
                string query = $"update cartaoFidelidade set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//Fim do método

        public string DeletarFidelidade(int codigo)
        {
            try
            {
                string query = $"delete from cartaoFidelidade where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado excluído com sucesso!";
            }
            catch (Exception erro)
            {
                return $"Algo deu errado\n\n {erro}";
            }
        }//Fim do método
    }//Fim da classe
}//Fim do projeto
