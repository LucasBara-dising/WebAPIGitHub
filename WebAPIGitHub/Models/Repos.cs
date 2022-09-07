using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIGitHub.Models
{
    public class Repos
    {
        string id_Repos { get; set; }
        string nome_Repos{ get; set; }
        string Linguagem { get; set; }
        string ultimo_Commit { get; set; }
        int Favoritos { get; set; }
        string Descricao { get; set; }
        int Num_Whatcher_Repos{ get; set; }
        string Privacidade { get; set; }
        string linkUrl { get; set; }
        string login_Usu { get; set; }
    }
}