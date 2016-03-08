using Jack.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace Controllers.API
{
    public class TesteController : ApiController
	{

		// GET: api/Teste
		public IList<CriancaMoralCrista> GetValues()
		{
            IList<CriancaMoralCrista> criancas;
            Jack.Business.CriancaMoralCrista oCrianca = new Jack.Business.CriancaMoralCrista();

            criancas = oCrianca.LoadAll();

            return criancas;
        }

		// GET: api/Teste/5
		public string GetValue(int id)
		{
			return "value";
		}

		// POST: api/Teste
		public void PostValue(	[FromBody()] string value)
		{
		}

		// PUT: api/Teste/5
		public void PutValue(int id, [FromBody()] string value)
		{
		}

		// DELETE: api/Teste/5

		public void DeleteValue(int id)
		{
		}
	}
}
