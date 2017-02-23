using Jack.DomainValidator;
using Jack.Library;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{
    [NoCache]
    public class BaseController : Controller
    {

        protected string RenderizeErros(ValidationResult resultValue)
        {

            string retorno = string.Empty;

            foreach (ValidationError itemErro in resultValue.Erros)
            {
                var retornoTemp = string.Format("- {0} <br />", itemErro.Messagem);
                retorno += retornoTemp;
            }

            return retorno;
        }

    }
}
