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
        //------------------------selects------------

        //usuario
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
                    LinkImg = retorno["LinkImg"].ToString(),
                };
                user.Add(TempUsuario);
            }
            retorno.Close();

            return user;

        }

        //Repositorio
        public List<Repos> BuscaTodosRepos(string Login_Usu)
        {
            //efetua comando com a conexao
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Respositorio where login_usu = @Login_Usu;", conexao);
            cmd.Parameters.AddWithValue("@Login_Usu", Login_Usu);
            MySqlDataReader retorno = cmd.ExecuteReader();
            //lista
            List<Repos> repositorio = new List<Repos>();
            while (retorno.Read())
            {
                var TempRepos = new Repos()
                {
                    Id_Repos = retorno["Id_Repos"].ToString(),
                    Nome_Repos = retorno["Nome_Repos"].ToString(),
                    Linguagem = retorno["Linguagem"].ToString(),
                    Ultimo_Commit = retorno["Ultimo_Commit"].ToString(),
                    Favoritos = int.Parse(retorno["Favoritos"].ToString()),
                    Descricao = retorno["Descricao"].ToString(),
                    Num_Whatcher_Repos = int.Parse(retorno["Num_Whatcher_Repos"].ToString()),
                    Privacidade = retorno["Privacidade"].ToString(),
                    LinkUrl = retorno["LinkUrl"].ToString(),
                    Login_Usu = retorno["Login_Usu"].ToString(),
                };
                repositorio.Add(TempRepos);
            }
            retorno.Close();

            return repositorio;

        }

        //seguidores
        public List<Seguidores> BuscaTodosSeguidores(string Login_Usu)
        {
            //efetua comando com a conexao
            MySqlCommand cmd = new MySqlCommand("call SpSelectseguidores(@Login_Usu);", conexao);
            cmd.Parameters.AddWithValue("@Login_Usu", Login_Usu);
            MySqlDataReader retorno = cmd.ExecuteReader();
            //lista
            List<Seguidores> segui = new List<Seguidores>();
            while (retorno.Read())
            {
                var TempSegui = new Seguidores()
                {
                    id_Seg = retorno["id_Seg"].ToString(),
                    LinkFoto = retorno["LinkFoto"].ToString(),
                    Login_Usu_segui = retorno["fk_User_login"].ToString(),
                };
                segui.Add(TempSegui);
            }
            retorno.Close();

            return segui;

        }


        //------metodos de inserção-------
        //insert user
        public void adicionaUser(Usuario usuario)
        {
            MySqlCommand cmd = new MySqlCommand("call SpAddUser(@login_Usu, @nome_Usu, @num_Repos, @num_Seguindo, @num_seguidores, @Bio, @ultimo_update, @linkImg)", conexao);
            cmd.Parameters.AddWithValue("@login_Usu", usuario.Login_Usu);
            cmd.Parameters.AddWithValue("@nome_Usu", usuario.Nome_Usu);
            cmd.Parameters.AddWithValue("@num_Repos", usuario.Num_Repos);
            cmd.Parameters.AddWithValue("@num_Seguindo", usuario.Num_Seguindo);
            cmd.Parameters.AddWithValue("@num_seguidores", usuario.Num_seguidores);
            cmd.Parameters.AddWithValue("@Bio", usuario.Bio);
            cmd.Parameters.AddWithValue("@ultimo_update", usuario.Ultimo_update);
            cmd.Parameters.AddWithValue("@linkImg", usuario.LinkImg);
            cmd.ExecuteNonQuery();
        }


        //insert repos
        public void adicionaRepos(Repos repositorio)
        {
            MySqlCommand cmd = new MySqlCommand("call SpAddRepos(@id_Repos, @nome_Repos, @linguagem, @ultimo_Commit, @favoritos, @descricao, " +
                "@num_Whatcher_Repos, @privacidade, @linkUrl, @login_Usu)", conexao);

            cmd.Parameters.AddWithValue("@id_Repos", repositorio.Id_Repos);
            cmd.Parameters.AddWithValue("@nome_Repos", repositorio.Nome_Repos);
            cmd.Parameters.AddWithValue("@linguagem", repositorio.Linguagem);
            cmd.Parameters.AddWithValue("@ultimo_Commit", repositorio.Ultimo_Commit);
            cmd.Parameters.AddWithValue("@favoritos", repositorio.Favoritos);
            cmd.Parameters.AddWithValue("@descricao", repositorio.Descricao);
            cmd.Parameters.AddWithValue("@num_Whatcher_Repos", repositorio.Num_Whatcher_Repos);
            cmd.Parameters.AddWithValue("@privacidade", repositorio.Privacidade);
            cmd.Parameters.AddWithValue("@linkUrl", repositorio.LinkUrl);
            cmd.Parameters.AddWithValue("@login_Usu", repositorio.Login_Usu);
            cmd.ExecuteNonQuery();
        }

        //insert Seguidores
        public void adicionaSegui(Seguidores segui)
        {
            MySqlCommand cmd = new MySqlCommand("call SpAddSeguidores(@id_Seg, @LinkFoto, @login_Usu); ", conexao);

            cmd.Parameters.AddWithValue("@id_Seg", segui.id_Seg);
            cmd.Parameters.AddWithValue("@LinkFoto", segui.LinkFoto);
            cmd.Parameters.AddWithValue("@login_Usu", segui.Login_Usu_segui);
 
            cmd.ExecuteNonQuery();
        }

        public void Fechar()
        {
            conexao.Close();
        }
    }
}