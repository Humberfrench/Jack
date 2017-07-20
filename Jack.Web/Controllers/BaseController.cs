using System.Linq;
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
            return resultValue.Erros.Select(itemErro => string.Format("- {0} <br />", itemErro.Messagem)).Aggregate(string.Empty, (current, retornoTemp) => current + retornoTemp);
        }
    }
}
