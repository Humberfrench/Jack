using Jack.DTO;
using Jack.Presentation.Web.Controllers.MVC;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Controllers.MVC
{
    public class FamiliaController : BaseController
    {

		// GET: Familia
		public ActionResult Index()
		{
            HttpStatusCode httpStatus;

            var listaFamilias = GetApiMethod<List<DTOFamilia>>("/Familia", null, out httpStatus);

            return View(listaFamilias);

		}

<<<<<<< HEAD
        public ActionResult Edit(int id)
        {
            HttpStatusCode httpStatus;
            var param = new Dictionary<string, object>();
            param.Add("id", id);

            var umaFamilias = GetApiMethod<DTOFamilia>("/Familia", param, out httpStatus);

            return View(umaFamilias);
        }

	}
=======
        public JsonResult Edit(int id)
        {
            HttpStatusCode httpStatus;
            var param = new Dictionary<string, object>
            {
                { "id", id }
            };

            var familia = GetApiMethod<List<DTOFamilia>>("/Familia", param, out httpStatus);

            return Json(familia, JsonRequestBehavior.AllowGet);
        }
    }
>>>>>>> 940b687e7126d6dfd5a2b8d7e93ce6c3739cff8d
}
