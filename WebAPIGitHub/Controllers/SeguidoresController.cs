using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIGitHub.Models;

namespace WebAPIGitHub.Controllers
{
    public class SeguidoresController : ApiController
    {
        //GET: api/User/MostraUser?Login_Usu={Login_Usu}
        [HttpGet]
        [ActionName("MostraSeguidores")]
        public IEnumerable<Seguidores> GetUsers(string Login_Usu)
        {
            //tenta conectar ao banco
            try
            {
                BdConector db = new BdConector();
                var Segui = db.BuscaTodosSeguidores(Login_Usu);
                db.Fechar();
                return Segui;
            }
            catch (Exception e)
            {
                //se der erado o banco retorna erro de desautorizado 
                var resp = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(resp);
            }
        }

        [HttpPost]
        [ActionName("addSeguidores")]
        public HttpResponseMessage Post([FromBody] List<Seguidores> dadosSegui)
        {
            if (dadosSegui == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

            //manda adicionar o item 
            //recebe uma lista, faz um laço para recbe um valor de cada vez
            BdConector db = new BdConector();
            foreach (var item in dadosSegui)
            {
                db.adicionaSegui(item);
            }

            db.Fechar();

            //retorna mensagem de sucesso
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            return response;
        }
    }
}
