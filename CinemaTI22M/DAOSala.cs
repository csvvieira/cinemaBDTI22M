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
    class DAOSala
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public int[] codigo;
        public int[] capacidade;
        public string[] recursos;
        public int i;
        public int contador;
        public string msg;
        public DAOSala()
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

        public void Inserir(int capacidade, string recursos)
        {
            try
            {
                dados = $"('{capacidade}','{recursos}')";
                comando = $"Insert into sala(codigo, capacidade, recursos) values{dados}";
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine($"Inserido com sucesso! {resultado}");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu errado!\n\n {erro}");
            }//Fim do try_catch
        }//Fim do método

        public void PreencherVetorSala()
        {
            string query = "select * from sala";
            codigo = new int[100];
            capacidade = new int[100];
            recursos = new string[100];

            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                capacidade[i] = 0;
                recursos[i] = "";
            }//Fim do for

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                capacidade[i] = Convert.ToInt32(leitura["capacidade"]);
                recursos[i] = leitura["recursos"] + "";
                i++;
                contador++;
            }//Fim do while

            leitura.Close();
        }//Fim do método

        public string ConsultarTudoSala()
        {
            PreencherVetorSala();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                msg += $"\nCódigo: {codigo[i]} \nCapacidade: {capacidade[i]} \nRecursos: {recursos[i]}\n";
            }//Fim do for

            return msg;
        }//Fim do método

        public string ConsultaPorCodigoSala(int codigo)
        {
            PreencherVetorSala();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    msg = $"\nCódigo: {this.codigo[i]} \nCapacidade: {capacidade[i]} \nRecursos: {recursos[i]}\n";
                    return msg;
                }//Fim do if
            }//Fim do for
            return "\n\nCódigo informado não foi encontrado";
        }//Fim do método

        public string AtualizarSala(int codigo, string campo, int novoDado)
        {
            try
            {
                string query = $"update sala set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//Fim do método

        public string AtualizarSala(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update sala set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//Fim do método

        public string DeletarSala(int codigo)
        {
            try
            {
                string query = $"delete from sala where codigo = '{codigo}'";
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
