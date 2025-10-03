using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTI22M
{
    class DAOIngresso
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public int[] codigo;
        public DateTime[] dataIngresso;
        public string[] assento;
        public double[] valor;
        public int[] codigoCliente;
        public int[] codigoSessao;
        public int[] codigoPromocao;
        public int i;
        public int contador;
        public string msg;
        public DAOIngresso()
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

        public void Inserir(DateTime dataIngresso, string assento, double valor, int codigoCliente, int codigoSessao, int codigoPromocao)
        {
            try
            {
                dados = $"('{dataIngresso}','{assento}','{valor}','{codigoCliente}','{codigoSessao}','{codigoPromocao}')";
                comando = $"Insert into ingresso(codigo, dataIngresso, assento, valor, codigoCliente, codigoSessao, codigoPromocao) values{dados}";
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine($"Inserido com sucesso! {resultado}");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu errado!\n\n {erro}");
            }//Fim do try_catch
        }//Fim do método

        public void PreencherVetorIngresso()
        {
            string query = "select * from ingresso";
            codigo = new int[100];
            dataIngresso = new DateTime[100];
            assento = new string[100];
            valor = new double[100];
            codigoCliente = new int[100];
            codigoSessao = new int[100];
            codigoPromocao = new int[100];

            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                dataIngresso[i] = new DateTime();
                assento[i] = "";
                valor[i] = 0;
                codigoCliente[i] = 0;
                codigoSessao[i] = 0;
                codigoPromocao[i] = 0;
            }//Fim do for

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                dataIngresso[i] = Convert.ToDateTime(leitura["dataIngresso"]);
                assento[i] = leitura["assento"] + "";
                valor[i] = Convert.ToDouble(leitura["valor"]);
                codigoCliente[i] = Convert.ToInt32(leitura["codigoCliente"]);
                codigoSessao[i] = Convert.ToInt32(leitura["codigoSessao"]);
                codigoPromocao[i] = Convert.ToInt32(leitura["codigoPromocao"]);
                i++;
                contador++;
            }//Fim do while

            leitura.Close();
        }//Fim do método

        public string ConsultarTudoIngresso()
        {
            PreencherVetorIngresso();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                msg += $"\nCódigo: {codigo[i]} \nData do Ingresso: {dataIngresso[i]} \nAssento: {assento[i]} \nValor do Ingresso: {valor[i]} " +
                    $"\nCódigo do Cliente: {codigoCliente[i]} \nCódigo da Sessão: {codigoSessao[i]} \nCódigo da Pormoção: {codigoPromocao[i]}\n";
            }//Fim do for

            return msg;
        }//Fim do método

        public string ConsultaPorCodigoIngresso(int codigo)
        {
            PreencherVetorIngresso();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    msg = $"\nCódigo: {this.codigo[i]} \nData do Ingresso: {dataIngresso[i]} \nAssento: {assento[i]} \nValor do Ingresso: {valor[i]} " +
                    $"\nCódigo do Cliente: {codigoCliente[i]} \nCódigo da Sessão: {codigoSessao[i]} \nCódigo da Pormoção: {codigoPromocao[i]}\n";
                    return msg;
                }//Fim do if
            }//Fim do for
            return "\n\nCódigo informado não foi encontrado";
        }//Fim do método

        public string AtualizarIngresso(int codigo, string campo, DateTime novoDado)
        {
            try
            {
                string query = $"update ingresso set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//Fim do método

        public string AtualizarIngresso(int codigo, string campo, double novoDado)
        {
            try
            {
                string query = $"update ingresso set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//Fim do método

        public string AtualizarIngresso(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update ingresso set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//Fim do método

        public string AtualizarIngresso(int codigo, string campo, int novoDado)
        {
            try
            {
                string query = $"update ingresso set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//Fim do método

        public string AtualizarCliente(int codigo, string campo, int novoDado)
        {
            try
            {
                string query = $"update cliente set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//Fim do método

        public string DeletarIngresso(int codigo)
        {
            try
            {
                string query = $"delete from ingresso where codigo = '{codigo}'";
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
