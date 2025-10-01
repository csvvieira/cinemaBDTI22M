using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.Mozilla;

namespace CinemaTI22M
{
    class DAOFilme
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] titulo;
        public string[] genero;
        public int i;
        public int contador;
        public string msg;
        public DAOFilme()
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

        public void Inserir(string titulo, string genero)
        {
            try
            {
                dados = $"('{titulo}','{genero}')";
                comando = $"Insert into filme(codigo, titulo, genero) values{dados}";
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine($"Inserido com sucesso! {resultado}");
            }
            catch (Exception erro)
            {
                    Console.WriteLine($"Algo deu erradi!\n\n {erro}");
            }//Fim do try_catch
        }//Fim do método
        
        public void PreencherVetorFilme()
        {
            string query = "select * from filme";
            codigo = new int[100];
            titulo = new string[100];
            genero = new string[100];

            for(i = 0; i <100; i++)
            {
                codigo[i] = 0;
                titulo[i] = "";
                genero[i] = "";
            }//Fim do for

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            while( leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                titulo[i] = leitura["titulo"] + "";
                genero[i] = leitura["genero"] + "";
                i++;
                contador++;
            }//Fim do while

            leitura.Close();
        }//Fim do método

        public string ConsultarTudoFilme()
        {
            PreencherVetorFilme();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                msg = $"\nCódigo: {codigo[i]} \nTítulo: {titulo[i]} \nGênero: {genero[i]}\n";
            }//Fim do for

            return msg;
        }//Fim do método

        public string ConsultaPorCodigoFilme(int codigo)
        {
            PreencherVetorFilme();
            msg = "";
            for(i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    msg = $"\nCódigo: {this.codigo[i]} \nTítulo: {titulo[i]} \nGênero: {genero[i]}\n";
                    return msg;
                }//Fim do if
            }//Fim do for
            return "\n\nCódigo informado não foi encontrado";
        }//Fim do método

        public string AtualizarFilme(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update filme set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//Fim do método
    }//Fim da classe
}//Fim do projeto
