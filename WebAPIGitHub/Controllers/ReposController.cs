using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIGitHub.Models;

namespace WebAPIGitHub.Controllers
{
    public class ReposController : ApiController
    {
        // GET: api/Repos
        [HttpGet]
        [ActionName("MostraTodosRepos")]
        public IEnumerable<Repos> GetUsers(string Login_Usu)
        {
            //tenta conectar ao banco
            try
            {
                BdConector db = new BdConector();
                var repo = db.BuscaTodosRepos(Login_Usu);
                db.Fechar();
                return repo;
            }
            catch (Exception e)
            {
                //se der erado o banco retorna erro de desautorizado 
                var resp = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(resp);
            }
        }

        // GET: api/Repos/addRepos
        [HttpPost]
        [ActionName("addRepos")]
        public HttpResponseMessage Post([FromBody] List<Repos> dados)
        {
            if (dados == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

            //manda adicionar o item 
            //recebe uma lista, faz um laço para recbe um valor de cada vez
            BdConector db = new BdConector();
            foreach (var dadoRepos in dados)
            {
                db.adicionaRepos(dadoRepos);
            }

            db.Fechar();

            //retorna mensagem de sucesso
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            return response;
        }
    }
}
