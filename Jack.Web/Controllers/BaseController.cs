using Jack.DomainValidator;
using System.Web.Mvc;
using Jack.Library;

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
                var retornoTemp = string.Format("- {0} <br />", itemErro.Message);
                retorno += retornoTemp;
            }

            return retorno;
        }

    }
}
