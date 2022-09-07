using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIGitHub.Models;
using System.Data.SqlClient;

namespace WebAPIGitHub.Controllers
{
    public class BdConector
    {
        MySqlConnection conexao;

        //servidor de banco de dados
        static string host = "localhost";
        //nome do banco de dados
        static string database = "bdApiGithub";
        //usuário de conexão do banco de dados
        static string userDB = "root";
        //senha de conexão do banco de dados
        static string password = "PLMjy579";

        //string de conexão ao BD
        public static string strProvider = "server=" + host +
                                            ";Database=" + database +
                                            ";User ID=" + userDB +
                                            ";Password=" + password;

        public static Boolean novo = false;
        public String sql;

        public BdConector()
        {
            //cria conexão
            conexao = new MySqlConnection(strProvider);
            //Abre uma conexão de banco de dados 
            conexao.Open();

        }

        //------para cada ação criar um metodo no banco-------
        public List<Usuario> BuscaTodos(string Login_Usu)
        {
            //efetua comando com a conexao
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Usuario where login_usu = @Login_Usu;", conexao);
            cmd.Parameters.AddWithValue("@Login_Usu", Login_Usu);
            MySqlDataReader retorno = cmd.ExecuteReader();
            //lista
            List<Usuario> user = new List<Usuario>();
            while (retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                    Login_Usu = retorno["Login_Usu"].ToString(),
                    Nome_Usu = retorno["Nome_Usu"].ToString(),
                    Num_Repos = int.Parse(retorno["Num_Repos"].ToString()),
                    Num_Seguindo = int.Parse(retorno["Num_Seguindo"].ToString()),
                    Num_seguidores = int.Parse(retorno["Num_seguidores"].ToString()),
                    Bio = retorno["Bio"].ToString(),
                    Ultimo_update = retorno["Ultimo_update"].ToString(),
                };
                user.Add(TempUsuario);
            }
            retorno.Close();

            return user;

        }



        //------metodos de inserção-------
        //insert
        public void adicionaUser(Usuario usuario)
        {
            MySqlCommand cmd = new MySqlCommand("call SpAddUser(@login_Usu, @nome_Usu, @num_Repos, @num_Seguindo, @num_seguidores, @Bio, @ultimo_update)", conexao);
            cmd.Parameters.AddWithValue("@login_Usu", usuario.Login_Usu);
            cmd.Parameters.AddWithValue("@nome_Usu", usuario.Nome_Usu);
            cmd.Parameters.AddWithValue("@num_Repos", usuario.Num_Repos);
            cmd.Parameters.AddWithValue("@num_Seguindo", usuario.Num_Seguindo);
            cmd.Parameters.AddWithValue("@num_seguidores", usuario.Num_seguidores);
            cmd.Parameters.AddWithValue("@Bio", usuario.Bio);
            cmd.Parameters.AddWithValue("@ultimo_update", usuario.Ultimo_update);
            cmd.ExecuteNonQuery();
        }

        public void Fechar()
        {
            conexao.Close();
        }
    }
}