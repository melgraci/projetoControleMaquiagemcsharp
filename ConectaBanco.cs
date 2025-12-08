using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace SistemaCadastro
{
    internal class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost; user id = root; password=1234; database=cadastro_banco_maquiagem");
        public string mensagem;

        public bool insereMaquiagem(Maquiagem novaMaquiagem)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd =
                    new MySqlCommand("sp_insereMaquiagem", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nome", novaMaquiagem.NomeMaquiagem);
                cmd.Parameters.AddWithValue("quantidade", novaMaquiagem.QuantidadeMaquiagem);
                cmd.Parameters.AddWithValue("estoque", novaMaquiagem.EstoqueMaquiagem);
                cmd.Parameters.AddWithValue("marca", novaMaquiagem.MarcaMaquiagem);
                cmd.ExecuteNonQuery(); //Executar no banco
                return true;
            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return false;
            }
        } //fim do InsereMaquiagem

     public DataTable listaMarca()
     {
            MySqlCommand cmd = new MySqlCommand("sp_listaMarca", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }// fim try
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
     }//fim lista_marca


        public DataTable listaMaquiagem()
        {
            MySqlCommand cmd = new MySqlCommand("sp_listaMaquiagem", conexao);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }// fim try
            catch(MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }// fim listaMaquiagem

        public bool deleteMaquiagem(int idRemoveMaquiagem)
        {
            MySqlCommand cmd = new MySqlCommand("sp_removeMaquiagem", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idmaquiagens", idRemoveMaquiagem);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); //executa o comando
                return true;

            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }// fim deleteMaquiagem

        public bool alteraMaquiagem(Maquiagem m, int idMaquiagens)
        {
         MySqlCommand cmd = new MySqlCommand("sp_alteraMaquiagem", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idMaquiagens", idMaquiagens);
            cmd.Parameters.AddWithValue("nome", m.NomeMaquiagem);
            cmd.Parameters.AddWithValue("marca", m.MarcaMaquiagem);
            cmd.Parameters.AddWithValue("quantidade", m.QuantidadeMaquiagem);
            cmd.Parameters.AddWithValue("estoque", m.EstoqueMaquiagem);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); //executa o comando
                return true;

            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }//fim altera maquiagem 

    }//fim da classe

}

