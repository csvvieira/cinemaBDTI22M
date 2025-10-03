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
    class DAOPromocao
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public int[] codigo;
        public DateTime[] dataPromocao;
        public DateTime[] horario;
        public int i;
        public int contador;
        public string msg;
        public DAOPromocao()
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

        public void Inserir(DateTime dataPromocao, DateTime horario)
        {
            try
            {
                dados = $"('{dataPromocao}','{horario}')";
                comando = $"Insert into promocao(codigo, dataPromocao, horario) values{dados}";
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine($"Inserido com sucesso! {resultado}");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu errado!\n\n {erro}");
            }//Fim do try_catch
        }//Fim do método

        public void PreencherVetorPromocao()
        {
            string query = "select * from promocao";
            codigo = new int[100];
            dataPromocao = new DateTime[100];
            horario = new DateTime[100];

            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                dataPromocao[i] = new DateTime();
                horario[i] = new DateTime();
            }//Fim do for

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                dataPromocao[i] = Convert.ToDateTime(leitura["dataPromocao"]);
                horario[i] = Convert.ToDateTime(leitura["horario"]);
                i++;
                contador++;
            }//Fim do while

            leitura.Close();
        }//Fim do método

        public string ConsultarTudoPromocao()
        {
            PreencherVetorPromocao();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                msg += $"\nCódigo: {codigo[i]} \nData da Promoção: {dataPromocao[i]} \nHorário: {horario[i]}\n";
            }//Fim do for

            return msg;
        }//Fim do método

        public string ConsultaPorCodigoPromocao(int codigo)
        {
            PreencherVetorPromocao();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    msg = $"\nCódigo: {this.codigo[i]} \nData da Promoção:  {dataPromocao[i]}  \nHorário:  {horario[i]}\n";
                    return msg;
                }//Fim do if
            }//Fim do for
            return "\n\nCódigo informado não foi encontrado";
        }//Fim do método

        public string AtualizarPromocao(int codigo, string campo, DateTime novoDado)
        {
            try
            {
                string query = $"update promocao set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//Fim do método

        public string DeletarPromocao(int codigo)
        {
            try
            {
                string query = $"delete from promocao where codigo = '{codigo}'";
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
