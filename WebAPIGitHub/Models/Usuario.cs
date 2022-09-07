using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIGitHub.Models
{
    public class Usuario
    {
        public Usuario()
        {

        }

        public Usuario(string login_Usu, string nome_Usu, int num_Repos, int num_Seguindo, int num_seguidores, string bio, string ultimo_update)
        {
            Login_Usu = login_Usu;
            Nome_Usu = nome_Usu;
            Num_Repos = num_Repos;
            Num_Seguindo = num_Seguindo;
            Num_seguidores = num_seguidores;
            Bio = bio;
            Ultimo_update = ultimo_update;
        }

        public string Login_Usu { get; set; }
        public string Nome_Usu { get; set; }
        public int Num_Repos { get; set; }
        public int Num_Seguindo { get; set; }
        public int Num_seguidores { get; set; }
        public string Bio { get; set; }
        public string Ultimo_update { get; set; }
    }
}