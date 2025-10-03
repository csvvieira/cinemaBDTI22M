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
    class DAOCliente
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] nome;
        public long[] CPF;
        public string[] email;
        public DateTime[] dtNascimento;
        public string[] telefone;
        public int[] codigoFidelidade;
        public int i;
        public int contador;
        public string msg;
        public DAOCliente()
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

        public void Inserir(string nome, long CPF, string email, DateTime dtNascimento, string telefone, int codigoFidelidade)
        {
            try
            {
                dados = $"('{nome}','{CPF}','{email}','{dtNascimento}','{telefone}','{codigoFidelidade}')";
                comando = $"Insert into cliente(codigo, nome, CPF, email, dtNascimento, telefone, codigoFidelidade) values{dados}";
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine($"Inserido com sucesso! {resultado}");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu errado!\n\n {erro}");
            }//Fim do try_catch
        }//Fim do método

        public void PreencherVetorCliente()
        {
            string query = "select * from cliente";
            codigo = new int[100];
            nome = new string[100];
            CPF = new long[100];
            email = new string[100];
            dtNascimento = new DateTime[100];
            telefone = new string[100];
            codigoFidelidade = new int[100];

            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                nome[i] = "";
                CPF[i] = 0;
                email[i] = "";
                dtNascimento[i] = new DateTime();
                telefone[i] = "";
                codigoFidelidade[i] = 0;
            }//Fim do for

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                nome[i] = leitura["nome"] + "";
                CPF[i] = Convert.ToInt64(leitura["CPF"]);
                email[i] = leitura["email"] + "";
                dtNascimento[i] = Convert.ToDateTime(leitura["dtNascimento"]);
                telefone[i] = leitura["telefone"] + "";
                codigoFidelidade[i] = Convert.ToInt32(leitura["codigoFidelidade"]);
                i++;
                contador++;
            }//Fim do while

            leitura.Close();
        }//Fim do método

        public string ConsultarTudoCliente()
        {
            PreencherVetorCliente();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                msg += $"\nCódigo: {codigo[i]} \nNome: {nome[i]} \nCPF: {CPF[i]} \nEmail: {email[i]} \nData de Nascimento: {dtNascimento[i]} " +
                      $"\nTelefone: {telefone[i]} \nCódigo do Cartão de Fidelidade: {codigoFidelidade[i]}\n";
            }//Fim do for

            return msg;
        }//Fim do método

        public string ConsultaPorCodigoCliente(int codigo)
        {
            PreencherVetorCliente();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    msg = $"\nCódigo: {this.codigo[i]} \nNome: {nome[i]} \nCPF: {CPF[i]} \nEmail: {email[i]} \nData de Nascimento: {dtNascimento[i]} " +
                      $"\nTelefone: {telefone[i]} \nCódigo do Cartão de Fidelidade: {codigoFidelidade[i]}\n";
                    return msg;
                }//Fim do if
            }//Fim do for
            return "\n\nCódigo informado não foi encontrado";
        }//Fim do método

        public string AtualizarCliente(int codigo, string campo, DateTime novoDado)
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

        public string AtualizarCliente(int codigo, string campo, long novoDado)
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

        public string AtualizarCliente(int codigo, string campo, string novoDado)
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

        public string DeletarCliente(int codigo)
        {
            try
            {
                string query = $"delete from cliente where codigo = '{codigo}'";
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
