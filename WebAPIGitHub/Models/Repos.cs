using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIGitHub.Models
{
    public class Repos
    {
        public Repos()
        {

        }

        public string Id_Repos { get; set; }
        public string Nome_Repos { get; set; }
        public string Linguagem { get; set; }
        public string Ultimo_Commit { get; set; }
        public int Favoritos { get; set; }
        public string Descricao { get; set; }
        public int Num_Whatcher_Repos { get; set; }
        public string Privacidade { get; set; }
        public string LinkUrl { get; set; }
        public string Login_Usu { get; set; }
    }
}