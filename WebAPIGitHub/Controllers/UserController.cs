using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIGitHub.Models;

namespace WebAPIGitHub.Controllers
{
    public class UserController : ApiController
    {
        List<Usuario> usuarios = new List<Usuario>();


        //sleceioan user pelo login
        //GET: api/User/MostraUser?Login_Usu={Login_Usu}
        [HttpGet]
        [ActionName("MostraUser")]
        public IEnumerable<Usuario> GetUsers(string Login_Usu)
        {
            //tenta conectar ao banco
            try
            {
                BdConector db = new BdConector();
                var user = db.BuscaTodos(Login_Usu);
                db.Fechar();
                return user;
            }
            catch (Exception e)
            {
                //se der erado o banco retorna erro de desautorizado 
                var resp = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(resp);
            }
        }

        [HttpPost]
        [ActionName("addUser")]
        public HttpResponseMessage Post([FromBody] List<Usuario> dados)
        {
            if (dados == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

            //manda adicionar o item 
            //recebe uma lista, faz um laço para recbe um valor de cada vez
            BdConector db = new BdConector();
            foreach (var item in dados)
            {
                db.adicionaUser(item);
            }

            db.Fechar();

            //retorna mensagem de sucesso
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            return response;
        }

    }
}
