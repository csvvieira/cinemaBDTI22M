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
    class DAOSessao
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public int[] codigo;
        public DateTime[] horarioSessao;
        public int[] codigoSala;
        public int[] codigoFilme;
        public int i;
        public int contador;
        public string msg;
        public DAOSessao()
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

        public void Inserir(DateTime horarioSessao, int codigoSala, int codigoFilme)
        {
            try
            {
                dados = $"('{horarioSessao}','{codigoSala}','{codigoFilme}')";
                comando = $"Insert into sessao(codigo, horarioSessao, codigoSala, codigoFilme) values{dados}";
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine($"Inserido com sucesso! {resultado}");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu errado!\n\n {erro}");
            }//Fim do try_catch
        }//Fim do método

        public void PreencherVetorSessao()
        {
            string query = "select * from sessao";
            codigo = new int[100];
            horarioSessao = new DateTime[100];
            codigoSala = new int[100];
            codigoFilme = new int[100];

            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                horarioSessao[i] = new DateTime();
                codigoSala[i] = 0;
                codigoFilme[i] = 0;
            }//Fim do for

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                horarioSessao[i] = Convert.ToDateTime(leitura["horarioSessao"]);
                codigoSala[i] = Convert.ToInt32(leitura["codigoSala"]);
                codigoFilme[i] = Convert.ToInt32(leitura["codigoFilme"]);
                i++;
                contador++;
            }//Fim do while

            leitura.Close();
        }//Fim do método

        public string ConsultarTudoSessao()
        {
            PreencherVetorSessao();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                msg += $"\nCódigo: {codigo[i]} \nHorário da Sessão: {horarioSessao[i]} \nCódigo da Sala: {codigoSala[i]} \nCódigo do Filme : {codigoFilme[i]}\n";
            }//Fim do for

            return msg;
        }//Fim do método

        public string ConsultaPorCodigoSessao(int codigo)
        {
            PreencherVetorSessao();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    msg = $"\nCódigo: {this.codigo[i]} \nHorário da Sessão:  {horarioSessao[i]}  \nCódigo da Sala:  {codigoSala[i]} \nCódigo do Filme: {codigoFilme[i]}\n";
                    return msg;
                }//Fim do if
            }//Fim do for
            return "\n\nCódigo informado não foi encontrado";
        }//Fim do método

        public string AtualizarSessao(int codigo, string campo, DateTime novoDado)
        {
            try
            {
                string query = $"update sessao set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//Fim do método

        public string AtualizarSessao(int codigo, string campo, int novoDado)
        {
            try
            {
                string query = $"update sessao set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//Fim do método

        public string DeletarSessao(int codigo)
        {
            try
            {
                string query = $"delete from sessao where codigo = '{codigo}'";
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
