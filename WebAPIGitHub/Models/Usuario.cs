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


        public string Login_Usu { get; set; }
        public string Nome_Usu { get; set; }
        public int Num_Repos { get; set; }
        public int Num_Seguindo { get; set; }
        public int Num_seguidores { get; set; }
        public string Bio { get; set; }
        public string Ultimo_update { get; set; }
        public string LinkImg { get; set; }
    }
}